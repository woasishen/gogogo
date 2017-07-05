using System;
using System.Windows.Forms;

namespace Gogogo.Statics
{
    public static class HandleCtrlInOtherThread
    {
        public static void HandleCtrlInBackGroundThread(
            Control ctrl,
            Action call)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(call, null);
            }
            else
            {
                call();
            }
        }

        public static void HandleCtrlInBackGroundThread<T>(
            Control ctrl,
            Action<T> call,
            T arg)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke(call, arg);
            }
            else
            {
                call(arg);
            }
        }
    }
}

