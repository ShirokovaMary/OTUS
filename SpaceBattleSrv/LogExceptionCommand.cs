using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class LogExceptionCommand : ICommand
    {
        public ICommand FailedCommand { get; }
        public Exception Exception { get; }

        public LogExceptionCommand(Exception ex, ICommand failedCommand)
        {
            Exception = ex;
            FailedCommand = failedCommand;
        }

        public void Execute()
        {
            Console.WriteLine($"ERROR: Command {FailedCommand.GetType().Name} failed with {Exception.Message}");
        }
    }
}
