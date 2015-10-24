using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public class NotRegisteredException : Exception
    {
        public Type TargetType { get; private set; }

        public NotRegisteredException(Type targetType) : base(string.Format("'{0}' type not registered.", targetType.FullName)) { }
    }
}
