using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Gogogo.Forms
{
    public partial class BaseForm : Form
    {
        [Browsable(false)]
        public override Color BackColor
        {
            get { return Color.LightBlue; }
            // ReSharper disable once ValueParameterNotUsed
            set { return; }
        }

        [Browsable(false)]
        public new FormBorderStyle FormBorderStyle
        {
            // ReSharper disable once ValueParameterNotUsed
            set { return;}
        }

        public bool Sizable
        {
            set { base.FormBorderStyle = value ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle; }
            get { return base.FormBorderStyle == FormBorderStyle.Sizable; }
        }

        public BaseForm()
        {
            InitializeComponent();
            Sizable = false;
        }

        public bool TextBoxNotValid(TextBox textbox, Control label, int maxCount, bool canNotEmpty = true)
        {
            if (string.IsNullOrEmpty(textbox.Text) && canNotEmpty)
            {
                MessageBox.Show(label.Text.TrimEnd(':') + @"不能为空");
                return true;
            }
            if (maxCount != 0 && textbox.Text.Length > maxCount)
            {
                MessageBox.Show(label.Text.TrimEnd(':') + $@"不能超过{maxCount}个字符");
                return true;
            }
            return false;
        }
    }
}
