using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gogogo.Entities;
using Gogogo.Instances;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainControl : UserControl
    {
        private const float ITEM_SIZE_SCALE = 0.5f;
        private static readonly Dictionary<CellStatus, Brush> CellBrush =
            new Dictionary<CellStatus, Brush>
            {
                {CellStatus.B, new SolidBrush(Color.Black)},
                {CellStatus.W, new SolidBrush(Color.White)}
            };

        private float _cellWStep;
        private float _cellHStep;
        private float _itemDiameter;

        private readonly Pen _linePen = new Pen(Color.Black, 1);
        private readonly Brush _numBrush = new SolidBrush(Color.Red);
        private readonly Pen _curStepTips = new Pen(Color.Green, 3);

        private const float NUM_W = 20;
        private const float NUM_H = 20;
        private readonly Border _border;

        public ChessMainControl()
        {
            InitializeComponent();
            ReInitCellSize();
            _border = new Border
            {
                ChessChanged = () =>
                {
                    HandleCtrlInOtherThread.HandleCtrlInBackGroundThread(
                        this,
                        Refresh);
                }
            };
        }

        private void ReInitCellSize()
        {
            _cellWStep = ((float)ClientSize.Width - Padding.Left - Padding.Right)
                / (RoomStatic.BorderSize - 1);
            _cellHStep = ((float)ClientSize.Height - Padding.Top - Padding.Bottom)
                / (RoomStatic.BorderSize - 1);
            _itemDiameter = Math.Min(_cellWStep, _cellHStep) * ITEM_SIZE_SCALE;
        }

        #region DrawView

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawLines(e.Graphics);
            DrawNums(e.Graphics);
            DrawCells(e.Graphics);
        }

        private void DrawNums(Graphics g)
        {
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                g.DrawString(
                    ((char)(i + 65)).ToString(),
                    DefaultFont,
                    _numBrush,
                    new RectangleF(
                        i * _cellWStep + Padding.Left - NUM_W / 2,
                        Padding.Top - NUM_H,
                        NUM_W,
                        NUM_H),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    });
            }
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                g.DrawString(
                    (i + 1).ToString(),
                    DefaultFont,
                    _numBrush,
                    new RectangleF(
                        Padding.Left - NUM_W,
                        i * _cellHStep + Padding.Top - NUM_H / 2,
                        NUM_W,
                        NUM_H),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
            }
        }

        private void DrawLines(Graphics g)
        {
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                g.DrawLine(_linePen,
                    i * _cellWStep + Padding.Left,
                    Padding.Top,
                    i * _cellWStep + Padding.Left,
                    ClientSize.Height - Padding.Bottom);
            }
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                g.DrawLine(_linePen,
                    Padding.Left,
                    i * _cellHStep + Padding.Top,
                    ClientSize.Width - Padding.Right,
                    i * _cellHStep + Padding.Top);
            }
        }

        private void DrawCells(Graphics g)
        {
            for (var i = 0; i < RoomStatic.BorderSize; i++)
            {
                for (var j = 0; j < RoomStatic.BorderSize; j++)
                {
                    if (_border.GetCellStatus(i, j) == CellStatus.E)
                    {
                        continue;
                    }

                    g.FillEllipse(CellBrush[_border.GetCellStatus(i, j)],
                        Padding.Left + i * _cellWStep - _itemDiameter / 2,
                        Padding.Top + j * _cellHStep - _itemDiameter / 2,
                        _itemDiameter,
                        _itemDiameter);
                    if (i == RoomStatic.Steps.Peek().Pos.X 
                        && j == RoomStatic.Steps.Peek().Pos.Y)
                    {
                        g.DrawLine(_curStepTips,
                            Padding.Left + i * _cellWStep - -_itemDiameter / 2,
                            Padding.Top + j * _cellHStep,
                            Padding.Left + i * _cellWStep + -_itemDiameter / 2,
                            Padding.Top + j * _cellHStep);
                        g.DrawLine(_curStepTips,
                            Padding.Left + i * _cellWStep,
                            Padding.Top + j * _cellHStep - -_itemDiameter / 2,
                            Padding.Left + i * _cellWStep,
                            Padding.Top + j * _cellHStep + -_itemDiameter / 2);
                    }
                }
            }
        }

        #endregion

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            ReInitCellSize();
            Refresh();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Refresh();
        }

        private void ChessMainControl_MouseClick(object sender, MouseEventArgs e)
        {
            var x = (int)Math.Round((e.X - Padding.Left) / _cellWStep);
            var y = (int)Math.Round((e.Y - Padding.Top) / _cellHStep);
            if (x < 0 || y < 0
                || x > RoomStatic.BorderSize
                || y > RoomStatic.BorderSize
                || _border.GetCellStatus(x, y) != CellStatus.E)
            {
                return;
            }
            //TcpInstance.Instance.Socket.SendMethod.RoomMsg(
            //        RoomMsgInfoId.PutChess,
            //        new PosInfo(x, y, _border.CurStatus));
        }
    }
}
