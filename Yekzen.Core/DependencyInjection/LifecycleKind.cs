﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.DependencyInjection
{
    public enum LifecycleKind
    {
        Singleton,
        Scoped,
        Transient
    }
}
