using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers
{
    public interface IPluginHookActionController
    {
        bool ActionContain(string name);
        Task ActionRegister(string name, Type classType, Func<object[], Task<object>> action);
        Task ActionRegisterVoid(string name, Type classType, Func<object[], Task> action);
        Task<object> ActionExecWithResult(string name, params object[] args);
        Task ActionExecAwaited(string name, params object[] args);
        void ActionExecBackground(string name, params object[] args);
    }
}
