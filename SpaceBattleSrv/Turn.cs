using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class Turn
    {
        public Turn() { }

        public void Execute(ITurnable turnable, int agnleVelocity)
        {
            if (turnable == null)
                throw new ArgumentNullException(nameof(turnable));

            var velocity = turnable.Velocity;

            velocity.Angle += agnleVelocity;

            turnable.Velocity = velocity;
        }
    }
}
