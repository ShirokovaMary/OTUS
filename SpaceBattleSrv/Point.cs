using System.ComponentModel;
using System.Numerics;

namespace SpaceBattleSrv
{
    /// <summary>
    /// Задает координаты в пространстве
    /// </summary>
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y) {
            X = x;
            Y = y;
        }

        // Переопределение Equals для сравнения значений
        public override bool Equals(object obj)
        {
            if (!(obj is Point other))
                return false;

            // Сравниваем с учётом погрешности для float
            return Math.Abs(X - other.X) < float.Epsilon &&
                   Math.Abs(Y - other.Y) < float.Epsilon;
        }

        // Переопределение GetHashCode (обязательно при переопределении Equals)
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        // Сложение позиций
        public static Point operator +(Point a, Vector b)
            => new Point(a.X + b.X, a.Y + b.Y);

        public static bool operator ==(Point left, Point right)
            => left.Equals(right);

        public static bool operator !=(Point left, Point right)
            => !left.Equals(right);

        public static Point operator *(Point a, float scalar)
            => new Point(a.X * scalar, a.Y * scalar);
    }
}