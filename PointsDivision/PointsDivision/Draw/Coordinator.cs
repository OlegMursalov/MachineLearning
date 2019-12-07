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
        private Point _center;
        private int _del = 15;

        public Point Center => _center;
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

        public Coordinator(PictureBox pictureBox, int maxX, int maxY)
        {
            _pictureBox = pictureBox;
            _maxX = maxX;
            _maxY = maxY;
            _center = GetCenter();
        }

        private Point GetCenter()
        {
            return new Point(_pictureBox.Width / 2, _pictureBox.Height / 2);
        }

        public Bitmap Execute()
        {
            var blackPen = new Pen(Color.Black);
            var bitmap = new Bitmap(_pictureBox.Width, _pictureBox.Height, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, _pictureBox.Width, _pictureBox.Height);
                _rightX = new Point(_center.X + MaxX, _center.Y);
                g.DrawLine(blackPen, _center.X, _center.Y, _rightX.X, _rightX.Y);
                _topY = new Point(_center.X, _center.Y + MaxY);
                g.DrawLine(blackPen, _center.X, _center.Y, _topY.X, _topY.Y);
                _leftX = new Point(_center.X - MaxX, _center.Y);
                g.DrawLine(blackPen, _leftX.X, _leftX.Y, _center.X, _center.Y);
                _bottomY = new Point(_center.X, _center.Y - MaxY);
                g.DrawLine(blackPen, _bottomY.X, _bottomY.Y, _center.X, _center.Y);
                for (int i = 1; i <= _maxX; i++)
                {
                    g.DrawEllipse(blackPen, new RectangleF(_center.X + (i * _del), _center.Y, 2, 2));
                    g.DrawEllipse(blackPen, new RectangleF(_center.X - (i * _del), _center.Y, 2, 2));
                }
                for (int i = 1; i <= _maxY; i++)
                {
                    g.DrawEllipse(blackPen, new RectangleF(_center.X, _center.Y + (i * _del), 2, 2));
                    g.DrawEllipse(blackPen, new RectangleF(_center.X, _center.Y - (i * _del), 2, 2));
                }
                g.Save();
                return bitmap;
            }
        }
    }
}