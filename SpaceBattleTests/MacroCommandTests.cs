using Moq;
using SpaceBattleSrv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleTests
{
    public class MacroCommandTests : MacroCommand
    {

        [Fact]
        public void Execute_RunsAllCommands_WhenNoExceptions()
        {
            // Arrange
            var command1 = new Mock<ICommand>();
            var command2 = new Mock<ICommand>();
            var command3 = new Mock<ICommand>();

            var macroCommand = new MacroCommand(
                command1.Object,
                command2.Object,
                command3.Object);

            // Act
            macroCommand.Execute();

            // Assert
            command1.Verify(c => c.Execute(), Times.Once);
            command2.Verify(c => c.Execute(), Times.Once);
            command3.Verify(c => c.Execute(), Times.Once);
        }


        [Fact]
        public void Execute_StopsOnFirstException_AndThrowsCommandException()
        {
            // Arrange
            var command1 = new Mock<ICommand>();
            var failingCommand = new Mock<ICommand>();
            var command3 = new Mock<ICommand>();

            var expectedException = new InvalidOperationException("Test failure");
            failingCommand.Setup(c => c.Execute()).Throws(expectedException);

            var macroCommand = new MacroCommand(
                command1.Object,
                failingCommand.Object,
                command3.Object);

            // Act
            var exception = Assert.Throws<CommandException>(() => macroCommand.Execute());

            // Assert
            command1.Verify(c => c.Execute(), Times.Once);
            command3.Verify(c => c.Execute(), Times.Never);

            Assert.Same(expectedException, exception.InnerException);
            Assert.Equal("Macro command execution failed", exception.Message);
        }


        [Fact]
        public void Execute_ThrowsCommandException_WithOriginalExceptionData()
        {
            // Arrange
            var failingCommand = new Mock<ICommand>();
            var originalException = new InvalidOperationException("Test");
            originalException.Data.Add("Key", "Value");
            failingCommand.Setup(c => c.Execute()).Throws(originalException);

            var macroCommand = new MacroCommand(failingCommand.Object);

            // Act
            var exception = Assert.Throws<CommandException>(() => macroCommand.Execute());

            // Assert
            Assert.Equal("Value", exception.InnerException.Data["Key"]);
        }

        [Fact]
        public void Execute_PreservesCommandOrder_WhenNoExceptions()
        {
            // Arrange
            var executionOrder = 0;
            var command1 = new Mock<ICommand>();
            var command2 = new Mock<ICommand>();

            command1.Setup(c => c.Execute()).Callback(() => Assert.Equal(1, ++executionOrder));
            command2.Setup(c => c.Execute()).Callback(() => Assert.Equal(2, ++executionOrder));

            var macroCommand = new MacroCommand(command1.Object, command2.Object);

            // Act
            macroCommand.Execute();

            // Assert
            Assert.Equal(2, executionOrder);
        }

        [Fact]
        public void Constructor_ThrowsArgumentNullException_WhenCommandsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MacroCommand(null));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_WhenAnyCommandIsNull()
        {
            var validCommand = new Mock<ICommand>().Object;
            Assert.Throws<ArgumentException>(() => new MacroCommand(validCommand, null));
        }
    }
}
