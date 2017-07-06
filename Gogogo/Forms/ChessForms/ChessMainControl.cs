using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Gogogo.Entities;
using Gogogo.Statics;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainControl : UserControl
    {
        private const float ITEM_SIZE_SCALE = 0.7f;
        private const float NUM_W = 30;
        private const float NUM_H = 30;
        private static readonly Dictionary<CellStatus, Brush> CellBrush =
            new Dictionary<CellStatus, Brush>
            {
                {CellStatus.Black, new SolidBrush(Color.Black)},
                {CellStatus.White, new SolidBrush(Color.White)}
            };

        private readonly Pen _linePen = new Pen(Color.Black, 1); 
        private readonly Brush _numBrush = new SolidBrush(Color.Red);
        private readonly Brush _stepTips = new SolidBrush(Color.Chocolate);

        private readonly Border _border;

        private float _cellWStep;
        private float _cellHStep;
        private float _itemDiameter;

        public Action<int, int> OnChessboardClick;

        public Border Border => _border;

        public ChessMainControl()
        {
            _border = new Border(RoomStatic.BorderSize, RoomStatic.Steps);
            ReInitCellSize();
            SizeChanged += (sender, args) => ReInitCellSize();
            InitializeComponent();
        }
        private void ReInitCellSize()
        {
            _cellWStep = ((float)ClientSize.Width - Padding.Left - Padding.Right)
                / (_border.Size - 1);
            _cellHStep = ((float)ClientSize.Height - Padding.Top - Padding.Bottom)
                / (_border.Size - 1);
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
            for (var i = 0; i < _border.Size; i++)
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
                        LineAlignment = StringAlignment.Center
                    });
            }
            for (var i = 0; i < _border.Size; i++)
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
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
            }
        }

        private void DrawLines(Graphics g)
        {
            for (var i = 0; i < _border.Size; i++)
            {
                g.DrawLine(_linePen,
                    i * _cellWStep + Padding.Left,
                    Padding.Top,
                    i * _cellWStep + Padding.Left,
                    ClientSize.Height - Padding.Bottom);
            }
            for (var i = 0; i < _border.Size; i++)
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
            for (var i = 0; i < _border.Size; i++)
            {
                for (var j = 0; j < _border.Size; j++)
                {
                    var cellInfo = _border.GetCellInfo(i, j);

                    if (cellInfo.CellStatus == CellStatus.Empty)
                    {
                        continue;
                    }
                    var tempRectf = new RectangleF(Padding.Left + i * _cellWStep - _itemDiameter / 2,
                        Padding.Top + j * _cellHStep - _itemDiameter / 2,
                        _itemDiameter,
                        _itemDiameter);

                    g.FillEllipse(CellBrush[cellInfo.CellStatus], tempRectf);

                    g.DrawString(
                        cellInfo.Index.ToString(),
                        Font,
                        _stepTips,
                        tempRectf,
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                }
            }
        }

        #endregion

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
                || x > _border.Size
                || y > _border.Size
                || _border.GetCellInfo(x, y).CellStatus != CellStatus.Empty)
            {
                return;
            }
            OnChessboardClick.Invoke(x, y);
        }
    }
}
