using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointsDivision.Draw
{
    public class PointGenerator
    {
        private int _amount;
        private Color _color;
        private Coordinator _coordinator;
        private List<Point> _points;

        public PointGenerator(Coordinator coordinator, int amount, Color color, Plane plane)
        {
            _amount = amount;
            _color = color;
            _coordinator = coordinator;
            _points = new List<Point>();
        }

        public Bitmap Execute(Bitmap bitmap)
        {
            var rand = new Random();
            var colorPen = new Pen(_color);
            var g = Graphics.FromImage(bitmap);
            for (int i = 0; i < _amount; i++)
            {
                var x = rand.Next(_coordinator.MaxX, _coordinator.MaxY);
                var y = rand.Next(_coordinator.MaxX, _coordinator.MaxY);
                var p = new Point(x, y);
                _points.Add(p);
                g.DrawEllipse(colorPen, new RectangleF(p.X, p.Y, 2, 2));
            }
            g.Save();
            return bitmap;
        }
    }
}