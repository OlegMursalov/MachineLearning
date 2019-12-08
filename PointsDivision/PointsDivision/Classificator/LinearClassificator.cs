using PointsDivision.Draw;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows;

namespace PointsDivision.Classificator
{
    public class LinearClassificator
    {
        private Graphics _graphics;
        private Coordinator _coordinator;
        private PictureBox _pictureBox;
        private List<PointExt> _points;
        private float _a;
        private float _b;
        private float _offset;


        private float Func(float x)
        {
            var y = _a * x + _b;
            return y;
        }

        public LinearClassificator(Graphics graphics, Coordinator coordinator, PictureBox pictureBox, List<PointExt> points)
        {
            _graphics = graphics;
            _coordinator = coordinator;
            _pictureBox = pictureBox;
            _points = points;
        }

        /// <summary>
        /// Задать начальные характеристики для линейной функции
        /// </summary>
        public void SetParams(float a, float b, float offset)
        {
            _a = a;
            _b = b;
            _offset = offset;
        }

        public void Execute()
        {
            var initialPoint = new PointF(0, Func(0));
            var initialPointR = _coordinator.GetRelativePointF(initialPoint);

            foreach (var point in _points)
            {
                var factPoint = new PointF(point.X, Func(point.X));

                var expectedPoint = point.Point;

                // Красные точки должны быть над линией класификации
                if (point.Color == Color.Red)
                {
                    expectedPoint.Y += _offset;
                }
                // Зелене точки должны быть под линией класификации
                if (point.Color == Color.Green)
                {
                    expectedPoint.Y -= _offset;
                }

                // Вычисляем ошибку (ожидаемое y - фактическое y)
                var E = expectedPoint.Y - factPoint.Y;

                var factPointR = _coordinator.GetRelativePointF(factPoint);
                var expectedPointR = _coordinator.GetRelativePointF(expectedPoint);

                DrawLine(new Pen(Color.Red), initialPointR, factPointR);
                DrawLine(new Pen(Color.Green), initialPointR, expectedPointR);

                _pictureBox.InitialImage = new Bitmap(_pictureBox.Width, _pictureBox.Height, _graphics);
            }
        }

        private void DrawLine(Pen pen, PointF p1, PointF p2)
        {
            _graphics.DrawLine(pen, p1, p2);
            _graphics.Save();
        }
    }
}