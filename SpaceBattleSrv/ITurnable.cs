using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface ITurnable
    {
        /// <summary>
        /// Вектор скорости движения
        /// </summary>
        Vector2 Velocity { get; set; }

    }
}
