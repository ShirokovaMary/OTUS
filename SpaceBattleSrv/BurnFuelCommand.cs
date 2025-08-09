using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class BurnFuelCommand : ICommand
    {
        IFuelConsumer fuelConsumer;

        public BurnFuelCommand (IFuelConsumer fuelConsumer)
        {
            if (fuelConsumer == null)
                throw new ArgumentNullException(nameof(fuelConsumer));

            this.fuelConsumer = fuelConsumer;
        }

        public void Execute()
        {
            fuelConsumer.FuelLevel -= fuelConsumer.FuelConsumption;
        }

    }
}
