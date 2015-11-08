using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Core
{
    public class DictionarySettingProvider : Yekzen.Core.Settings.ISettingsProvider
    {
        private readonly IDictionary<int, object> settings;

        public DictionarySettingProvider(IDictionary<int,object> settings)
        {
            this.settings = settings;
        }

        public TSetting Get<TSetting>() where TSetting : class
        {
            var key = typeof(TSetting).GetHashCode();
            return (TSetting)settings[key];
        }
    }
}
