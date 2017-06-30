using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gogogo.Helper;
using Gogogo.StaticData;
using TcpConnect.ServerInterface;

namespace Gogogo.Forms.ChessForms
{
    public partial class ChessMainControl : UserControl
    {
        private const float ITEM_SIZE_SCALE = 0.5f;
        private static readonly Dictionary<CellStatus, Brush> CellBrush =
            new Dictionary<CellStatus, Brush>
            {
                {CellStatus.Black, new SolidBrush(Color.Black)},
                {CellStatus.White, new SolidBrush(Color.White)}
            };

        private float _cellWStep;
        private float _cellHStep;
        private float _itemDiameter;

        private readonly Pen _linePen = new Pen(Color.Black, 1);
        private readonly Brush _numBrush = new SolidBrush(Color.Red);
        private readonly Pen _curStepTips = new Pen(Color.Green, 3);

        private CellStatus _curStatus = CellStatus.Black;
        public CellStatus CurStatus
        {
            private set
            {
                _curStatus = value;
                StepStatusChanged.Invoke();
            }
            get { return _curStatus; }
        }

        private const float NUM_W = 20;
        private const float NUM_H = 20;
        private readonly Border _border;

        public bool AutoCompute { get; set; }
        public Action<int, TimeSpan> ComputeFinished;
        public Action StepStatusChanged { set; get; }

        public void Redo()
        {
            if (!_border.UnPutChess())
            {
                return;
            }
            CurStatus = CellStatusHelper.Not(CurStatus);
        }

        public void RestartGame()
        {
            _border.ClearChess();
            CurStatus = CellStatus.Black;
        }

        public ChessMainControl()
        {
            InitializeComponent();
            ReInitCellSize();
            _border = new Border
            {
                ChessChanged = Refresh
            };
        }

        private void ReInitCellSize()
        {
            _cellWStep = ((float)ClientSize.Width - Padding.Left - Padding.Right)
                / (GlobalStatic.BORDER_SIZE - 1);
            _cellHStep = ((float)ClientSize.Height - Padding.Top - Padding.Bottom)
                / (GlobalStatic.BORDER_SIZE - 1);
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
            for (var i = 0; i < GlobalStatic.BORDER_SIZE; i++)
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
            for (var i = 0; i < GlobalStatic.BORDER_SIZE; i++)
            {
                g.DrawString(
                    i.ToString(),
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
            for (var i = 0; i < GlobalStatic.BORDER_SIZE; i++)
            {
                g.DrawLine(_linePen,
                    i * _cellWStep + Padding.Left,
                    Padding.Top,
                    i * _cellWStep + Padding.Left,
                    ClientSize.Height - Padding.Bottom);
            }
            for (var i = 0; i < GlobalStatic.BORDER_SIZE; i++)
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
            for (var i = 0; i < GlobalStatic.BORDER_SIZE; i++)
            {
                for (var j = 0; j < GlobalStatic.BORDER_SIZE; j++)
                {
                    if (_border.GetCellStatus(i, j) == CellStatus.Empty)
                    {
                        continue;
                    }

                    g.FillEllipse(CellBrush[_border.GetCellStatus(i, j)],
                        Padding.Left + i * _cellWStep - _itemDiameter / 2,
                        Padding.Top + j * _cellHStep - _itemDiameter / 2,
                        _itemDiameter,
                        _itemDiameter);
                    if (i == _border.LastStepPos.X && j == _border.LastStepPos.Y)
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

        private void MainControl_MouseClick(object sender, MouseEventArgs e)
        {
            var x = (int)Math.Round((e.X - Padding.Left) / _cellWStep);
            var y = (int)Math.Round((e.Y - Padding.Top) / _cellHStep);
            if (x < 0 || y < 0 
                || x > GlobalStatic.BORDER_SIZE || y > GlobalStatic.BORDER_SIZE 
                || _border.GetCellStatus(x ,y) != CellStatus.Empty)
            {
                return;
            }
            var pos = new Pos(x, y);
            _border.PutChess(pos, CurStatus);
            CurStatus = CellStatusHelper.Not(CurStatus);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Refresh();
        }
    }
}
