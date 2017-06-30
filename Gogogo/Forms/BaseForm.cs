using System.Drawing;
using System.Windows.Forms;

namespace Gogogo.Forms
{
    public partial class BaseForm : Form
    {
        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public BaseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackColor = Color.LightBlue;
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
