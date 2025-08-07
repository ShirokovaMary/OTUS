using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class MacroCommand : ICommand
    {
        ICommand[] _commands;

        public MacroCommand(params ICommand[] commands)
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            if (commands.Any(c => c == null))
                throw new ArgumentException("Command array contains null elements", nameof(commands));

            _commands = commands;
        }
        public void Execute()
        {
            foreach (var command in _commands)
            {
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    throw new CommandException("Macro command execution failed", ex);
                }
            }
        }
    }
}
