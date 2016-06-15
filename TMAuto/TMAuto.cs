using System;
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
        private int villageIndex = 0;
        public TMAuto()
        {
            InitializeComponent();
            initComponents();
            initHandlers();
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
            LogManager.LogUpdated += new LogManager.UpdateLogHandler(controller_LogUpdated);
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
                TabPage villagePage = new TabPage(village.Name);

                TableLayoutPanel tablePanel = new TableLayoutPanel();
                tablePanel.Dock = DockStyle.Fill;
                tablePanel.ColumnCount = 2;
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                FlowLayoutPanel buildingsPanel = new FlowLayoutPanel();
                buildingsPanel.AutoSize = true;
                buildingsPanel.WrapContents = true;
                FlowLayoutPanel resourcesPanel = new FlowLayoutPanel();
                resourcesPanel.WrapContents = true;
                resourcesPanel.AutoSize = true;

                for (int j = 0; j < village.Buildings.Length; j++)
                {
                    Building b = village.Buildings[j];
                    Button button;

                    if (b.Type == 0)
                    {
                        button = new Button { Size = new Size(50,50), Text = (j + 1) + "" };
                    } else
                    {
                        button = new Button { Image = b.BuildingImage, Text = b.Level + "", AutoSize = true };
                    }

                    
                    button.Font = new Font(button.Font.Name, button.Font.Size, FontStyle.Bold);

                    int id = j;
                    button.Click += new EventHandler((s, e) => {
                        Village vill = Player.Instance.Villages[villageIndex];

                        controller.AddBuildingToQueue(vill, id);
                        var building = vill.Buildings[id];

                        if (building.Type == 0)
                        {
                            PickNewBuilding pickForm = new PickNewBuilding();
                            pickForm.ShowDialog();

                            if (pickForm.DialogResult == DialogResult.OK)
                            {
                                building.Type = pickForm.newBuildingType;
                                button.Image = building.BuildingImage;
                            } else
                            {
                                return;
                            }
                        }

                        int total = controller.GetOffset(vill, id) + building.Level;
                        button.Text = building.Level + "|" + total;
                    });

                    if (j < 18)
                    {
                        resourcesPanel.Controls.Add(button);
                    } else
                    {
                        buildingsPanel.Controls.Add(button);
                    }
                }

                tablePanel.Controls.Add(resourcesPanel);
                tablePanel.Controls.Add(buildingsPanel);
                villagePage.Controls.Add(tablePanel);

                tbCtrlBuildings.Invoke(new Action(() => tbCtrlBuildings.Controls.Add(villagePage)));
            }
        }
    }
}
