using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Plugin
{
    /// <summary>
    /// Main Function of the Plugin System.
    /// </summary>
   public class PluginController : IPluginController
    {
        private static Dictionary<string, Func<object[], Task>> ActionsVoid { get; set; } = new Dictionary<string, Func<object[], Task>>();
        private static Dictionary<string, Func<object[], Task<object>>> Actions { get; set; } = new Dictionary<string, Func<object[], Task<object>>>();
        private static Dictionary<string, List<Func<object, Task<object>>>> Filters { get; set; } = new Dictionary<string, List<Func<object, Task<object>>>>();

        /// <summary>
        /// Check if Action Contains Synchronously
        /// </summary>
        /// <param name="name">Function fullname including namespace XXXX.XXX.XXXX.FUNCTION</param>
        public bool ActionContain(string name)
        {
            return (Actions.ContainsKey(name) || ActionsVoid.ContainsKey(name));
        }
       
        /// <summary>
        /// Shouldn't be directly called (use [])<br/>
        /// Register a Method as Action in the system so it can be accessible by other plugins
        /// </summary>
        /// <param name="name">Name of the Action (note: Class namespace will be preppend) </param>
        /// <param name="action">Method Information (Reflection)</param>
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
           
        /// <summary>
        /// Shouldn't be directly called (use [])<br/>
        /// Register a Method as Action in the system so it can be accessible by other plugins
        /// </summary>
        /// <param name="name">Name of the Action (note: Class namespace will be preppend) </param>
        /// <param name="action">Method Information (Reflection)</param>
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

        /// <summary>
        /// Execute an Action returning an object
        /// </summary>
        /// <param name="name">Fullname (including namespace) of the function</param>
        public async Task<object> ActionExecWithResult(string name, params object[] args)
        {
            if (!Actions.ContainsKey(name))
            {
                throw new Exception($"Function {name} is not registered.");
            }
            return await Actions[name](args);
        }

        /// <summary>
        /// Execute Awaiting Task
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arg"></param>
        public async Task ActionExecAwaited(string name, params object[] args)
        {
            if (!ActionsVoid.ContainsKey(name))
            {
                throw new Exception($"Method {name} was not found.");
            }
            await ActionsVoid[name](args);
        }

        /// <summary>
        /// Execute Without Awaiting Task
        /// </summary>
        /// <param name="name">Fullname including namespace.</param>
        /// <param name="arg">Function's argument, by convention function should check types</param>
        public void ActionExecBackground(string name, params object[] args)
        {
            if (!ActionsVoid.ContainsKey(name))
            {
                throw new Exception($"Method {name} was not found.");
            }
            ActionsVoid[name](args);
        }

        /// <summary>
        /// Run a filter to get altered result
        /// </summary>
        /// <param name="name">fullname including namespace ASSEMBLY.STUFFS.CLASS.FILTER</param>
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

        /// <summary>
        /// Add a filter to a given
        /// </summary>
        /// <param name="name">fullname including namespace ASSEMBLY.STUFFS.CLASS.FILTER</param>
        /// <param name="action">Filter Function</param>
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


        /// <summary>
        /// Called when plugin is activated <br/>
        /// Will go through the plugin using reflection and pull out all the functions
        /// </summary>
        public void RegisterActivationHook(){

        }

        
        
    }
}
