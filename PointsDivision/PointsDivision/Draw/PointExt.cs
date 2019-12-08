using System.Drawing;

namespace PointsDivision.Draw
{
    public class PointExt
    {
        public PointF Point { get; set; }
        public Color Color { get; set; }
        public float X => Point.X;
        public float Y => Point.Y;
    }
}