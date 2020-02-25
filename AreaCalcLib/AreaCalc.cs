using System;

namespace AreaCalcLib {

    /// <summary>
    /// Перечисление типов фигур
    /// </summary>
    public enum ShapeType
    {
        CIRCLE
        ,TRIANGLE
    }

    public static class AreaCalc
    {
        /// <summary>
        /// Простая фабрика (для удобства клиента)
        /// </summary>
        /// <param name="st">Тип создаваемой фигуры из перечисления ShapeType</param>
        /// <param name="p">Для ShapeType.CIRCLE - один параметр (радиус), для ShapeType.TRIANGLE - три параметра (стороны)</param>
        /// <returns></returns>
        public static IShape CreateShape(ShapeType st, params double[] p)
        {
            switch(st)
            {
                // Выброс исключений при неправильном вызове метода пока отдадим на откуп среде исполнения
                case ShapeType.CIRCLE: return CreateCircle(p[0]);
                case ShapeType.TRIANGLE: return CreateTriangle(p[0], p[1], p[2]);
                default: throw new NotSupportedException("This shape is not supported");
            }
        }

        /// <summary>
        /// Возвращает новый объект треугольника (TriangleShape), заданного тремя сторонами
        /// </summary>
        /// <param name="a">Первая сторона треугольника</param>
        /// <param name="b">Вторая сторона треугольника</param>
        /// <param name="c">Третья сторона треугольника</param>
        /// <returns></returns>
        public static IShape CreateTriangle(double a, double b, double c)
        {
            return new TriangleShape(a, b, c);
        }

        /// <summary>
        /// Возвращает новый объект круга (CircleShape)
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static IShape CreateCircle(double radius)
        {
            return new CircleShape(radius);
        }
    }
}
