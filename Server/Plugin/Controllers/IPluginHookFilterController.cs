using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers
{
    public interface IPluginHookFilterController
    {
        Task<object> FilterRun(string name, object initial);
        void FilterAdd(string name, Func<object, Task<object>> action);
        bool FilterContain(string name);
    }
}
