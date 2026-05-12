namespace PharmacyWinForms
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.Dashoard_btn = new Guna.UI2.WinForms.Guna2Button();
            this.title_barPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.Minimize_btn = new Guna.UI2.WinForms.Guna2Button();
            this.btnColes = new Guna.UI2.WinForms.Guna2Button();
            this.dashboard_title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbldate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.userIcon = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Medicine_btn = new Guna.UI2.WinForms.Guna2Button();
            this.SellMedicicne_btn = new Guna.UI2.WinForms.Guna2Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ElpiseProfileInfo = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.userProfileControl1 = new PharmacyWinForms.userProfileControl();
            this.title_barPanel.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dashoard_btn
            // 
            this.Dashoard_btn.BorderRadius = 10;
            this.Dashoard_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Dashoard_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Dashoard_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Dashoard_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Dashoard_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(224)))), ((int)(((byte)(217)))));
            this.Dashoard_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Dashoard_btn.Font = new System.Drawing.Font("Alexandria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashoard_btn.ForeColor = System.Drawing.Color.Black;
            this.Dashoard_btn.Location = new System.Drawing.Point(14, 10);
            this.Dashoard_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Dashoard_btn.Name = "Dashoard_btn";
            this.Dashoard_btn.Size = new System.Drawing.Size(145, 33);
            this.Dashoard_btn.TabIndex = 0;
            this.Dashoard_btn.Text = "DASHBOARD";
            // 
            // title_barPanel
            // 
            this.title_barPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.title_barPanel.Controls.Add(this.Minimize_btn);
            this.title_barPanel.Controls.Add(this.btnColes);
            this.title_barPanel.Controls.Add(this.dashboard_title);
            this.title_barPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.title_barPanel.Location = new System.Drawing.Point(0, 0);
            this.title_barPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.title_barPanel.Name = "title_barPanel";
            this.title_barPanel.Size = new System.Drawing.Size(1360, 48);
            this.title_barPanel.TabIndex = 1;
            // 
            // Minimize_btn
            // 
            this.Minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.Minimize_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Minimize_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Minimize_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Minimize_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Minimize_btn.FillColor = System.Drawing.Color.Transparent;
            this.Minimize_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Minimize_btn.ForeColor = System.Drawing.Color.White;
            this.Minimize_btn.Image = ((System.Drawing.Image)(resources.GetObject("Minimize_btn.Image")));
            this.Minimize_btn.Location = new System.Drawing.Point(1248, 0);
            this.Minimize_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Minimize_btn.Name = "Minimize_btn";
            this.Minimize_btn.Size = new System.Drawing.Size(52, 48);
            this.Minimize_btn.TabIndex = 3;
            this.Minimize_btn.Click += new System.EventHandler(this.Minimize_btn_Click);
            // 
            // btnColes
            // 
            this.btnColes.BackColor = System.Drawing.Color.Transparent;
            this.btnColes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnColes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnColes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnColes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnColes.FillColor = System.Drawing.Color.Transparent;
            this.btnColes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnColes.ForeColor = System.Drawing.Color.White;
            this.btnColes.Image = ((System.Drawing.Image)(resources.GetObject("btnColes.Image")));
            this.btnColes.Location = new System.Drawing.Point(1308, 0);
            this.btnColes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnColes.Name = "btnColes";
            this.btnColes.Size = new System.Drawing.Size(52, 48);
            this.btnColes.TabIndex = 2;
            this.btnColes.Click += new System.EventHandler(this.btnColes_Click);
            // 
            // dashboard_title
            // 
            this.dashboard_title.BackColor = System.Drawing.Color.Transparent;
            this.dashboard_title.Font = new System.Drawing.Font("Alexandria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dashboard_title.Location = new System.Drawing.Point(9, 12);
            this.dashboard_title.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dashboard_title.Name = "dashboard_title";
            this.dashboard_title.Size = new System.Drawing.Size(307, 24);
            this.dashboard_title.TabIndex = 0;
            this.dashboard_title.Text = "Pharmacy Management System---Dashboard";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.guna2Panel1);
            this.guna2Panel2.Controls.Add(this.lbldate);
            this.guna2Panel2.Controls.Add(this.userIcon);
            this.guna2Panel2.Controls.Add(this.lblTime);
            this.guna2Panel2.Controls.Add(this.Medicine_btn);
            this.guna2Panel2.Controls.Add(this.SellMedicicne_btn);
            this.guna2Panel2.Controls.Add(this.Dashoard_btn);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 48);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1360, 61);
            this.guna2Panel2.TabIndex = 2;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.FillColor = System.Drawing.Color.Black;
            this.guna2Panel3.Location = new System.Drawing.Point(162, 10);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1, 33);
            this.guna2Panel3.TabIndex = 7;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.FillColor = System.Drawing.Color.Black;
            this.guna2Panel1.Location = new System.Drawing.Point(326, 10);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1, 33);
            this.guna2Panel1.TabIndex = 6;
            // 
            // lbldate
            // 
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.Font = new System.Drawing.Font("Alexandria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(1235, 34);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(34, 24);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "date";
            // 
            // userIcon
            // 
            this.userIcon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.userIcon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.userIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.userIcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.userIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(224)))), ((int)(((byte)(217)))));
            this.userIcon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.userIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.userIcon.ForeColor = System.Drawing.Color.White;
            this.userIcon.Image = ((System.Drawing.Image)(resources.GetObject("userIcon.Image")));
            this.userIcon.ImageSize = new System.Drawing.Size(30, 30);
            this.userIcon.Location = new System.Drawing.Point(1296, 6);
            this.userIcon.Name = "userIcon";
            this.userIcon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.userIcon.Size = new System.Drawing.Size(52, 52);
            this.userIcon.TabIndex = 3;
            this.userIcon.Click += new System.EventHandler(this.userIcon_Click);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Alexandria", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1235, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 24);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "time";
            // 
            // Medicine_btn
            // 
            this.Medicine_btn.BorderRadius = 10;
            this.Medicine_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Medicine_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Medicine_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Medicine_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Medicine_btn.FillColor = System.Drawing.Color.Transparent;
            this.Medicine_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Medicine_btn.Font = new System.Drawing.Font("Alexandria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Medicine_btn.ForeColor = System.Drawing.Color.Black;
            this.Medicine_btn.Location = new System.Drawing.Point(329, 10);
            this.Medicine_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Medicine_btn.Name = "Medicine_btn";
            this.Medicine_btn.Size = new System.Drawing.Size(135, 33);
            this.Medicine_btn.TabIndex = 3;
            this.Medicine_btn.Text = "MEDICINE";
            // 
            // SellMedicicne_btn
            // 
            this.SellMedicicne_btn.BorderRadius = 10;
            this.SellMedicicne_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SellMedicicne_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SellMedicicne_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SellMedicicne_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SellMedicicne_btn.FillColor = System.Drawing.Color.Transparent;
            this.SellMedicicne_btn.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.SellMedicicne_btn.Font = new System.Drawing.Font("Alexandria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellMedicicne_btn.ForeColor = System.Drawing.Color.Black;
            this.SellMedicicne_btn.Location = new System.Drawing.Point(164, 10);
            this.SellMedicicne_btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SellMedicicne_btn.Name = "SellMedicicne_btn";
            this.SellMedicicne_btn.Size = new System.Drawing.Size(160, 33);
            this.SellMedicicne_btn.TabIndex = 3;
            this.SellMedicicne_btn.Text = "SELL MEDICINE";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            // 
            // ElpiseProfileInfo
            // 
            this.ElpiseProfileInfo.TargetControl = this.userIcon;
            // 
            // userProfileControl1
            // 
            this.userProfileControl1.BackColor = System.Drawing.Color.Transparent;
            this.userProfileControl1.Location = new System.Drawing.Point(1078, 113);
            this.userProfileControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userProfileControl1.Name = "userProfileControl1";
            this.userProfileControl1.Size = new System.Drawing.Size(282, 280);
            this.userProfileControl1.TabIndex = 3;
            this.userProfileControl1.Visible = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1360, 1056);
            this.Controls.Add(this.userProfileControl1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.title_barPanel);
            this.Font = new System.Drawing.Font("Alexandria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.title_barPanel.ResumeLayout(false);
            this.title_barPanel.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button Dashoard_btn;
        private Guna.UI2.WinForms.Guna2Panel title_barPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel dashboard_title;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button Medicine_btn;
        private Guna.UI2.WinForms.Guna2Button SellMedicicne_btn;
        private Guna.UI2.WinForms.Guna2Button btnColes;
        private Guna.UI2.WinForms.Guna2Button Minimize_btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTime;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2CircleButton userIcon;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbldate;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Elipse ElpiseProfileInfo;
        private userProfileControl userProfileControl1;
    }
}

