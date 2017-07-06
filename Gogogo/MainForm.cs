using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gogogo.Forms;
using Gogogo.Forms.ChessForms;
using Gogogo.Forms.LoginForms;
using Gogogo.Forms.RoomForms;
using Gogogo.Instances;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo
{
    public partial class MainForm : BaseForm
    {
        private class RoomItem
        {
            public RoomItem(string roomName, RoomInfo roomInfo)
            {
                RoomName = roomName;
                Password = roomInfo.Password;
                PlayerCount = roomInfo.PlayerCount;
            }


            public string RoomName { get; }
            public string Password { get; }
            private int PlayerCount { get; }
            public override string ToString()
            {
                return $"{RoomName}({PlayerCount}人)";
            }
        }

        public MainForm()
        {
            InitializeComponent();

            LogInstance.Instance.AllMsgAction += msg =>
            {
                HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                    this,
                    logMsg =>
                    {
                        logListBox.Items.Add(logMsg);
                        logListBox.SelectedIndex = logListBox.Items.Count - 1;
                    },
                    msg);
            };

            TcpInstance.Instance.Socket.MsgActions.Loginc += RefreshUser;
            TcpInstance.Instance.Socket.MsgActions.Registc += RefreshUser;
            TcpInstance.Instance.Socket.MsgActions.Logoutc += RefreshUser;

            TcpInstance.Instance.Socket.MsgActions.JoinRoomc += JoinRoomc;

            TcpInstance.Instance.Socket.MsgActions.GetRoomsc += RefreshRooms;
            TcpInstance.Instance.Socket.MsgActions.B_Join += RefreshRooms;
            TcpInstance.Instance.Socket.MsgActions.B_Leave += RefreshRooms;

            TcpInstance.Instance.Socket.SendMethod.GetRooms();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.AccountId) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                TcpInstance.Instance.Socket.SendMethod.Login(
                    Properties.Settings.Default.AccountId,
                    Properties.Settings.Default.Password);
            }
        }

        private void JoinRoomc(object msg)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    using (var chessForm = new ChessMainForm())
                    {
                        chessForm.ShowDialog();
                    }
                    RefreshUser(null);
                    TcpInstance.Instance.Socket.SendMethod.LeaveRoom();
                });
        }

        private void RefreshUser(object msg)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    if (string.IsNullOrEmpty(GlobalStatic.CurUser))
                    {
                        welcomPanel.Hide();
                    }
                    else
                    {
                        userNameLabel.Text = GlobalStatic.CurUser;
                        welcomPanel.Show();
                    }
                });
        }

        private void RefreshRooms(object msg)
        {
            HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                this,
                () =>
                {
                    listBox.Items.Clear();
                    noRoomLabel.Visible = !RoomStatic.RoomsDict.Any();

                    listBox.Items.AddRange(RoomStatic.RoomsDict.Select(
                        s => new RoomItem(s.Key, s.Value)).Cast<object>().ToArray());
                });
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();//绘制背景 
            var pwd = ((RoomItem)listBox.Items[e.Index]).Password;
            var myBrush = string.IsNullOrEmpty(pwd) ? Brushes.Black : Brushes.Green;

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

        private void logListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();//绘制背景 
            Brush myBrush;
            if (logListBox.Items[e.Index].ToString().StartsWith(LogInstance.ERR_START))
            {
                myBrush = Brushes.Red;
            }
            else if (logListBox.Items[e.Index].ToString().StartsWith(LogInstance.WARN_START))
            {
                myBrush = Brushes.Purple;
            }
            else
            {
                myBrush = Brushes.Green;
            }
            
            e.DrawFocusRectangle();//焦点框 

            //文本 
            e.Graphics.DrawString(
                logListBox.Items[e.Index].ToString(),
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
            this.ShowForm<CreateRoomForm>();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.ShowForm<LoginForm>();
        }

        private void registLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ShowForm<RegistForm>();
        }

        private void logoutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TcpInstance.Instance.Socket.SendMethod.Logout();
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                return;
            }
            var roomItem = (RoomItem) listBox.SelectedItem;
            TcpInstance.Instance.Socket.SendMethod.JoinRoom(roomItem.RoomName);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}
