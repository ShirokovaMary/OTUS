using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class RetryTwiceThenLogHandler
    {
        public bool CanHandle(Exception ex, ICommand command)
    => command is not RetryTwiceThenLogCommand; // Чтобы не зациклиться  

        public void Handle(Exception ex, ICommand command, CommandQueue queue)
        {
            if (command is RetryTwiceThenLogCommand retryCommand)
            {
                // Если уже была попытка, логируем  
                queue.AddCommand(new LogExceptionCommand(ex, retryCommand));
            }
            else
            {
                // Первая ошибка → пробуем ещё 2 раза  
                queue.AddCommand(new RetryTwiceThenLogCommand(command));
            }
        }

    }
}
