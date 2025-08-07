using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class RetryTwiceThenLogHandlerTests
    {
        [Fact]
        public void Handle_AddsRetryTwiceCommand_OnFirstFailure()
        {
            // Arrange
            var queue = new CommandQueue();
            var handler = new RetryTwiceThenLogHandler();
            var exception = new Exception("Error");
            var commandMock = new Mock<ICommand>();

            // Act
            handler.Handle(exception, commandMock.Object, queue);

            // Assert
            Assert.Single(queue.Commands);
            var retryCommand = queue.Commands.First() as RetryTwiceThenLogCommand;
            Assert.NotNull(retryCommand);
            Assert.Equal(commandMock.Object, retryCommand.OriginalCommand);
        }

        [Fact]
        public void Handle_AddsLogCommand_AfterTwoFailures()
        {
            // Arrange
            var queue = new CommandQueue();
            var handler = new RetryTwiceThenLogHandler();
            var exception = new Exception("Error");
            var retryCommand = new RetryTwiceThenLogCommand(new Mock<ICommand>().Object);

            // Act
            handler.Handle(exception, retryCommand, queue);

            // Assert
            Assert.Single(queue.Commands);
            Assert.IsType<LogExceptionCommand>(queue.Commands.First());
        }
    }
}
