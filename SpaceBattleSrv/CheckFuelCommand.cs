using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class CheckFuelCommand : ICommand
    {
        IFuelConsumer fuelConsumer;

        public CheckFuelCommand(IFuelConsumer fuelConsumer)
        {
            if (fuelConsumer == null)
                throw new ArgumentNullException(nameof(fuelConsumer));

            this.fuelConsumer = fuelConsumer;
        }

        public void Execute()
        {

            if (fuelConsumer.FuelLevel - fuelConsumer.FuelConsumption < 0)
                throw new CommandException("Не достаточно топлива");


        }
    }
}
