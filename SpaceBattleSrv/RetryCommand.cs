using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class RetryCommand : ICommand
    {
        public ICommand CommandToRetry { get; }

        public RetryCommand(ICommand commandToRetry)
        {
            CommandToRetry = commandToRetry;
        }

        public void Execute() => CommandToRetry.Execute();
    }
}
