using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointsDivision.Draw
{
    public class PointGenerator
    {
        private Coordinator _coordinator;
        private List<PointArea> _pointAreas;
        private Graphics _graphics;

        public List<Point> AllPoints
        {
            get
            {
                var points = new List<Point>();
                foreach (var pa in _pointAreas)
                {
                    points.AddRange(pa.Points);
                }
                return points;
            }
        }

        public PointGenerator(Graphics graphics, Coordinator coordinator)
        {
            _graphics = graphics;
            _coordinator = coordinator;
            _pointAreas = new List<PointArea>();
        }

        public Graphics Execute(Plane plane, Color color, int amount)
        {
            var pointArea = new PointArea(_coordinator, plane, color, amount);
            var colorPen = new Pen(color);
            var points = pointArea.Generate();
            foreach (var p in points)
            {
                _graphics.DrawEllipse(colorPen, new RectangleF(p.X, p.Y, 2, 2));
            }
            _pointAreas.Add(pointArea);
            _graphics.Save();
            return _graphics;
        }
    }
}