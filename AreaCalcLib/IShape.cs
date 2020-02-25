using System;

namespace AreaCalcLib
{
    public interface IShape
    {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        double GetShapeArea();
    }
}
