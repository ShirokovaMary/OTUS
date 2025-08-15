using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class MoveWithFuelCommandTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenFuelConsumerNull()
        {
            // Arrange
            var movableMock = new Mock<IMovable>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new MoveWithFuelCommand(null, movableMock.Object));
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenMovableNull()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new MoveWithFuelCommand(fuelConsumerMock.Object, null));
        }

        [Fact]
        public void Execute_MovesObject_WhenFuelIsSufficient()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.Setup(f => f.FuelLevel).Returns(100);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(10);

            var movableMock = new Mock<IMovable>();
            movableMock.SetupProperty(m => m.Position, new Point(5, 5));
            movableMock.SetupGet(m => m.Velocity).Returns(new Vector(2, 3));

            var command = new MoveWithFuelCommand(fuelConsumerMock.Object, movableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(new Point(7, 8), movableMock.Object.Position);
            fuelConsumerMock.VerifySet(f => f.FuelLevel = 90);
        }

        [Fact]
        public void Execute_ThrowsCommandException_WhenFuelNotEnough()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.Setup(f => f.FuelLevel).Returns(5);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(10);

            var movableMock = new Mock<IMovable>();
            movableMock.SetupProperty(m => m.Position, new Point(1,1));
            movableMock.SetupGet(m => m.Velocity).Returns(new Vector(1, 1));

            var command = new MoveWithFuelCommand(fuelConsumerMock.Object, movableMock.Object);

            // Act & Assert
            var exception = Assert.Throws<CommandException>(() => command.Execute());
            var exceptionMessage = exception.ToString();
            Assert.Contains("Не достаточно топлива", exceptionMessage);
            movableMock.VerifySet(m => m.Position = It.IsAny<Point>(), Times.Never);
        }

        [Fact]
        public void Execute_DoesNotMove_WhenVelocityZero()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.SetupProperty(f => f.FuelLevel, 50);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(5);

            var movableMock = new Mock<IMovable>();
            movableMock.SetupProperty(m => m.Position, new Point(0, 0));
            movableMock.SetupGet(m => m.Velocity).Returns(new Vector(0, 0));

            var command = new MoveWithFuelCommand(fuelConsumerMock.Object, movableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(new Point(0, 0), movableMock.Object.Position);
            Assert.Equal(45, fuelConsumerMock.Object.FuelLevel);
        }

        [Fact]
        public void Execute_ConsumesFuelEven_WhenNotMoving()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.SetupProperty(f => f.FuelLevel, 10);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(3);

            var movableMock = new Mock<IMovable>();
            movableMock.SetupProperty(m => m.Position, new Point(1,1));
            movableMock.SetupGet(m => m.Velocity).Returns(new Vector(0, 0));

            var command = new MoveWithFuelCommand(fuelConsumerMock.Object, movableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(7, fuelConsumerMock.Object.FuelLevel);
        }

    }
}
