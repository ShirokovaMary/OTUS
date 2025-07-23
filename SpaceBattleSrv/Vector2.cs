namespace SpaceBattleSrv
{
    /// <summary>
    /// Вектор движения
    /// </summary>
    public class Vector2
    {
        /// <summary>
        /// мгновенная скорость
        /// </summary>
        public float Velocity { get; set; }

        /// <summary>
        /// Угол поворота
        /// </summary>
        public float Angle { get; set; }

        public Vector2(float velocity, float angle)
        {
            Velocity = velocity;
            Angle = angle;

        }

        // Переопределение Equals для сравнения значений
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2 other))
                return false;

            // Сравниваем с учётом погрешности для float
            return Math.Abs(Velocity - other.Velocity) < float.Epsilon &&
                   Math.Abs(Angle - other.Angle) < float.Epsilon;
        }

        // Переопределение GetHashCode (обязательно при переопределении Equals)
        public override int GetHashCode()
        {
            return HashCode.Combine(Velocity, Angle);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
            => left.Equals(right);

        public static bool operator !=(Vector2 left, Vector2 right)
            => !left.Equals(right);


    }
}