using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class RotateWithChangeVelocityCommandTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenRotatableNull()
        {
            // Arrange& Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new RotateWithChangeVelocityCommand(null));
        }

        [Fact]
        public void Execute_Rotate()
        {
            // Arrange
            var rotatableMock = new Mock<IRotatable>();
            rotatableMock.SetupProperty(m => m.Velocity, new Vector(1f, 0));
            rotatableMock.SetupProperty(m => m.Angle, 0);
            rotatableMock.SetupGet(m => m.RotationSpeed).Returns(45);

            var command = new RotateWithChangeVelocityCommand(rotatableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(0.71f, rotatableMock.Object.Velocity.X, precision: 2);
            Assert.Equal(0.71f, rotatableMock.Object.Velocity.Y, precision: 2);

        }

    }
}
