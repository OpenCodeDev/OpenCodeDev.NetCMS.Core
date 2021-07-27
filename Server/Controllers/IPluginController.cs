using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Plugin
{
    public interface IPluginController
    {

        bool ActionContain(string name);
        Task ActionRegister(string name, Type classType, Func<object[], Task<object>> action);

        Task ActionRegisterVoid(string name, Type classType, Func<object[], Task> action);
        Task<object> ActionExecWithResult(string name, params object[] args);
        Task ActionExecAwaited(string name, params object[] args);
        void ActionExecBackground(string name, params object[] args);
        Task<object> FilterRun(string name, object initial);
        void FilterAdd(string name, Func<object, Task<object>> action);
        bool FilterContain(string name);
    }
}
