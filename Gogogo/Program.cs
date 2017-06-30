using System;
using System.Windows.Forms;
using Gogogo.Instances;

namespace Gogogo
{
    static class Program
    {
        public static Form MainForm;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TcpInstance.Instance.Init();
            MainForm = new MainForm();
            Application.Run(MainForm);
        }
    }
}
