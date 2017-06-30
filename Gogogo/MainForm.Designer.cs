namespace Gogogo
{
    partial class MainForm
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
            this.roomInfoPanel = new System.Windows.Forms.Panel();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.makeRoomButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.welcomPanel = new System.Windows.Forms.Panel();
            this.welcomLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.logoutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.registLinkLabel = new System.Windows.Forms.LinkLabel();
            this.loginButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.noRoomLabel = new System.Windows.Forms.Label();
            this.joinButton = new System.Windows.Forms.Button();
            this.roomInfoPanel.SuspendLayout();
            this.topTableLayoutPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.welcomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomInfoPanel
            // 
            this.roomInfoPanel.Controls.Add(this.joinButton);
            this.roomInfoPanel.Controls.Add(this.logListBox);
            this.roomInfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.roomInfoPanel.Location = new System.Drawing.Point(258, 71);
            this.roomInfoPanel.Name = "roomInfoPanel";
            this.roomInfoPanel.Size = new System.Drawing.Size(254, 318);
            this.roomInfoPanel.TabIndex = 4;
            // 
            // logListBox
            // 
            this.logListBox.BackColor = System.Drawing.SystemColors.Info;
            this.logListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.logListBox.FormattingEnabled = true;
            this.logListBox.ItemHeight = 30;
            this.logListBox.Location = new System.Drawing.Point(0, 198);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(254, 120);
            this.logListBox.TabIndex = 0;
            this.logListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.logListBox_DrawItem);
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.BackColor = System.Drawing.Color.LightBlue;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox.HorizontalExtent = 20;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 40;
            this.listBox.Location = new System.Drawing.Point(0, 71);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(252, 320);
            this.listBox.TabIndex = 3;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.ColumnCount = 2;
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.Controls.Add(this.makeRoomButton, 0, 0);
            this.topTableLayoutPanel.Controls.Add(this.panel, 1, 0);
            this.topTableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 2;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.Size = new System.Drawing.Size(512, 71);
            this.topTableLayoutPanel.TabIndex = 1;
            // 
            // makeRoomButton
            // 
            this.makeRoomButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.makeRoomButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.makeRoomButton.Location = new System.Drawing.Point(67, 12);
            this.makeRoomButton.Name = "makeRoomButton";
            this.makeRoomButton.Size = new System.Drawing.Size(121, 36);
            this.makeRoomButton.TabIndex = 0;
            this.makeRoomButton.Text = "创建房间";
            this.makeRoomButton.UseVisualStyleBackColor = true;
            this.makeRoomButton.Click += new System.EventHandler(this.makeRoomButton_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.welcomPanel);
            this.panel.Controls.Add(this.registLinkLabel);
            this.panel.Controls.Add(this.loginButton);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(259, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 45);
            this.panel.TabIndex = 2;
            // 
            // welcomPanel
            // 
            this.welcomPanel.Controls.Add(this.welcomLabel);
            this.welcomPanel.Controls.Add(this.userNameLabel);
            this.welcomPanel.Controls.Add(this.logoutLinkLabel);
            this.welcomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomPanel.Location = new System.Drawing.Point(0, 0);
            this.welcomPanel.Name = "welcomPanel";
            this.welcomPanel.Size = new System.Drawing.Size(250, 45);
            this.welcomPanel.TabIndex = 7;
            this.welcomPanel.Visible = false;
            // 
            // welcomLabel
            // 
            this.welcomLabel.AutoSize = true;
            this.welcomLabel.Location = new System.Drawing.Point(74, 21);
            this.welcomLabel.Name = "welcomLabel";
            this.welcomLabel.Size = new System.Drawing.Size(41, 12);
            this.welcomLabel.TabIndex = 8;
            this.welcomLabel.Text = "欢迎：";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(119, 21);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(23, 12);
            this.userNameLabel.TabIndex = 7;
            this.userNameLabel.Text = "xxx";
            // 
            // logoutLinkLabel
            // 
            this.logoutLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutLinkLabel.AutoSize = true;
            this.logoutLinkLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logoutLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.logoutLinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.logoutLinkLabel.Location = new System.Drawing.Point(207, 21);
            this.logoutLinkLabel.Name = "logoutLinkLabel";
            this.logoutLinkLabel.Size = new System.Drawing.Size(29, 12);
            this.logoutLinkLabel.TabIndex = 6;
            this.logoutLinkLabel.TabStop = true;
            this.logoutLinkLabel.Text = "注销";
            this.logoutLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.logoutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLinkLabel_LinkClicked);
            // 
            // registLinkLabel
            // 
            this.registLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registLinkLabel.AutoSize = true;
            this.registLinkLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.registLinkLabel.LinkColor = System.Drawing.Color.Blue;
            this.registLinkLabel.Location = new System.Drawing.Point(207, 21);
            this.registLinkLabel.Name = "registLinkLabel";
            this.registLinkLabel.Size = new System.Drawing.Size(40, 16);
            this.registLinkLabel.TabIndex = 6;
            this.registLinkLabel.TabStop = true;
            this.registLinkLabel.Text = "注册";
            this.registLinkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.registLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registLinkLabel_LinkClicked);
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Location = new System.Drawing.Point(121, 13);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(80, 29);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.topTableLayoutPanel.SetColumnSpan(this.panel1, 2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 4);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Location = new System.Drawing.Point(255, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 322);
            this.panel2.TabIndex = 5;
            // 
            // noRoomLabel
            // 
            this.noRoomLabel.AutoSize = true;
            this.noRoomLabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.noRoomLabel.ForeColor = System.Drawing.Color.Tomato;
            this.noRoomLabel.Location = new System.Drawing.Point(51, 203);
            this.noRoomLabel.Name = "noRoomLabel";
            this.noRoomLabel.Size = new System.Drawing.Size(169, 20);
            this.noRoomLabel.TabIndex = 6;
            this.noRoomLabel.Text = "当前没有任何房间";
            // 
            // joinButton
            // 
            this.joinButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.joinButton.Location = new System.Drawing.Point(87, 65);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(92, 47);
            this.joinButton.TabIndex = 1;
            this.joinButton.Text = "加入";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(512, 389);
            this.Controls.Add(this.noRoomLabel);
            this.Controls.Add(this.roomInfoPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.topTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(375, 226);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.roomInfoPanel.ResumeLayout(false);
            this.topTableLayoutPanel.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.welcomPanel.ResumeLayout(false);
            this.welcomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button makeRoomButton;
        private System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel roomInfoPanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.LinkLabel registLinkLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel welcomPanel;
        private System.Windows.Forms.LinkLabel logoutLinkLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label welcomLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label noRoomLabel;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Button joinButton;
    }
}