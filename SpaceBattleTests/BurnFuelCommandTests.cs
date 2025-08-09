using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class BurnFuelCommandTests
    {
        /// <summary>
        /// Проверяет корректное уменьшение топлива (100 -> 85 при расходе 15)
        /// </summary>
        [Fact]
        public void Execute_ReducesFuelByConsumptionAmount()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.SetupProperty(f => f.FuelLevel, 100); // Начальное значение
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(15);

            var command = new BurnFuelCommand(fuelConsumerMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(85, fuelConsumerMock.Object.FuelLevel);
            fuelConsumerMock.VerifySet(f => f.FuelLevel = 85);
        }

        /// <summary>
        /// Проверяет, что команда корректно обрабатывает нулевой расход топлива
        /// </summary>
        [Fact]
        public void Execute_HandlesZeroConsumption()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.SetupProperty(f => f.FuelLevel, 50);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(0);

            var command = new BurnFuelCommand(fuelConsumerMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(50, fuelConsumerMock.Object.FuelLevel);
        }

        /// <summary>
        /// Убеждается, что конструктор проверяет входные параметры на null
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenFuelConsumerNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new BurnFuelCommand(null));
        }

        /// <summary>
        /// Проверяет корректную работу при точном совпадении уровня топлива и расхода (Граничный случай)
        /// </summary>
        [Fact]
        public void Execute_HandlesExactFuelConsumption()
        {
            // Arrange
            var fuelConsumerMock = new Mock<IFuelConsumer>();
            fuelConsumerMock.SetupProperty(f => f.FuelLevel, 20);
            fuelConsumerMock.Setup(f => f.FuelConsumption).Returns(20);

            var command = new BurnFuelCommand(fuelConsumerMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(0, fuelConsumerMock.Object.FuelLevel);
        }
    }
}
