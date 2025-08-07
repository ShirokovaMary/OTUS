using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface IExceptionHandler
    {
        bool CanHandle(Exception ex, ICommand command);
        void Handle(Exception ex, ICommand command, CommandQueue queue);
    }
}
