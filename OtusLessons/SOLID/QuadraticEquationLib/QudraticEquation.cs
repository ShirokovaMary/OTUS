namespace QuadraticEquationLib
{
    public class QudraticEquation
    {
        public double[] Solve(double a, double b, double c)
        {

            if (Math.Abs(a) <= double.Epsilon)
                throw new ArgumentException("Argument is invalid");

            if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c))
                throw new ArgumentException("Argument NaN is invalid");

            if (double.IsPositiveInfinity(a) || double.IsPositiveInfinity(b) || double.IsPositiveInfinity(c))
                throw new ArgumentException("Argument PositiveInfinity is invalid");

            if (double.IsNegativeInfinity(a) || double.IsNegativeInfinity(b) || double.IsNegativeInfinity(c))
                throw new ArgumentException("Argument NegativeInfinity is invalid");

            //Дискриминант d=b^2-4ac;
            double d = b * b - 4 * a * c;
            double x1, x2;

            if (d < 0)
            {
                //отрицательный дискриминант - нет решения
                return [ ];
            }

            if (Math.Abs(d) <= double.Epsilon)
            {
                // дискриминант = 0 -> 1 решение
                x1 = x2 = -b / (2 * a);
                return [ x1, x2 ];
            }

            // дискриминант > 0 -> 2 решения

            var sqrt = Math.Sqrt(d);

            x1 = (-b + d) / (2 * a);
            x2 = (-b - d) / (2 * a);

            return [ x1, x2 ];

        }
    }
}
