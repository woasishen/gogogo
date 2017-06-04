﻿namespace TestWzq
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
            this.restarBtn = new System.Windows.Forms.Button();
            this.redo = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.mainControl = new TestWzq.MainControl();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // restarBtn
            // 
            this.restarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.restarBtn.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.restarBtn.Location = new System.Drawing.Point(399, 23);
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
            this.redo.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.redo.Location = new System.Drawing.Point(136, 23);
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
            this.bottomPanel.Controls.Add(this.redo);
            this.bottomPanel.Controls.Add(this.restarBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 572);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(710, 118);
            this.bottomPanel.TabIndex = 8;
            // 
            // mainControl
            // 
            this.mainControl.AutoCompute = true;
            this.mainControl.BackColor = System.Drawing.Color.Transparent;
            this.mainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.Name = "mainControl";
            this.mainControl.Padding = new System.Windows.Forms.Padding(30);
            this.mainControl.Size = new System.Drawing.Size(710, 572);
            this.mainControl.StepStatusChanged = null;
            this.mainControl.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(710, 690);
            this.Controls.Add(this.mainControl);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button restarBtn;
        private System.Windows.Forms.Button redo;
        private System.Windows.Forms.Panel bottomPanel;
        private TestWzq.MainControl mainControl;
    }
}