using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class MoveWithFuelCommand : MacroCommand
    {
        public MoveWithFuelCommand(IFuelConsumer fuelConsumer, IMovable movable)
            : base(
                new CheckFuelCommand(fuelConsumer),
                new Movement(movable),
                new BurnFuelCommand(fuelConsumer))
        {
        }
    }
}
