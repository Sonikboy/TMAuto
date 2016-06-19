namespace TMAuto
{
    partial class TravianBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rTxtBoxLog = new System.Windows.Forms.RichTextBox();
            this.tbCtrlMain = new System.Windows.Forms.TabControl();
            this.tabPageAccount = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtBoxServer = new System.Windows.Forms.TextBox();
            this.tagPageBuildings = new System.Windows.Forms.TabPage();
            this.tbCtrlBuildings = new System.Windows.Forms.TabControl();
            this.tabPageTroops = new System.Windows.Forms.TabPage();
            this.tabPageFarms = new System.Windows.Forms.TabPage();
            this.tabPageHero = new System.Windows.Forms.TabPage();
            this.numericUpDownHard = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNormal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxAdventureMode = new System.Windows.Forms.GroupBox();
            this.rdBtnClosest = new System.Windows.Forms.RadioButton();
            this.rdBtnRandom = new System.Windows.Forms.RadioButton();
            this.rdBtnFurthest = new System.Windows.Forms.RadioButton();
            this.chkBoxDoAdventures = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkBoxPreferHard = new System.Windows.Forms.CheckBox();
            this.lblMaxTravelTime = new System.Windows.Forms.Label();
            this.numericUpDownMaxTravelTime = new System.Windows.Forms.NumericUpDown();
            this.tbCtrlMain.SuspendLayout();
            this.tabPageAccount.SuspendLayout();
            this.tagPageBuildings.SuspendLayout();
            this.tabPageHero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormal)).BeginInit();
            this.groupBoxAdventureMode.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTravelTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Server:";
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Location = new System.Drawing.Point(117, 5);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(144, 22);
            this.txtBoxUsername.TabIndex = 4;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(117, 36);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(144, 22);
            this.txtBoxPassword.TabIndex = 5;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(106, 112);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(268, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 21);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "show";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rTxtBoxLog
            // 
            this.rTxtBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxtBoxLog.Location = new System.Drawing.Point(3, 381);
            this.rTxtBoxLog.Name = "rTxtBoxLog";
            this.rTxtBoxLog.Size = new System.Drawing.Size(996, 106);
            this.rTxtBoxLog.TabIndex = 15;
            this.rTxtBoxLog.Text = "";
            // 
            // tbCtrlMain
            // 
            this.tbCtrlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCtrlMain.Controls.Add(this.tabPageAccount);
            this.tbCtrlMain.Controls.Add(this.tagPageBuildings);
            this.tbCtrlMain.Controls.Add(this.tabPageTroops);
            this.tbCtrlMain.Controls.Add(this.tabPageFarms);
            this.tbCtrlMain.Controls.Add(this.tabPageHero);
            this.tbCtrlMain.Controls.Add(this.tabPageLog);
            this.tbCtrlMain.Location = new System.Drawing.Point(3, 3);
            this.tbCtrlMain.Name = "tbCtrlMain";
            this.tbCtrlMain.SelectedIndex = 0;
            this.tbCtrlMain.Size = new System.Drawing.Size(996, 372);
            this.tbCtrlMain.TabIndex = 14;
            // 
            // tabPageAccount
            // 
            this.tabPageAccount.Controls.Add(this.checkBox2);
            this.tabPageAccount.Controls.Add(this.txtBoxServer);
            this.tabPageAccount.Controls.Add(this.checkBox1);
            this.tabPageAccount.Controls.Add(this.label1);
            this.tabPageAccount.Controls.Add(this.label2);
            this.tabPageAccount.Controls.Add(this.label4);
            this.tabPageAccount.Controls.Add(this.txtBoxUsername);
            this.tabPageAccount.Controls.Add(this.btnLogin);
            this.tabPageAccount.Controls.Add(this.txtBoxPassword);
            this.tabPageAccount.Location = new System.Drawing.Point(4, 25);
            this.tabPageAccount.Name = "tabPageAccount";
            this.tabPageAccount.Size = new System.Drawing.Size(988, 343);
            this.tabPageAccount.TabIndex = 2;
            this.tabPageAccount.Text = "Account";
            this.tabPageAccount.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(268, 69);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(151, 21);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "save http response";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtBoxServer
            // 
            this.txtBoxServer.Location = new System.Drawing.Point(117, 69);
            this.txtBoxServer.Name = "txtBoxServer";
            this.txtBoxServer.Size = new System.Drawing.Size(144, 22);
            this.txtBoxServer.TabIndex = 12;
            // 
            // tagPageBuildings
            // 
            this.tagPageBuildings.Controls.Add(this.tbCtrlBuildings);
            this.tagPageBuildings.Location = new System.Drawing.Point(4, 25);
            this.tagPageBuildings.Name = "tagPageBuildings";
            this.tagPageBuildings.Size = new System.Drawing.Size(988, 343);
            this.tagPageBuildings.TabIndex = 0;
            this.tagPageBuildings.Text = "Buildings";
            this.tagPageBuildings.UseVisualStyleBackColor = true;
            // 
            // tbCtrlBuildings
            // 
            this.tbCtrlBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrlBuildings.Location = new System.Drawing.Point(0, 0);
            this.tbCtrlBuildings.Name = "tbCtrlBuildings";
            this.tbCtrlBuildings.SelectedIndex = 0;
            this.tbCtrlBuildings.Size = new System.Drawing.Size(988, 343);
            this.tbCtrlBuildings.TabIndex = 0;
            // 
            // tabPageTroops
            // 
            this.tabPageTroops.Location = new System.Drawing.Point(4, 25);
            this.tabPageTroops.Name = "tabPageTroops";
            this.tabPageTroops.Size = new System.Drawing.Size(988, 343);
            this.tabPageTroops.TabIndex = 4;
            this.tabPageTroops.Text = "Troops";
            this.tabPageTroops.UseVisualStyleBackColor = true;
            // 
            // tabPageFarms
            // 
            this.tabPageFarms.Location = new System.Drawing.Point(4, 25);
            this.tabPageFarms.Name = "tabPageFarms";
            this.tabPageFarms.Size = new System.Drawing.Size(988, 343);
            this.tabPageFarms.TabIndex = 6;
            this.tabPageFarms.Text = "Farms";
            this.tabPageFarms.UseVisualStyleBackColor = true;
            // 
            // tabPageHero
            // 
            this.tabPageHero.Controls.Add(this.numericUpDownMaxTravelTime);
            this.tabPageHero.Controls.Add(this.lblMaxTravelTime);
            this.tabPageHero.Controls.Add(this.chkBoxPreferHard);
            this.tabPageHero.Controls.Add(this.numericUpDownHard);
            this.tabPageHero.Controls.Add(this.numericUpDownNormal);
            this.tabPageHero.Controls.Add(this.label6);
            this.tabPageHero.Controls.Add(this.groupBoxAdventureMode);
            this.tabPageHero.Controls.Add(this.chkBoxDoAdventures);
            this.tabPageHero.Controls.Add(this.label5);
            this.tabPageHero.Controls.Add(this.label3);
            this.tabPageHero.Location = new System.Drawing.Point(4, 25);
            this.tabPageHero.Name = "tabPageHero";
            this.tabPageHero.Size = new System.Drawing.Size(988, 343);
            this.tabPageHero.TabIndex = 5;
            this.tabPageHero.Text = "Hero";
            this.tabPageHero.UseVisualStyleBackColor = true;
            // 
            // numericUpDownHard
            // 
            this.numericUpDownHard.Location = new System.Drawing.Point(179, 78);
            this.numericUpDownHard.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHard.Name = "numericUpDownHard";
            this.numericUpDownHard.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownHard.TabIndex = 9;
            this.numericUpDownHard.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownHard.ValueChanged += new System.EventHandler(this.numericUpDownHard_ValueChanged);
            // 
            // numericUpDownNormal
            // 
            this.numericUpDownNormal.Location = new System.Drawing.Point(179, 50);
            this.numericUpDownNormal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNormal.Name = "numericUpDownNormal";
            this.numericUpDownNormal.Size = new System.Drawing.Size(49, 22);
            this.numericUpDownNormal.TabIndex = 8;
            this.numericUpDownNormal.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownNormal.ValueChanged += new System.EventHandler(this.numericUpDownNormal_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Hard adventures:";
            // 
            // groupBoxAdventureMode
            // 
            this.groupBoxAdventureMode.Controls.Add(this.rdBtnClosest);
            this.groupBoxAdventureMode.Controls.Add(this.rdBtnRandom);
            this.groupBoxAdventureMode.Controls.Add(this.rdBtnFurthest);
            this.groupBoxAdventureMode.Location = new System.Drawing.Point(28, 210);
            this.groupBoxAdventureMode.Name = "groupBoxAdventureMode";
            this.groupBoxAdventureMode.Size = new System.Drawing.Size(200, 108);
            this.groupBoxAdventureMode.TabIndex = 6;
            this.groupBoxAdventureMode.TabStop = false;
            this.groupBoxAdventureMode.Text = "Adventure mode";
            // 
            // rdBtnClosest
            // 
            this.rdBtnClosest.AutoSize = true;
            this.rdBtnClosest.Checked = true;
            this.rdBtnClosest.Location = new System.Drawing.Point(46, 21);
            this.rdBtnClosest.Name = "rdBtnClosest";
            this.rdBtnClosest.Size = new System.Drawing.Size(75, 21);
            this.rdBtnClosest.TabIndex = 2;
            this.rdBtnClosest.TabStop = true;
            this.rdBtnClosest.Text = "Closest";
            this.rdBtnClosest.UseVisualStyleBackColor = true;
            // 
            // rdBtnRandom
            // 
            this.rdBtnRandom.AutoSize = true;
            this.rdBtnRandom.Location = new System.Drawing.Point(46, 75);
            this.rdBtnRandom.Name = "rdBtnRandom";
            this.rdBtnRandom.Size = new System.Drawing.Size(82, 21);
            this.rdBtnRandom.TabIndex = 5;
            this.rdBtnRandom.Text = "Random";
            this.rdBtnRandom.UseVisualStyleBackColor = true;
            // 
            // rdBtnFurthest
            // 
            this.rdBtnFurthest.AutoSize = true;
            this.rdBtnFurthest.Location = new System.Drawing.Point(46, 48);
            this.rdBtnFurthest.Name = "rdBtnFurthest";
            this.rdBtnFurthest.Size = new System.Drawing.Size(81, 21);
            this.rdBtnFurthest.TabIndex = 4;
            this.rdBtnFurthest.Text = "Furthest";
            this.rdBtnFurthest.UseVisualStyleBackColor = true;
            // 
            // chkBoxDoAdventures
            // 
            this.chkBoxDoAdventures.AutoSize = true;
            this.chkBoxDoAdventures.Location = new System.Drawing.Point(74, 116);
            this.chkBoxDoAdventures.Name = "chkBoxDoAdventures";
            this.chkBoxDoAdventures.Size = new System.Drawing.Size(123, 21);
            this.chkBoxDoAdventures.TabIndex = 3;
            this.chkBoxDoAdventures.Text = "Do adventures";
            this.chkBoxDoAdventures.UseVisualStyleBackColor = true;
            this.chkBoxDoAdventures.CheckedChanged += new System.EventHandler(this.chkBoxDoAdventures_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Normal adventures:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Health settings";
            // 
            // tabPageLog
            // 
            this.tabPageLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(988, 343);
            this.tabPageLog.TabIndex = 3;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71F));
            this.tableLayoutPanel1.Controls.Add(this.rTxtBoxLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbCtrlMain, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 511);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // chkBoxPreferHard
            // 
            this.chkBoxPreferHard.AutoSize = true;
            this.chkBoxPreferHard.Location = new System.Drawing.Point(74, 143);
            this.chkBoxPreferHard.Name = "chkBoxPreferHard";
            this.chkBoxPreferHard.Size = new System.Drawing.Size(102, 21);
            this.chkBoxPreferHard.TabIndex = 10;
            this.chkBoxPreferHard.Text = "Prefer hard";
            this.chkBoxPreferHard.UseVisualStyleBackColor = true;
            this.chkBoxPreferHard.CheckedChanged += new System.EventHandler(this.chkBoxPreferHard_CheckedChanged);
            // 
            // lblMaxTravelTime
            // 
            this.lblMaxTravelTime.AutoSize = true;
            this.lblMaxTravelTime.Location = new System.Drawing.Point(43, 175);
            this.lblMaxTravelTime.Name = "lblMaxTravelTime";
            this.lblMaxTravelTime.Size = new System.Drawing.Size(110, 17);
            this.lblMaxTravelTime.TabIndex = 12;
            this.lblMaxTravelTime.Text = "Max. travel time:";
            // 
            // numericUpDownMaxTravelTime
            // 
            this.numericUpDownMaxTravelTime.Location = new System.Drawing.Point(160, 171);
            this.numericUpDownMaxTravelTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxTravelTime.Name = "numericUpDownMaxTravelTime";
            this.numericUpDownMaxTravelTime.Size = new System.Drawing.Size(37, 22);
            this.numericUpDownMaxTravelTime.TabIndex = 13;
            this.numericUpDownMaxTravelTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxTravelTime.ValueChanged += new System.EventHandler(this.numericUpDownMaxTravelTime_ValueChanged);
            // 
            // TravianBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TravianBot";
            this.Text = "Travian Auto";
            this.tbCtrlMain.ResumeLayout(false);
            this.tabPageAccount.ResumeLayout(false);
            this.tabPageAccount.PerformLayout();
            this.tagPageBuildings.ResumeLayout(false);
            this.tabPageHero.ResumeLayout(false);
            this.tabPageHero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormal)).EndInit();
            this.groupBoxAdventureMode.ResumeLayout(false);
            this.groupBoxAdventureMode.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTravelTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox rTxtBoxLog;
        private System.Windows.Forms.TabControl tbCtrlMain;
        private System.Windows.Forms.TabPage tabPageAccount;
        private System.Windows.Forms.TabPage tagPageBuildings;
        private System.Windows.Forms.TabControl tbCtrlBuildings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPageTroops;
        private System.Windows.Forms.TabPage tabPageFarms;
        private System.Windows.Forms.TabPage tabPageHero;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TextBox txtBoxServer;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdBtnRandom;
        private System.Windows.Forms.RadioButton rdBtnFurthest;
        private System.Windows.Forms.CheckBox chkBoxDoAdventures;
        private System.Windows.Forms.RadioButton rdBtnClosest;
        private System.Windows.Forms.GroupBox groupBoxAdventureMode;
        private System.Windows.Forms.NumericUpDown numericUpDownHard;
        private System.Windows.Forms.NumericUpDown numericUpDownNormal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkBoxPreferHard;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTravelTime;
        private System.Windows.Forms.Label lblMaxTravelTime;
    }
}

