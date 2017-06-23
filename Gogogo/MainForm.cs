using System;
using System.Drawing;
using System.Windows.Forms;
using Gogogo.Forms;
using Gogogo.Forms.RoomForms;
using Gogogo.Helper;
using TcpConnect.ServerInterface;

namespace Gogogo
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            TcpInstance.SOCKET.MsgActions.Loginc += msg =>
            {
                HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                    this,
                    CreateRoomc,
                    msg);
            };
        }

        private void CreateRoomc(ServerMsgBase obj)
        {
            
        }


        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();//绘制背景 
            Brush myBrush = Brushes.Black;

            switch (e.Index)
            {
                case 0:
                    myBrush = Brushes.Red;
                    break;
                case 1:
                    myBrush = Brushes.Orange;
                    break;
                case 2:
                    myBrush = Brushes.Purple;
                    break;
            }
            e.DrawFocusRectangle();//焦点框 

            //文本 
            e.Graphics.DrawString(
                listBox.Items[e.Index].ToString(),
                e.Font,
                myBrush,
                e.Bounds,
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

        }

        private void makeRoomButton_Click(object sender, EventArgs e)
        {
            using (var createRoomForm = new CreateRoomForm())
            {
                if (createRoomForm.ShowDialog() == DialogResult.OK)
                {
                    TcpInstance.SOCKET.SendMethod.CreateRoom(
                        createRoomForm.nameTextBox.Text, 
                        createRoomForm.passwordTextBox.Text);
                }
            }
        }
    }
}
