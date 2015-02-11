﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yekzen.Core.DependencyInjection;

namespace Yekzen.Core.Unity
{
    public class UnityServiceScopeFactory : IServiceScopeFactory
    {
        public IServiceScope CreateScope()
        {
            
            var serviceScope = new ServiceScope(new UnityServiceProvider());
            return serviceScope;
        }
    }
}
