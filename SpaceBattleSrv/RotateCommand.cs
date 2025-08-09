using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class RotateCommand : ICommand
    {
        IRotatable rotatable { get; }

        public RotateCommand(IRotatable rotatable, int angle)
        {
            ArgumentNullException.ThrowIfNull(rotatable, nameof(rotatable));
            this.rotatable = rotatable;
        }

        public void Execute()
        {
            rotatable.Angle += rotatable.RotationSpeed;
        }
    }
}
