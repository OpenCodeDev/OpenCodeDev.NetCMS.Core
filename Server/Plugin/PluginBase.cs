using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Attributes;

namespace OpenCodeDev.NetCMS.Core.Plugin
{
    /// <summary>
    /// 
    /// </summary>
    public class PluginBase
    {
        /// <summary>
        /// Common Singleton Across All Plugins, to Request other plugin or services.
        /// </summary>
        public static IServiceProvider Provider { get; private set; }

        /// <summary>
        /// Common Singleton Across All Plugins to call plugin core functionalities.
        /// </summary>
        public static IPluginController PluginCtrl { get; private set; }

        /// <summary>
        /// Load the Action Hooks
        /// </summary>
        private void LoadHookAction()
        {
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookActionAttribute), false).Length > 0)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(Task<object>) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object[]))
                {
                    throw new Exception($"The method {method.Name}");
                }
            }
        }
        
        /// <summary>
        /// Load the Action Hooks for Void Methods
        /// </summary>
        private void LoadHookActionVoid()
        {
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookActionVoidAttribute), false).Length > 0)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(Task) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object[]))
                {
                    throw new Exception($"The method {method.Name}");
                }
            }
        }

        /// <summary>
        /// Load Filter Methods
        /// </summary>
        private void LoadFilters()
        {
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookFilterAttribute), false).Length > 0)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(object) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object))
                {
                    throw new Exception($"The method {method.Name}");
                }
                PluginCtrl.FilterAdd("", method.);
            }
        }


        /// <summary>
        /// Setup Services (IServiceProvider and IPluginController)<br/>
        /// Override but make sure to base call.
        /// </summary>
        public void Setup(IServiceProvider provider){
            Provider = Provider == null ? provider : Provider;
            PluginCtrl = PluginCtrl == null ? Provider.GetService<IPluginController>() : PluginCtrl;
        }

        
        /// <summary>
        /// Called after Setup
        /// </summary>
        public void Load()
        {
            LoadHookAction();
            LoadHookActionVoid();
            LoadFilters();

        }

        /// <summary>
        /// Called on Plugin's installation (After Setup)<br/>
        /// <i>IPluginController</i> and <i>IServiceProvider</i> are available.
        /// </summary>
        public virtual void Install(){

        }

        /// <summary>
        /// Called when plugin is activated (After Install)
        /// </summary>
        public virtual void Activate(){

        }
        


    }
}
