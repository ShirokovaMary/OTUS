using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface IRotatable
    {
        /// <summary>
        /// Вектор движения
        /// </summary>
        Vector Velocity { get; set; }

        /// <summary>
        /// Скорость вращения (градусов в такт)
        /// </summary>
        double RotationSpeed { get; }

        /// <summary>
        /// точка вращения
        /// </summary>
        Point RotationCenter { get; }

        /// <summary>
        /// Текущий угол поворота
        /// </summary>
        double Angle { get; set; }

    }
}
