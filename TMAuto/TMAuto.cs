﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TWAuto
{
    public partial class TMAuto : Form
    {
        private Controller controller = new Controller();
        private Hero hero = Hero.Instance;
        private int villageIndex = 0;
        public TMAuto()
        {
            InitializeComponent();
            initComponents();
            initHandlers();

            rdBtnClosest.CheckedChanged += new EventHandler(chkBoxDoAdventures_CheckedChanged);
            rdBtnFurthest.CheckedChanged += new EventHandler(chkBoxDoAdventures_CheckedChanged);
            rdBtnRandom.CheckedChanged += new EventHandler(chkBoxDoAdventures_CheckedChanged);
        }

        private void initComponents()
        {
            rTxtBoxLog.HideSelection = false;

            Settings settings = Settings.Instance;

            txtBoxUsername.Text = settings.Username;
            txtBoxPassword.Text = settings.Password;
            txtBoxServer.Text = settings.Server;
        }

        private void initHandlers()
        {
            BuildingManager.TabVillagesPanelCreated += new BuildingManager.CreateTabVillagesPanelHandler(controller_TabVillagesPanelCreated);
            BuildingManager.BuildingQueueRemoved += new BuildingManager.RemoveBuildingQueueHandler(BuildingManager_BuildingQueueRemoved);
            LogManager.LogUpdated += new LogManager.UpdateLogHandler(controller_LogUpdated);
        }

        private void BuildingManager_BuildingQueueRemoved(Action action)
        {
            this.Invoke(new Action(() => action.Invoke()));
        }

        private void controller_LogUpdated(string message)
        {
            rTxtBoxLog.Invoke(new Action(() => rTxtBoxLog.AppendText(message + Environment.NewLine)));
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            saveSettings();       
        }

        private void saveSettings()
        {
            Settings settings = Settings.Instance;
            
            settings.Username = txtBoxUsername.Text;
            settings.Password = txtBoxPassword.Text;
            settings.Server = txtBoxServer.Text;

            settings.saveLastSettings();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            saveSettings();
            controller.saveResponses = checkBox2.Checked;
            controller.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
            txtBoxPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void controller_TabVillagesPanelCreated(List<Village> villages)
        {
            tbCtrlBuildings.SelectedIndexChanged += ((sender, obj) =>
            {
                villageIndex = tbCtrlBuildings.SelectedIndex;
            });

            for (int i = 0; i < villages.Count; i++)
            {
                Village village = villages[i];
                TabPage villagePage = new TabPage(village + "");

                FlowLayoutPanel buildingsPanel = new FlowLayoutPanel();
                buildingsPanel.AutoSize = true;
                buildingsPanel.WrapContents = true;
                FlowLayoutPanel resourcesPanel = new FlowLayoutPanel();
                resourcesPanel.WrapContents = true;
                resourcesPanel.AutoSize = true;

                TableLayoutPanel tablePanel = new TableLayoutPanel();
                tablePanel.Dock = DockStyle.Fill;
                tablePanel.ColumnCount = 2;

                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tablePanel.RowStyles.Add(new RowStyle());
                tablePanel.RowStyles.Add(new RowStyle());

                DataGridView queueDgView = new DataGridView() { Anchor = AnchorStyles.Bottom, Dock = DockStyle.Fill };
                queueDgView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Text" });
                queueDgView.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Time" });
                queueDgView.Columns.Add(new DataGridViewButtonColumn() { Text = "X", UseColumnTextForButtonValue = true });
                queueDgView.Columns.Add("Id", "Id");
                queueDgView.MultiSelect = false;
                queueDgView.RowHeadersVisible = false;
                queueDgView.AutoGenerateColumns = false;
                queueDgView.CellContentClick += (sender, e) =>
                {
                    var senderGrid = (DataGridView)sender;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                    {
                        Village vill = Player.Instance.Villages[villageIndex];
                        int id = ((QueuedBuilding)senderGrid.Rows[e.RowIndex].DataBoundItem).Id;

                        controller.RemoveBuildingFromQueue(vill, e.RowIndex);

                        var buildingLevel = vill.Buildings[id].Level;
                        int total = controller.GetOffset(vill, id) + buildingLevel;
                        var panel = (id < 18) ? resourcesPanel : buildingsPanel;
                        panel.Controls[id].Text = buildingLevel + (total > buildingLevel ? "|" + total : "");
                    }
                };
                queueDgView.Columns[3].Visible = false;
                var list = village.BuildingQueue.List;
                queueDgView.DataSource = list;

                for (int j = 0; j < village.Buildings.Length; j++)
                {
                    Building b = village.Buildings[j];
                    Button button;

                    if (b.Type == 0)
                    {
                        button = new Button { Size = new Size(50, 50), Text = (j + 1) + "" };
                    }
                    else
                    {
                        button = new Button { Image = b.BuildingImage, Text = b.Level + "", AutoSize = true };
                    }


                    button.Font = new Font(button.Font.Name, button.Font.Size, FontStyle.Bold);

                    int id = j;
                    button.Click += new EventHandler((s, e) =>
                    {
                        Village vill = Player.Instance.Villages[villageIndex];
                        var buildings = vill.Buildings;
                        var building = buildings[id];

                        if (building.Type == 0)
                        {
                            PickNewBuilding pickForm = new PickNewBuilding(id + 1, buildings.Where(bb => bb.Type > 4).Select(bu => bu.Type).ToArray());
                            pickForm.ShowDialog();

                            if (pickForm.DialogResult == DialogResult.OK)
                            {
                                building.Type = pickForm.newBuildingType;
                                button.Image = building.BuildingImage;
                            }
                            else
                            {
                                return;
                            }
                        }

                        controller.AddBuildingToQueue(vill, id);
                        int total = controller.GetOffset(vill, id) + building.Level;
                        button.Text = building.Level + "|" + total;
                    });

                    if (j < 18)
                    {
                        resourcesPanel.Controls.Add(button);
                    }
                    else
                    {
                        buildingsPanel.Controls.Add(button);
                    }
                }

                tablePanel.Controls.Add(resourcesPanel);
                tablePanel.Controls.Add(buildingsPanel);
                tablePanel.Controls.Add(queueDgView);

                villagePage.Controls.Add(tablePanel);

                tbCtrlBuildings.Invoke(new Action(() => tbCtrlBuildings.Controls.Add(villagePage)));
            }
        }

        private void updateHeroSettings()
        {
            if (!chkBoxDoAdventures.Checked)
            {
                hero.AdventureMode = Mode.NONE;
            }
            else
            {
                if (rdBtnClosest.Checked)
                {
                    hero.AdventureMode = Mode.CLOSEST;
                }
                else if (rdBtnFurthest.Checked)
                {
                    hero.AdventureMode = Mode.FURTHEST;
                }
                else
                {
                    hero.AdventureMode = Mode.RANDOM;
                }
            }

        }
        private void chkBoxDoAdventures_CheckedChanged(object sender, EventArgs e)
        {
            updateHeroSettings();
        }

        private void numericUpDownNormal_ValueChanged(object sender, EventArgs e)
        {
            hero.HealthNormalAdventures = (int)numericUpDownNormal.Value;
        }

        private void numericUpDownHard_ValueChanged(object sender, EventArgs e)
        {
            hero.HealthHardAdventures = (int)numericUpDownHard.Value;
        }
    }
}
