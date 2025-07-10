using QuadraticEquationLib;

namespace QuadraticEquationTests
{
    public class QuadraticEquationTests
    {
        [Theory]
        [InlineData(1, 0, 1, new double[] { })]
        [InlineData(1, 0, -1, new double[] { 2, -2 })]
        [InlineData(1, 2, 1, new double[] { -1, -1 })]
        [InlineData(double.Epsilon * 1.5, double.Epsilon * 2, double.Epsilon * 2, new double[] { -0.5, -0.5 })]
        public void Solve_ShouldReturnCorrectData(double a, double b, double c, double[] expected)
        {
            // Arrange
            QudraticEquation qudraticEquation = new QudraticEquation();

            //Act
            var result = qudraticEquation.Solve(a, b, c);

            //Assert
            Assert.Equal(expected, result);

        }

        [Theory]
        [InlineData(0, 2, 1)]
        [InlineData(double.NaN, 2, 1)]
        [InlineData(1, double.NaN, -1)]
        [InlineData(1, -1, double.NaN)]
        [InlineData(double.NegativeInfinity, 2, 1)]
        [InlineData(1, double.NegativeInfinity, 1)]
        [InlineData(1, 2, double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity, 2, 1)]
        [InlineData(1, double.PositiveInfinity, 1)]
        [InlineData(1, 2, double.PositiveInfinity)]
        public void Solve_ShuldReturnException(double a, double b, double c)
        {
            // Arrange
            QudraticEquation qudraticEquation = new QudraticEquation();

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var result = qudraticEquation.Solve(a, b, c);
            });
        }
    }
}