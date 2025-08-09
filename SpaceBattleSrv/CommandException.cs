using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class CommandException : Exception
    {
        public CommandException() : base() { }

        public CommandException(string? message) : base(message) { }

        public CommandException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
