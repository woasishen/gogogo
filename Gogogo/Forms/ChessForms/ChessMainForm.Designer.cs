﻿namespace Gogogo.Forms.ChessForms
{
    partial class ChessMainForm
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
            this.restarBtn = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.autoCheckBox = new System.Windows.Forms.CheckBox();
            this.blackRadioButton = new System.Windows.Forms.RadioButton();
            this.whiteRadioButton = new System.Windows.Forms.RadioButton();
            this._chessMainControl = new Gogogo.Forms.ChessForms.ChessMainControl();
            this.topPanel = new System.Windows.Forms.Panel();
            this.userLabel = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // restarBtn
            // 
            this.restarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.restarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restarBtn.Location = new System.Drawing.Point(201, 6);
            this.restarBtn.Name = "restarBtn";
            this.restarBtn.Size = new System.Drawing.Size(144, 60);
            this.restarBtn.TabIndex = 4;
            this.restarBtn.Text = "重新开始";
            this.restarBtn.UseVisualStyleBackColor = true;
            this.restarBtn.Click += new System.EventHandler(this.restarBtn_Click);
            // 
            // redo
            // 
            this.redo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.redo.Location = new System.Drawing.Point(27, 6);
            this.redo.Name = "redo";
            this.redo.Size = new System.Drawing.Size(144, 60);
            this.redo.TabIndex = 5;
            this.redo.Text = "撤销";
            this.redo.UseVisualStyleBackColor = true;
            this.redo.Click += new System.EventHandler(this.redo_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.autoCheckBox);
            this.bottomPanel.Controls.Add(this.blackRadioButton);
            this.bottomPanel.Controls.Add(this.whiteRadioButton);
            this.bottomPanel.Controls.Add(this.redo);
            this.bottomPanel.Controls.Add(this.restarBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 611);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(710, 79);
            this.bottomPanel.TabIndex = 8;
            // 
            // autoCheckBox
            // 
            this.autoCheckBox.AutoSize = true;
            this.autoCheckBox.Checked = true;
            this.autoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCheckBox.Location = new System.Drawing.Point(550, 20);
            this.autoCheckBox.Name = "autoCheckBox";
            this.autoCheckBox.Size = new System.Drawing.Size(96, 16);
            this.autoCheckBox.TabIndex = 8;
            this.autoCheckBox.Text = "自动切换棋子";
            this.autoCheckBox.UseVisualStyleBackColor = true;
            // 
            // blackRadioButton
            // 
            this.blackRadioButton.AutoSize = true;
            this.blackRadioButton.Location = new System.Drawing.Point(421, 19);
            this.blackRadioButton.Name = "blackRadioButton";
            this.blackRadioButton.Size = new System.Drawing.Size(35, 16);
            this.blackRadioButton.TabIndex = 7;
            this.blackRadioButton.Text = "黑";
            this.blackRadioButton.UseVisualStyleBackColor = true;
            // 
            // whiteRadioButton
            // 
            this.whiteRadioButton.AutoSize = true;
            this.whiteRadioButton.Checked = true;
            this.whiteRadioButton.Location = new System.Drawing.Point(421, 50);
            this.whiteRadioButton.Name = "whiteRadioButton";
            this.whiteRadioButton.Size = new System.Drawing.Size(35, 16);
            this.whiteRadioButton.TabIndex = 6;
            this.whiteRadioButton.TabStop = true;
            this.whiteRadioButton.Text = "白";
            this.whiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // _chessMainControl
            // 
            this._chessMainControl.BackColor = System.Drawing.Color.Transparent;
            this._chessMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chessMainControl.Location = new System.Drawing.Point(0, 30);
            this._chessMainControl.Name = "_chessMainControl";
            this._chessMainControl.Padding = new System.Windows.Forms.Padding(30);
            this._chessMainControl.Size = new System.Drawing.Size(710, 581);
            this._chessMainControl.TabIndex = 9;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.userLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(710, 30);
            this.topPanel.TabIndex = 10;
            // 
            // userLabel
            // 
            this.userLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userLabel.Location = new System.Drawing.Point(0, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(710, 30);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "***";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChessMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(710, 690);
            this.Controls.Add(this._chessMainControl);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.Name = "ChessMainForm";
            this.Text = "ChessMainForm";
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button restarBtn;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Panel bottomPanel;
        private ChessMainControl _chessMainControl;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.CheckBox autoCheckBox;
        private System.Windows.Forms.RadioButton blackRadioButton;
        private System.Windows.Forms.RadioButton whiteRadioButton;
    }
}