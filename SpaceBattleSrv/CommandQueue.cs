using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class CommandQueue
    {
        private readonly Queue<ICommand> _commands = new();
        private readonly List<IExceptionHandler> _exceptionHandlers = new();
        public IReadOnlyCollection<ICommand> Commands => _commands.ToList().AsReadOnly();
        public void AddCommand(ICommand command) => _commands.Enqueue(command);
        public void AddHandler(IExceptionHandler handler) => _exceptionHandlers.Add(handler);

        public void ProcessQueue()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    var handler = _exceptionHandlers.FirstOrDefault(h => h.CanHandle(ex, command));
                    handler?.Handle(ex, command, this);
                }
            }
        }
    }
}
