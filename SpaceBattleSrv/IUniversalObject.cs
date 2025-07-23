using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public interface IUniversalObject
    {
        public object GetProperty(string property);
        public object SetProperty(string property, object value);
    }
}
