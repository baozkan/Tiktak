﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core.Settings
{
    public interface ISettingsProvider
    {
        TSetting Get<TSetting>() where TSetting : class;
    }
}
