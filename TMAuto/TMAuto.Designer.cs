namespace TWAuto
{
    partial class TMAuto
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
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbCtrlMain.SuspendLayout();
            this.tabPageAccount.SuspendLayout();
            this.tagPageBuildings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tbCtrlMain.Controls.Add(this.tabPageAccount);
            this.tbCtrlMain.Controls.Add(this.tagPageBuildings);
            this.tbCtrlMain.Controls.Add(this.tabPageTroops);
            this.tbCtrlMain.Controls.Add(this.tabPageFarms);
            this.tbCtrlMain.Controls.Add(this.tabPageHero);
            this.tbCtrlMain.Controls.Add(this.tabPageLog);
            this.tbCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.tabPageAccount.Size = new System.Drawing.Size(988, 345);
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
            this.tabPageHero.Location = new System.Drawing.Point(4, 25);
            this.tabPageHero.Name = "tabPageHero";
            this.tabPageHero.Size = new System.Drawing.Size(988, 343);
            this.tabPageHero.TabIndex = 5;
            this.tabPageHero.Text = "Hero";
            this.tabPageHero.UseVisualStyleBackColor = true;
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
            // TMAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TMAuto";
            this.Text = "Travian Auto";
            this.tbCtrlMain.ResumeLayout(false);
            this.tabPageAccount.ResumeLayout(false);
            this.tabPageAccount.PerformLayout();
            this.tagPageBuildings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
    }
}

