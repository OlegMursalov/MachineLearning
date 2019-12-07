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
        private Point _factCenter;
        private int _del = 15;
        private Graphics _graphics;

        public int Del => _del;
        public Point FactCenter => _factCenter;
        public int MaxX => _maxX * _del;
        public int MaxY => _maxY * _del;

        private Point _leftX;
        public Point LeftX => _leftX;

        private Point _rightX;
        public Point RightX => _rightX;

        private Point _topY;
        public Point TopY => _topY;

        private Point _bottomY;
        public Point BottomY => _bottomY;

        public Coordinator(Graphics graphics, PictureBox pictureBox, int maxX, int maxY)
        {
            _graphics = graphics;
            _pictureBox = pictureBox;
            _maxX = maxX;
            _maxY = maxY;
            _factCenter = GetFactCenter();
        }

        private Point GetFactCenter()
        {
            return new Point(_pictureBox.Width / 2, _pictureBox.Height / 2);
        }

        public Graphics Execute()
        {
            var blackPen = new Pen(Color.Black);
            _graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, _pictureBox.Width, _pictureBox.Height);
            _rightX = new Point(_factCenter.X + MaxX, _factCenter.Y);
            _graphics.DrawLine(blackPen, _factCenter.X, _factCenter.Y, _rightX.X, _rightX.Y);
            _topY = new Point(_factCenter.X, _factCenter.Y + MaxY);
            _graphics.DrawLine(blackPen, _factCenter.X, _factCenter.Y, _topY.X, _topY.Y);
            _leftX = new Point(_factCenter.X - MaxX, _factCenter.Y);
            _graphics.DrawLine(blackPen, _leftX.X, _leftX.Y, _factCenter.X, _factCenter.Y);
            _bottomY = new Point(_factCenter.X, _factCenter.Y - MaxY);
            _graphics.DrawLine(blackPen, _bottomY.X, _bottomY.Y, _factCenter.X, _factCenter.Y);
            for (int i = 1; i <= _maxX; i++)
            {
                _graphics.DrawEllipse(blackPen, new RectangleF(_factCenter.X + (i * _del), _factCenter.Y, 2, 2));
                _graphics.DrawEllipse(blackPen, new RectangleF(_factCenter.X - (i * _del), _factCenter.Y, 2, 2));
            }
            for (int i = 1; i <= _maxY; i++)
            {
                _graphics.DrawEllipse(blackPen, new RectangleF(_factCenter.X, _factCenter.Y + (i * _del), 2, 2));
                _graphics.DrawEllipse(blackPen, new RectangleF(_factCenter.X, _factCenter.Y - (i * _del), 2, 2));
            }
            _graphics.Save();
            return _graphics;
        }
    }
}