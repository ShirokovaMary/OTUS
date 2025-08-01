using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class Turn: ICommand
    {
        ITurnable turnable { get; }
        int AngleVelocity { get; set; }

        public Turn(ITurnable turnable, int angleVelocity)
        { 
            ArgumentNullException.ThrowIfNull(turnable, nameof(turnable));
            this.turnable = turnable;
            this.AngleVelocity = angleVelocity;
        }

        public void Execute()
        {
            var velocity = turnable.Velocity;

            velocity.Angle += AngleVelocity;

            turnable.Velocity = velocity;
        }
    }
}
