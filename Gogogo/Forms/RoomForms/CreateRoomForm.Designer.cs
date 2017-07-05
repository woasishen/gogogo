namespace Gogogo.Forms.RoomForms
{
    partial class CreateRoomForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.createRoomButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(135, 71);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(182, 21);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(135, 123);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(182, 21);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            // 
            // createRoomButton
            // 
            this.createRoomButton.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.createRoomButton.Location = new System.Drawing.Point(116, 173);
            this.createRoomButton.Name = "createRoomButton";
            this.createRoomButton.Size = new System.Drawing.Size(121, 49);
            this.createRoomButton.TabIndex = 2;
            this.createRoomButton.Text = "创建房间";
            this.createRoomButton.UseVisualStyleBackColor = true;
            this.createRoomButton.Click += new System.EventHandler(this.createRoomButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(48, 74);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 12);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "房间名称:";
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Location = new System.Drawing.Point(33, 125);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(78, 16);
            this.passwordCheckBox.TabIndex = 4;
            this.passwordCheckBox.Text = "房间密码:";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.passwordCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "棋盘大小：";
            // 
            // comboBox
            // 
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "9",
            "13",
            "19"});
            this.sizeComboBox.Location = new System.Drawing.Point(152, 25);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(70, 20);
            this.sizeComboBox.TabIndex = 6;
            // 
            // CreateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(349, 243);
            this.Controls.Add(this.sizeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordCheckBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.createRoomButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "CreateRoomForm";
            this.Text = "CreateRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createRoomButton;
        private System.Windows.Forms.Label nameLabel;
        public System.Windows.Forms.CheckBox passwordCheckBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sizeComboBox;
    }
}