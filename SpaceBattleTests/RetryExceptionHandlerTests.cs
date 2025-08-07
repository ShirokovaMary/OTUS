using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class RetryExceptionHandlerTests
    {
        [Fact]
        public void Handle_AddsRetryCommandToQueue()
        {
            // Arrange
            var queue = new CommandQueue();
            var handler = new RetryExceptionHandler();
            var exception = new Exception("Error");
            var commandMock = new Mock<ICommand>();

            // Act
            handler.Handle(exception, commandMock.Object, queue);

            // Assert
            Assert.Single(queue.Commands);
            var retryCommand = queue.Commands.First() as RetryCommand; //проверка через as + null надежнее, чем прямое приведение типов
                                                                       //+ First более устойчив к изменениям
            Assert.NotNull(retryCommand);
            Assert.Equal(commandMock.Object, retryCommand.CommandToRetry);

        }
    }
}
