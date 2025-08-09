using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface IFuelConsumer
    {
        /// <summary>
        /// Текущий уровень топлива
        /// </summary>
        int FuelLevel { get; set; }

        /// <summary>
        /// Скорость расхода топлива
        /// </summary>
        int FuelConsumption { get; set; }
    }
}
