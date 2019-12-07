using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointsDivision.Draw
{
    public class PointGenerator
    {
        private Coordinator _coordinator;
        private List<PointArea> _pointAreas;

        public PointGenerator(Coordinator coordinator)
        {
            _coordinator = coordinator;
            _pointAreas = new List<PointArea>();
        }

        public Bitmap Execute(Bitmap bitmap, Plane plane, Color color, int amount)
        {
            var pointArea = new PointArea(_coordinator, plane, color, amount);
            var colorPen = new Pen(color);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                foreach (var p in pointArea.Generate())
                {
                    graphics.DrawEllipse(colorPen, new RectangleF(p.X, p.Y, 2, 2));
                }
                _pointAreas.Add(pointArea);
                graphics.Save();
                return bitmap;
            }
        }
    }
}