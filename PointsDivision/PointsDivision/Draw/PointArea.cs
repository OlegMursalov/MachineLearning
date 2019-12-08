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

        public List<Point> Points { get; private set; }
        public Color Color { get; private set; }

        public PointArea(Coordinator coordinator, Plane plane, Color color, int amount)
        {
            _coordinator = coordinator;
            _plane = plane;
            Color = color;
            _amount = amount;
            Points = new List<Point>();
            _random = new Random();
        }

        public List<Point> Generate()
        {
            Points = new List<Point>();
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
                    x = _random.Next(_coordinator.LeftX.X, _coordinator.Center.X);
                    y = _random.Next(_coordinator.Center.Y, _coordinator.TopY.Y);
                    break;
                case Plane.BottomLeft:
                    x = _random.Next(_coordinator.LeftX.X, _coordinator.Center.X);
                    y = _random.Next(_coordinator.BottomY.Y, _coordinator.Center.Y);
                    break;
                case Plane.TopRight:
                    x = _random.Next(_coordinator.Center.X, _coordinator.RightX.X);
                    y = _random.Next(_coordinator.Center.Y, _coordinator.TopY.Y);
                    break;
                case Plane.BottomRight:
                    x = _random.Next(_coordinator.Center.X, _coordinator.RightX.X);
                    y = _random.Next(_coordinator.BottomY.Y, _coordinator.Center.Y);
                    break;
            }
            return new Point(x, y);
        }
    }
}