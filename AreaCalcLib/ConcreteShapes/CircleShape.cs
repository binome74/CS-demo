using System;

namespace AreaCalcLib
{
    class CircleShape : IShape
    {
        public double Radius { get; }

        /// <summary>
        /// Конструктор по умолчанию создает единичную окружность
        /// </summary>
        public CircleShape()
        {
            Radius = 1;
        }

        /// <summary>
        /// Конструктор круга по переданному радиусу
        /// </summary>
        /// <param name="radius">радиус</param>
        public CircleShape(double radius)
        {
            // Проверка, что радиус неотрицательный
            if (radius < 0) throw new ArgumentOutOfRangeException("radius");
            Radius = radius;
        }

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        /// <returns>Площадь круга</returns>
        public double GetShapeArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
