using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class RotateWithChangeVelocityCommand : MacroCommand
    {
        public RotateWithChangeVelocityCommand(IRotatable rotatable)
    : base(
        new RotateCommand(rotatable),
        new ChangeVelocityCommand(rotatable))
        {
        }

    }
}
