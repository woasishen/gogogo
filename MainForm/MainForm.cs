using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestWzq
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void restarBtn_Click(object sender, EventArgs e)
        {
            mainControl.RestartGame();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            mainControl.Redo();
        }
    }
}
