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
        private int pSize = 2;

        public List<PointExt> AllPointsExt
        {
            get
            {
                var points = new List<PointExt>();
                foreach (var pa in _pointAreas)
                {
                    foreach (var p in pa.Points)
                    {
                        points.Add(new PointExt
                        {
                            Point = p,
                            Color = pa.Color
                        });
                    }
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
                var relativePoint = _coordinator.GetRelativePointF(p);
                var rF = new RectangleF(relativePoint.X, relativePoint.Y, pSize, pSize);
                _graphics.DrawEllipse(colorPen, rF);
            }
            _pointAreas.Add(pointArea);
            _graphics.Save();
            return _graphics;
        }
    }
}