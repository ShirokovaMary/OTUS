using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class ChangeVelocityCommand : ICommand
    {
        private readonly IRotatable _rotatable;

        public ChangeVelocityCommand(IRotatable rotatable)
        {
            if (rotatable == null)
                throw new ArgumentNullException(nameof(rotatable));

            _rotatable = rotatable;
        }

        public void Execute()
        {
            if (_rotatable == null) return;

            var angle = Math.PI * _rotatable.Angle / 180; // Преобразуем градусы в радианы
            var velocity = _rotatable.Velocity;

            // Поворачиваем вектор скорости на 45 градусов
            var cos = Math.Cos(angle); // cos(45°)
            var sin = Math.Sin(angle); // sin(45°)

            // Новая скорость после поворота
            var newX = velocity.X * cos - velocity.Y * sin;
            var newY = velocity.X * sin + velocity.Y * cos;

            // Округляем до 2 знаков для избежания погрешностей
            _rotatable.Velocity.X = (float)Math.Round(newX, 2);
            _rotatable.Velocity.Y = (float)Math.Round(newY, 2);

        }
    }
}
