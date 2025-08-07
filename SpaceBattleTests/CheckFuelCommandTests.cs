using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class CheckFuelCommandTests
    {
        /// <summary>
        /// команда выбрасывает исключение CommandException, когда топлива недостаточно
        /// </summary>
        [Fact]
        public void Execute_ThrowsWhenNotEnoughFuel()
        {
            // Arrange
            var consumer = new Mock<IFuelConsumer>();
            consumer.Setup(c => c.FuelLevel).Returns(5);
            consumer.Setup(c => c.FuelConsumption).Returns(10);

            //Act
            var command = new CheckFuelCommand(consumer.Object);

            //Assert
            // Act & Assert
            var exception = Assert.Throws<CommandException>(() => command.Execute());
            Assert.Equal("Не достаточно топлива", exception.Message);
        }

        /// <summary>
        /// проверяет нормальное выполнение, когда топлива достаточно
        /// </summary>
        [Fact]
        public void Execute_DoesNotThrowWhenEnoughFuel()
        {
            //Arrange
            var consumer = new Mock<IFuelConsumer>();
            consumer.Setup(c => c.FuelLevel).Returns(15);
            consumer.Setup(c => c.FuelConsumption).Returns(10);

            var cmd = new CheckFuelCommand(consumer.Object);

            //Act
            var exception = Record.Exception(() => cmd.Execute());

            //Assert
            Assert.Null(exception);
        }

        /// <summary>
        /// проверяет граничное условие
        /// </summary>
        [Fact]
        public void Execute_DoesNotThrow_WhenFuelExactlyEnough()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.Setup(f => f.FuelLevel).Returns(10);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(10);

            var command = new CheckFuelCommand(fuelConsumerMock.Object);

            // Act
            var exception = Record.Exception(() => command.Execute());

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        /// проверяет обработку null-аргументов
        /// </summary>
        [Fact]
        public void Execute_Throws_WhenFuelConsumerIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new CheckFuelCommand(null));
        }
    }
}
