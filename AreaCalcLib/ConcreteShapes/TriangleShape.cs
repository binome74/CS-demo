using System;

namespace AreaCalcLib
{
    class TriangleShape : IShape
    {
        /// <summary>
        /// Первая сторона треугольника
        /// </summary>
        public double A { get; }
        /// <summary>
        /// Вторая сторона треугольника
        /// </summary>
        public double B { get; }
        /// <summary>
        /// Третья сторона треугольника
        /// </summary>
        public double C { get; }
        /// <summary>
        /// Признак прямоугольного треугольника
        /// </summary>
        public bool IsRightAngled { get; private set; }
        /// <summary>
        /// Признак вырожденного треугольника (все три точки на одной прямой)
        /// </summary>
        public bool IsDegenerate { get; } = false;

        /// <summary>
        /// Копия длин катетов
        /// </summary>
        private double Cat1, Cat2;

        /// <summary>
        /// Выключим конструктор по умолчанию
        /// </summary>
        private TriangleShape() { }

        /// <summary>
        /// Конструктор для создания треугольника по трем сторонам
        /// </summary>
        /// <param name="a">Первая сторона треугольника</param>
        /// <param name="b">Вторая сторона треугольника</param>
        /// <param name="c">Третья сторона треугольника</param>
        public TriangleShape(double a, double b, double c)
        {
            // Проверим очевидные ограничения
            if (a <= 0) throw new ArgumentOutOfRangeException("a");
            if (b <= 0) throw new ArgumentOutOfRangeException("b");
            if (c <= 0) throw new ArgumentOutOfRangeException("c");
            // Проверим неравенство теругольника
            if ((a > b + c + Double.Epsilon) || (b > a + c + Double.Epsilon) || (c > a + b + Double.Epsilon))
                throw new ArgumentException("Не существует такого треугольника");
            // Проверим вырожденность треугольника
            IsDegenerate = (Math.Abs(a - b - c) <= Double.Epsilon) 
                || (Math.Abs(b - a - c) <= Double.Epsilon) 
                || (Math.Abs(c - a - b) <= Double.Epsilon)
            ;
            A = a; B = b; C = c;
            DetermineIfRightAngled();
        }

        private void DetermineIfRightAngled()
        {
            IsRightAngled = false;
            if (IsDegenerate) return;
            // Проверим "обратную" теорему Пифагора
            if (Math.Abs(B * B - A * A - C * C) <= Double.Epsilon)
            {
                Cat1 = A; Cat2 = C; IsRightAngled = true;
            }
            else if (Math.Abs(A * A - B * B - C * C) <= Double.Epsilon)
            {
                Cat1 = C; Cat2 = B; IsRightAngled = true;
            }
            else if (Math.Abs(C * C - A * A - B * B) <= Double.Epsilon)
            {
                Cat1 = A; Cat2 = B; IsRightAngled = true;
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double GetShapeArea()
        {
            // Вырожденный треугольник - нулевая площадь
            if (IsDegenerate) return 0;
            // Прямоугольный треугольник - специальная формула
            if (IsRightAngled) return Cat1 * Cat2 / 2.0;
            // Формула Герона для общего случая
            double half_p = (A + B + C) / 2.0;
            return Math.Sqrt( half_p * (half_p - A) * (half_p - B) * (half_p - C) );
        }
    }
}
