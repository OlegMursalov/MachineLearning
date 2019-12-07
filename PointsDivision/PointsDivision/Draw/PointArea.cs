using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointsDivision.Draw
{
    public class PointArea
    {
        private int _amount;
        private Color _color;
        private Coordinator _coordinator;
        private List<Point> _points;
        private Plane _plane;

        public List<Point> Points => _points;

        public PointArea(Coordinator coordinator, Plane plane, Color color, int amount)
        {
            _coordinator = coordinator;
            _plane = plane;
            _color = color;
            _amount = amount;
            _points = new List<Point>();
        }

        public List<Point> Generate()
        {
            var rand = new Random();
            _points = new List<Point>();
            for (int i = 0; i < _amount; i++)
            {
                var x = rand.Next(_coordinator.LeftX.X, _coordinator.RightX.X);
                var y = rand.Next(_coordinator.BottomY.Y, _coordinator.TopY.Y);
                _points.Add(new Point(x, y));
            }
            return _points;
        }
    }
}