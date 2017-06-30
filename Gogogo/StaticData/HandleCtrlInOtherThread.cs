using System;
using System.Windows.Forms;

namespace Gogogo.StaticData
{
    public static class HandleCtrlInOtherThread
    {
        public static void HandleCtrlInBackGroundThread(
            Control ctrl,
            Action call)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(call), new object[] { });
            }
            else
            {
                call.Invoke();
            }
        }

        public static void HandleCtrlInBackGroundThread<T>(
            Control ctrl,
            Action<T> call,
            T arg)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action<T>(call), new object[] { arg });
            }
            else
            {
                call(arg);
            }
        }
    }
}

