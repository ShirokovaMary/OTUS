using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class RetryTwiceThenLogCommandTests
    {
        [Fact]
        public void Execute_RetriesTwiceThenLogs_OnThirdFailure()
        {
            // Arrange
            var executionCount = 0;
            var logOutput = new StringWriter();
            Console.SetOut(logOutput);

            var failingCommand = new Mock<ICommand>();
            failingCommand.Setup(c => c.Execute())
                .Callback(() => {
                    executionCount++;
                    throw new Exception($"Attempt {executionCount} failed");
                });

            var retryCommand = new RetryTwiceThenLogCommand(failingCommand.Object);

            // Act
            var exception = Record.Exception(() => retryCommand.Execute());

            // Assert
            Assert.Null(exception); // Не должно быть исключения на верхнем уровне
            failingCommand.Verify(c => c.Execute(), Times.Exactly(2)); // 2 попытки выполнения

            // Проверяем что было логирование
            var log = logOutput.ToString();
            Assert.Contains("Attempt 2 failed", log); // Сообщение из последней попытки
            Assert.Contains(failingCommand.Object.GetType().Name, log); // Тип команды в логе

        }
    }
}
