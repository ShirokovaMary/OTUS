using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class CommandQueueTests
    {
        [Fact]
        public void ProcessQueue_ExecutesCommandsInOrder()
        {
            // Arrange
            var queue = new CommandQueue();
            var command1 = new Mock<ICommand>();
            var command2 = new Mock<ICommand>();

            queue.AddCommand(command1.Object);
            queue.AddCommand(command2.Object);

            // Act
            queue.ProcessQueue();

            // Assert
            command1.Verify(c => c.Execute(), Times.Once);
            command2.Verify(c => c.Execute(), Times.Once);
        }

        [Fact]
        public void ProcessQueue_CallsExceptionHandler_WhenCommandFails()
        {
            // Arrange
            var queue = new CommandQueue();
            var handlerMock = new Mock<IExceptionHandler>();
            handlerMock.Setup(h => h.CanHandle(It.IsAny<Exception>(), It.IsAny<ICommand>())).Returns(true);

            queue.AddHandler(handlerMock.Object);

            var failingCommand = new Mock<ICommand>();
            failingCommand.Setup(c => c.Execute()).Throws<InvalidOperationException>();

            queue.AddCommand(failingCommand.Object);

            // Act
            queue.ProcessQueue();

            // Assert
            handlerMock.Verify(
                h => h.Handle(It.IsAny<Exception>(), failingCommand.Object, queue),
                Times.Once
            );
        }
    }
}
