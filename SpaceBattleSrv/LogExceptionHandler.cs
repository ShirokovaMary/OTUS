using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class LogExceptionHandler
    {
        public bool CanHandle(Exception ex, ICommand command) => true; // Ловит всё  

        public void Handle(Exception ex, ICommand command, CommandQueue queue)
        {
            queue.AddCommand(new LogExceptionCommand(ex, command));
        }
    }
}
