using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface IFuelBurnable
    {
        /// <summary>
        /// Объем топливного бака
        /// </summary>
        int TankCapacity
        {
            get;
        }

        /// <summary>
        /// Остаток топлива
        /// </summary>
        int FuelRemaining
        {
            get; set;
        }

        /// <summary>
        /// Расход топлива на 1 движение
        /// </summary>
        int Consumption { get; }

    }
}
