using System.Windows.Forms;

namespace Gogogo.Statics
{
    public static class Extentions
    {
        public static void ShowForm<T>(this Form form) where T : Form, new()
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                Program.MainForm,
                () =>
                {
                    if (form != Program.MainForm)
                    {
                        form.Dispose();
                    }
                    using (var f = new T())
                    {
                        f.ShowDialog(Program.MainForm);
                    }
                });

        }
    }
}
