using System;
using System.Windows.Forms;
using TcpConnect.ServerInterface;

namespace Gogogo.Helper
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

        public static void HandleCtrlInBackGroundThread(
            Control ctrl,
            Action<ServerMsgBase> call,
            ServerMsgBase arg)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action<ServerMsgBase>(call), new object[] { arg });
            }
            else
            {
                call(arg);
            }
        }
    }
}

