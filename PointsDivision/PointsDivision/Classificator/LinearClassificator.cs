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

        private float _A; // Коэфициент A для линейного уравнения
        private float _B; // Коэфициент B для линейного уравнения
        private float _offset; // Смещение для желаемых результатов (точек)
        private float _L; // Коэфициент сглаживания (коэфициент обучения)

        private float Func(float x)
        {
            var y = _A * x + _B;
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
        public void SetParams(float a, float b, float offset, float L)
        {
            _A = a;
            _B = b;
            _offset = offset;
            _L = L;
        }

        public void Execute()
        {
            // Предполагаем, что линия классификатора начинается из точки 0:0
            var initialPoint = new PointF(0, Func(0));
            var initialPointR = _coordinator.GetRelativePointF(initialPoint);

            foreach (var point in _points)
            {
                // Фактическая точка, то, что вернула функция линейного классификатора с текущим A
                var factPoint = new PointF(point.X, Func(point.X));

                // Ожидаемая точка
                var expectedPoint = point.Point;

                // Красные точки должны быть над линией класификации
                if (point.Color == Color.Red)
                {
                    expectedPoint.Y += _offset;
                }
                // Зеленые точки должны быть под линией класификации
                if (point.Color == Color.Green)
                {
                    expectedPoint.Y -= _offset;
                }

                // Вычисляем ошибку (ожидаемое y - фактическое y)
                var E = expectedPoint.Y - factPoint.Y;

                var factPointR = _coordinator.GetRelativePointF(factPoint);
                var expectedPointR = _coordinator.GetRelativePointF(expectedPoint);

                if (point == _points.Last())
                {
                    var factPointR_forLine = new PointF(factPointR.X + 100, factPointR.Y - 100);
                    DrawLine(new Pen(Color.Red), initialPointR, factPointR_forLine);
                    // DrawLine(new Pen(Color.Green), initialPointR, expectedPointR);
                }

                _pictureBox.InitialImage = new Bitmap(_pictureBox.Width, _pictureBox.Height, _graphics);

                ChangeA(E, point.X);
            }
        }

        /// <summary>
        /// Правит коэфициент A в зависимости от ошибки
        /// </summary>
        private void ChangeA(float E, float x)
        {
            var deltaA = _L * (E / x);
            _A += deltaA;
        }

        private void DrawLine(Pen pen, PointF p1, PointF p2)
        {
            _graphics.DrawLine(pen, p1, p2);
            _graphics.Save();
        }
    }
}