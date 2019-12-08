using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointsDivision.Draw
{
    public class PointArea
    {
        private int _amount;
        private Coordinator _coordinator;
        private Plane _plane;
        private Random _random;

        public List<PointF> Points { get; private set; }
        public Color Color { get; private set; }

        public PointArea(Coordinator coordinator, Plane plane, Color color, int amount)
        {
            _coordinator = coordinator;
            _plane = plane;
            Color = color;
            _amount = amount;
            Points = new List<PointF>();
            _random = new Random();
        }

        public List<PointF> Generate()
        {
            Points = new List<PointF>();
            for (int i = 0; i < _amount; i++)
            {
                var p = RandPointByPlane();
                Points.Add(p);
            }
            return Points;
        }

        public Point RandPointByPlane()
        {
            int x = 0, y = 0;
            switch (_plane)
            {
                case Plane.TopLeft:
                    x = _random.Next((int)_coordinator.LeftX.X, (int)_coordinator.Center.X);
                    y = _random.Next((int)_coordinator.Center.Y, (int)_coordinator.TopY.Y);
                    break;
                case Plane.BottomLeft:
                    x = _random.Next((int)_coordinator.LeftX.X, (int)_coordinator.Center.X);
                    y = _random.Next((int)_coordinator.BottomY.Y, (int)_coordinator.Center.Y);
                    break;
                case Plane.TopRight:
                    x = _random.Next((int)_coordinator.Center.X, (int)_coordinator.RightX.X);
                    y = _random.Next((int)_coordinator.Center.Y, (int)_coordinator.TopY.Y);
                    break;
                case Plane.BottomRight:
                    x = _random.Next((int)_coordinator.Center.X, (int)_coordinator.RightX.X);
                    y = _random.Next((int)_coordinator.BottomY.Y, (int)_coordinator.Center.Y);
                    break;
                case Plane.TopRightTopTriangle:
                    x = _random.Next((int)_coordinator.Center.X, (int)_coordinator.RightX.X);
                    y = _random.Next((int)x, (int)_coordinator.TopY.Y);
                    break;
                case Plane.TopRightBottomTriangle:
                    x = _random.Next((int)_coordinator.Center.X, (int)_coordinator.RightX.X);
                    y = _random.Next((int)_coordinator.Center.Y, (int)x);
                    break;
            }
            return new Point(x, y);
        }
    }
}