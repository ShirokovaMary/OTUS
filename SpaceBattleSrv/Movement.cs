using System.Numerics;

namespace SpaceBattleSrv
{
    public class Movement
    {
        public void Execute(IMovable movable)
        {
            if (movable == null)
                throw new ArgumentNullException(nameof(movable));

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
