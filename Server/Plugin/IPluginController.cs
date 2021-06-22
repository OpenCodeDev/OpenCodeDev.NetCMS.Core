using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Plugin
{
    public interface IPluginController
    {

        /// <summary>
        /// Check if action is currently registered.
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <returns></returns>
        Task<bool> ActionContain(string name);

        /// <summary>
        /// Check synchronously if action is currently register
        /// </summary>
        /// <param name="name">Name of the action.</param>
        /// <returns></returns>
        bool ActionContainSync(string name);

        /// <summary>
        /// Execute a registered action
        /// </summary>
        /// <param name="name">Name of the action</param>
        /// <param name="args">Args, null if none</param>
        /// <returns></returns>
        Task ActionExec(string name, dynamic args);
        /// <summary>
        /// Execute synchronously a register action.
        /// </summary>
        /// <param name="name">Name of the action</param>
        /// <param name="args">Args, null if none</param>
        void ActionExecSync(string name, dynamic args);

        /// <summary>
        /// Check if a filter is currently registered.
        /// </summary>
        /// <param name="name">Name of the filter</param>
        Task<bool> FilterContain(string name);
        /// <summary>
        /// Check Synchronously if a filter is currently registered.
        /// </summary>
        /// <param name="name">Name of the filter</param>
        bool FilterContainSync(string name);

        /// <summary>
        /// Run a registered filter.
        /// </summary>
        /// <param name="name">Name of the filter.</param>
        /// <param name="args">Possible arguments</param>
        Task<object> FilterApply(string name, List<object> args);
        /// <summary>
        /// Run synchronously a registered filter.
        /// </summary>
        /// <param name="name">Name of the filter.</param>
        /// <param name="args">Possible arguments</param>
        object FilterApplySync(string name, List<object> args);


    }
}
