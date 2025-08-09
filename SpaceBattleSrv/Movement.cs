using System.Numerics;

namespace SpaceBattleSrv
{
    public class Movement: ICommand
    {
        IMovable movable;

        public Movement(IMovable movable)
        {
            ArgumentNullException.ThrowIfNull(movable);

            ArgumentNullException.ThrowIfNull(movable.Position);

            this.movable = movable;
        }

        public void Execute()
        {
            var velocity = movable.Velocity;

            movable.Position = movable.Position + velocity;
        }

        private Point AngleToDirection(float rotationAngle)
        {
            return new Point(
                (float)Math.Cos(rotationAngle),
                (float)Math.Sin(rotationAngle)
            );
        }

    }
}
