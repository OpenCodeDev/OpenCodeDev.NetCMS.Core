using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers
{
    /// <summary>
    /// Main Function of the Plugin System.
    /// </summary>
   public class PluginController : IPluginController
    {
        private static Dictionary<string, Func<object[], Task>> ActionsVoid { get; set; } = new Dictionary<string, Func<object[], Task>>();
        private static Dictionary<string, Func<object[], Task<object>>> Actions { get; set; } = new Dictionary<string, Func<object[], Task<object>>>();
        private static Dictionary<string, List<Func<object, Task<object>>>> Filters { get; set; } = new Dictionary<string, List<Func<object, Task<object>>>>();
        private static Dictionary<string, object> Plugins { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Check if plugin is available
        /// </summary>
        /// <param name="name">Assembly's name</param>
        public bool PluginContain(string name){
            return Plugins.ContainsKey(name);
        }

        /// <summary>
        /// Get Plugin Server Base Object
        /// </summary>
        /// <param name="name">Assembly's name</param>
        public PluginServerBase PluginGetBase(string name){
            return (PluginServerBase)PluginGetObject(name);
        }

        /// <summary>
        /// Get Object that Must be Casted to known type <br/>
        /// The object will be the class Main in the plugin which is derived of PluginServerBase.
        /// </summary>
        /// <param name="name">Assembly's name</param>
        public object PluginGetObject(string name){
            if (!Plugins.ContainsKey(name))
            {
                throw new Exception($"Plugin {name} is not registered.");
            }
            return Plugins[name];
        }

        /// <summary>
        /// Register plugin to be globally accessible.
        /// </summary>
        /// <param name="obj">Main class type (derived from PluginServerBase)</param>
        public void PluginRegister(object obj){
            string name = obj.GetType().Assembly.GetName().Name;
            if (Plugins.ContainsKey(name))
            {
                throw new Exception($"Plugin {name} is already registered. You cannot add twice the same plugin.");
            }
            Plugins.Add(name, obj);
        }
        
        /// <summary>
        /// Unregister Plugin from active list.
        /// </summary>
        public void PluginUnregister(object obj)
        {
            string name = obj.GetType().Assembly.GetName().Name;
            if (Plugins.ContainsKey(name))
            { 
            Plugins.Remove(name); 
            }
           
        }
        
        public bool ActionContain(string name)
        {
            return (Actions.ContainsKey(name) || ActionsVoid.ContainsKey(name));
        }
        public async Task ActionRegister(string name, Type classType, Func<object[], Task<object>> action)
        {
            await Task.Run(() =>
            {
                name = $"{classType}.{name}";
                if (ActionContain(name))
                {
                    ActionsVoid[name] = action;
                }
                else
                {
                    ActionsVoid.Add(name, action);
                }
            });
        }
        public async Task ActionRegisterVoid(string name, Type classType, Func<object[], Task> action)
        {
            await Task.Run(()=> { 
                name = $"{classType}.{name}";
                if (ActionContain(name))
                {
                    ActionsVoid[name] = action;
                }
                else
                {
                    ActionsVoid.Add(name, action);
                }
            });

        }
        public async Task<object> ActionExecWithResult(string name, params object[] args)
        {
            if (!Actions.ContainsKey(name))
            {
                throw new Exception($"Function {name} is not registered.");
            }
            return await Actions[name](args);
        }
        public async Task ActionExecAwaited(string name, params object[] args)
        {
            if (!ActionsVoid.ContainsKey(name))
            {
                throw new Exception($"Method {name} was not found.");
            }
            await ActionsVoid[name](args);
        }
        public void ActionExecBackground(string name, params object[] args)
        {
            if (!ActionsVoid.ContainsKey(name))
            {
                throw new Exception($"Method {name} was not found.");
            }
            ActionsVoid[name](args);
        }
        public async Task<object> FilterRun(string name, object initial){
            if (FilterContain(name))
            {
                throw new Exception("Fitler {name} cannot be found.");
            }
            object final = initial;
            foreach (var filter in Filters[name])
            {
                final = await filter(final);
            }
            return final;
        }
        public void FilterAdd(string name, Func<object, Task<object>> action)
        {
            if (!FilterContain(name))
            {
                Filters.Add(name, new List<Func<object, Task<object>>>() { action });
            }else{
                Filters[name].Add(action);
            }

        }
        public bool FilterContain(string name)
        {
            return Filters.ContainsKey(name);
        }

    }
}
