using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class RetryCommandTests
    {
        [Fact]
        public void Execute_RetriesOriginalCommand()
        {
            // Arrange
            var originalCommandMock = new Mock<ICommand>();
            var retryCommand = new RetryCommand(originalCommandMock.Object);

            // Act
            retryCommand.Execute();

            // Assert
            originalCommandMock.Verify(c => c.Execute(), Times.Once);
        }
    }
}
