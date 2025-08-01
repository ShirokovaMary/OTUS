using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class LogExceptionCommandTests
    {
        [Fact]
        public void Execute_WritesExceptionToLog()
        {
            // Arrange
            var exception = new Exception("Test error");
            var fakeCommand = new FakeCommand();

            var logOutput = new StringWriter();
            Console.SetOut(logOutput);

            var logCommand = new LogExceptionCommand(exception, fakeCommand);

            // Act
            logCommand.Execute();

            // Assert
            var output = logOutput.ToString();
            Assert.Contains("Test error", logOutput.ToString());
            Assert.Contains(nameof(FakeCommand), output);
        }

        private class FakeCommand : ICommand
        {
            public void Execute() { }
        }

    }
}
