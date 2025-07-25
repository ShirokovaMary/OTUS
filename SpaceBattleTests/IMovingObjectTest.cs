using Moq;
using SpaceBattleSrv;

namespace SpaceBattleTests
{
    public class IMovingObjectTest
    {
        [Fact]
        public void Movable_CorrectMove()
        {
            // Arrange
            var mock = new Mock<IMovable>();
            mock.SetupProperty(m => m.Position, new Point(12,5));
            mock.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

            var movement = new Movement();

            //Act
            movement.Execute(mock.Object);

            //Assert
            var movable = mock.Object;
            Assert.Equal(new Point(5,8), movable.Position); // Проверяем

        }

        [Fact]
        public void Movable_ThrowsException_WhenPositionNotReadable()
        {
            // Arrange
            var mock = new Mock<IMovable>();
            mock.SetupGet(m=>m.Position).Throws<InvalidOperationException>();

            var movement = new Movement();

            //Act&Assert
            Assert.Throws<InvalidOperationException>( () => movement.Execute(mock.Object));

        }

        [Fact]
        public void Movable_ThrowsException_WhenVelocityNotReadable()
        {
            // Arrange
            var mock = new Mock<IMovable>();
            mock.SetupGet(m=>m.Velocity).Throws<InvalidOperationException>();

            var movement = new Movement();

            //Act&Assert
            Assert.Throws<InvalidOperationException>(() => movement.Execute(mock.Object));
        }

        [Fact]
        public void Movable_ThrowsException_WhenPositionNotWritable()
        {
            // Arrange
            var mock = new Mock<IMovable>();
            mock.SetupProperty(m => m.Position, new Point(0, 0));
            mock.SetupGet(m => m.Velocity).Throws<InvalidOperationException>();

            var movement = new Movement();

            //Act&Assert
            Assert.Throws<InvalidOperationException>(() => movement.Execute(mock.Object));
        }
    }
}