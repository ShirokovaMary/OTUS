using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class ChangeVelocityCommandTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenRotatableNull()
        {
            // Arrange
            IMovable movable = Mock.Of<IMovable>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => new ChangeVelocityCommand(null));
        }

        [Fact]
        public void Execute_RotatesVelocityCorrectly_45Degrees()
        {
            // Arrange
            var rotatableMock = new Mock<IRotatable>();
            rotatableMock.SetupProperty(m => m.Velocity, new Vector(1f, 0));
            rotatableMock.SetupProperty(m => m.Angle, 45);


            var movableMock = new Mock<IMovable>();

            var command = new ChangeVelocityCommand(rotatableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(0.71f, rotatableMock.Object.Velocity.X, precision: 2);
            Assert.Equal(0.71f, rotatableMock.Object.Velocity.Y, precision: 2);
        }

        [Fact]
        public void Execute_RotatesVelocityCorrectly_90Degrees()
        {
            // Arrange
            var rotatableMock = new Mock<IRotatable>();
            rotatableMock.SetupProperty(m => m.Velocity, new Vector(2f, 0));
            rotatableMock.SetupProperty(m => m.Angle, 90);

            var command = new ChangeVelocityCommand(rotatableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(0f, rotatableMock.Object.Velocity.X, precision: 2);
            Assert.Equal(2f, rotatableMock.Object.Velocity.Y, precision: 2);
        }

        [Fact]
        public void Execute_RotatesVelocityCorrectly_180Degrees()
        {
            // Arrange
            var rotatableMock = new Mock<IRotatable>();
            rotatableMock.SetupProperty(m => m.Velocity, new Vector(1f, 0));
            rotatableMock.SetupProperty(m => m.Angle, 180);

            var command = new ChangeVelocityCommand(rotatableMock.Object);

            // Act
            command.Execute();

            // Assert
            Assert.Equal(-1f, rotatableMock.Object.Velocity.X, precision: 2);
            Assert.Equal(0, rotatableMock.Object.Velocity.Y, precision: 2);
        }

    }
}
