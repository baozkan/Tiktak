using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Test
{
    public class GenericFooService<T> : IGenericFooService<T>
    {
        public T Value { get; set; }
    }
}
