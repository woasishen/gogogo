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
            this.makeRoomButton = new System.Windows.Forms.Button();
            this.topTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.splitLinePanel = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.roomInfoPanel = new System.Windows.Forms.Panel();
            this.topTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // makeRoomButton
            // 
            this.makeRoomButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.makeRoomButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.makeRoomButton.Location = new System.Drawing.Point(194, 3);
            this.makeRoomButton.Name = "makeRoomButton";
            this.makeRoomButton.Size = new System.Drawing.Size(121, 36);
            this.makeRoomButton.TabIndex = 0;
            this.makeRoomButton.Text = "创建房间";
            this.makeRoomButton.UseVisualStyleBackColor = true;
            this.makeRoomButton.Click += new System.EventHandler(this.makeRoomButton_Click);
            // 
            // topTableLayoutPanel
            // 
            this.topTableLayoutPanel.ColumnCount = 3;
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topTableLayoutPanel.Controls.Add(this.makeRoomButton, 1, 0);
            this.topTableLayoutPanel.Controls.Add(this.splitLinePanel, 0, 1);
            this.topTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topTableLayoutPanel.Name = "topTableLayoutPanel";
            this.topTableLayoutPanel.RowCount = 2;
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topTableLayoutPanel.Size = new System.Drawing.Size(512, 62);
            this.topTableLayoutPanel.TabIndex = 1;
            // 
            // splitLinePanel
            // 
            this.splitLinePanel.BackColor = System.Drawing.Color.Pink;
            this.topTableLayoutPanel.SetColumnSpan(this.splitLinePanel, 3);
            this.splitLinePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitLinePanel.Location = new System.Drawing.Point(3, 45);
            this.splitLinePanel.Name = "splitLinePanel";
            this.splitLinePanel.Size = new System.Drawing.Size(506, 3);
            this.splitLinePanel.TabIndex = 1;
            // 
            // listBox
            // 
            this.listBox.AllowDrop = true;
            this.listBox.BackColor = System.Drawing.Color.LightBlue;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox.HorizontalExtent = 20;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 40;
            this.listBox.Location = new System.Drawing.Point(0, 62);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(255, 327);
            this.listBox.TabIndex = 3;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // roomInfoPanel
            // 
            this.roomInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomInfoPanel.Location = new System.Drawing.Point(255, 62);
            this.roomInfoPanel.Name = "roomInfoPanel";
            this.roomInfoPanel.Size = new System.Drawing.Size(257, 327);
            this.roomInfoPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(512, 389);
            this.Controls.Add(this.roomInfoPanel);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.topTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(375, 226);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.topTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button makeRoomButton;
        private System.Windows.Forms.TableLayoutPanel topTableLayoutPanel;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel roomInfoPanel;
        private System.Windows.Forms.Panel splitLinePanel;
    }
}