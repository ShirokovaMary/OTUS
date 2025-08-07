using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class LogExceptionHandlerTests
    {
        [Fact]
        public void Handle_AddsLogCommandToQueue()
        {
            // Arrange
            var queue = new CommandQueue();
            var handler = new LogExceptionHandler();
            var exception = new Exception("Test error");
            var commandMock = new Mock<ICommand>();

            // Act
            handler.Handle(exception, commandMock.Object, queue);

            // Assert
            Assert.Single(queue.Commands);
            var logCommand = queue.Commands.First() as LogExceptionCommand;
            Assert.NotNull(logCommand);
            Assert.Equal(commandMock.Object, logCommand.FailedCommand);
            Assert.Equal(exception, logCommand.Exception);
        }
    }
}
