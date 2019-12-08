using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PointsDivision.Draw
{
    public class Coordinator
    {
        private PictureBox _pictureBox;
        private int _maxX;
        private int _maxY;
        private int _del = 15;
        private PointF _center;
        private Graphics _graphics;
        private int pSize = 2;

        public int Del => _del;
        public PointF Center => _center;
        public int MaxX => _maxX * _del;
        public int MaxY => _maxY * _del;

        private PointF _leftX;
        public PointF LeftX => _leftX;

        private PointF _rightX;
        public PointF RightX => _rightX;

        private PointF _topY;
        public PointF TopY => _topY;

        private PointF _bottomY;
        public PointF BottomY => _bottomY;

        public Coordinator(Graphics graphics, PictureBox pictureBox, int maxX, int maxY)
        {
            _graphics = graphics;
            _pictureBox = pictureBox;
            _maxX = maxX;
            _maxY = maxY;
        }

        public PointF CalcPointFForCoordinates(PointF p)
        {
            return new PointF(p.X + _pictureBox.Width / 2, p.Y + _pictureBox.Height / 2);
        }

        public PointF GetRelativePointF(PointF p)
        {
            return new PointF(p.X + _pictureBox.Width / 2, _pictureBox.Height / 2 - p.Y);
        }

        public Graphics Execute()
        {
            _center = new PointF(0, 0);
            var center = CalcPointFForCoordinates(_center);
            _rightX = new PointF(MaxX, 0);
            var rightX = CalcPointFForCoordinates(_rightX);
            _topY = new PointF(0, MaxY);
            var topY = CalcPointFForCoordinates(_topY);
            _leftX = new PointF(-MaxX, 0);
            var leftX = CalcPointFForCoordinates(_leftX);
            _bottomY = new PointF(0, -MaxY);
            var bottomY = CalcPointFForCoordinates(_bottomY);

            var blackPen = new Pen(Color.Black);
            _graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, _pictureBox.Width, _pictureBox.Height);
            _graphics.DrawLine(blackPen, center.X, center.Y, rightX.X, rightX.Y);
            _graphics.DrawLine(blackPen, center.X, center.Y, topY.X, topY.Y);
            _graphics.DrawLine(blackPen, leftX.X, leftX.Y, center.X, center.Y);
            _graphics.DrawLine(blackPen, bottomY.X, bottomY.Y, center.X, center.Y);

            for (int i = 1; i <= _maxX; i++)
            {
                _graphics.DrawEllipse(blackPen, new RectangleF(center.X + (i * _del), center.Y, pSize, pSize));
                _graphics.DrawEllipse(blackPen, new RectangleF(center.X - (i * _del), center.Y, pSize, pSize));
            }
            for (int i = 1; i <= _maxY; i++)
            {
                _graphics.DrawEllipse(blackPen, new RectangleF(center.X, center.Y + (i * _del), pSize, pSize));
                _graphics.DrawEllipse(blackPen, new RectangleF(center.X, center.Y - (i * _del), pSize, pSize));
            }

            _graphics.Save();
            return _graphics;
        }
    }
}