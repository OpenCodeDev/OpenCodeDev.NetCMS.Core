using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers
{
    public interface IPluginController : IPluginHookActionController, IPluginHookFilterController
    {

        bool PluginContain(string name);
        object PluginGetObject(string name);
        PluginServerBase PluginGetBase(string name);
        void PluginRegister(object obj);
        void PluginUnregister(object name);


    }
}
