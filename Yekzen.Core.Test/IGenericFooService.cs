using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Test
{
    public interface IGenericFooService<T>
    {
        T Value { get; set; }
    }
}
