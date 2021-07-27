using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Attributes;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin
{
    /// <summary>
    /// 
    /// </summary>
    public class PluginServerBase
    {
        /// <summary>
        /// Common Singleton Across All Plugins, to Request other plugin or services.
        /// </summary>
        public static IServiceProvider Provider { get; private set; }

        /// <summary>
        /// Load the Action Hooks
        /// </summary>
        private void LoadStaticHookAction()
        {
            var pluginCtrl = Provider.GetRequiredService<IPluginController>();
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookActionAttribute), false).Length > 0 && m.IsStatic && m.IsPublic)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(object) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object))
                {
                    throw new Exception($"The method {method.Name}");
                }
                HookActionAttribute attr = (HookActionAttribute)method.GetCustomAttribute(typeof(HookActionAttribute));
                Func<object[], Task<object>> result = Expression.Lambda<Func<object[], Task<object>>>(Expression.Call(method)).Compile();
                pluginCtrl.ActionRegister(attr.Name, method.GetType(), result);
            }
        }
        
        /// <summary>
        /// Load the Action Hooks for Void Methods
        /// </summary>
        private void LoadStaticHookActionVoid()
        {
            var pluginCtrl = Provider.GetRequiredService<IPluginController>();
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookActionVoidAttribute), false).Length > 0 && m.IsStatic && m.IsPublic)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(object) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object))
                {
                    throw new Exception($"The method {method.Name}");
                }
                HookActionVoidAttribute attr = (HookActionVoidAttribute)method.GetCustomAttribute(typeof(HookActionVoidAttribute));
                Func<object[], Task> result = Expression.Lambda<Func<object[], Task>>(Expression.Call(method)).Compile();
                pluginCtrl.ActionRegisterVoid(attr.Name, method.GetType(), result);
            }
        }

        /// <summary>
        /// Load All Static Filter Methods 
        /// </summary>
        private void LoadStaticFilters()
        {
            var pluginCtrl = Provider.GetRequiredService<IPluginController>();
            var methods = this.GetType().Assembly.GetTypes()
                       .SelectMany(t => t.GetMethods())
                       .Where(m => m.GetCustomAttributes(typeof(HookFilterAttribute), false).Length > 0 && m.IsStatic && m.IsPublic)
                       .ToArray();
            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(object) ||
                method.GetParameters().Length <= 0 ||
                method.GetParameters()[0].ParameterType != typeof(object))
                {
                    throw new Exception($"The method {method.Name}");
                }
                HookFilterAttribute attr = (HookFilterAttribute) method.GetCustomAttribute(typeof(HookFilterAttribute));
                Func<object, Task<object>> result = Expression.Lambda<Func<object, Task<object>>>(Expression.Call(method)).Compile();
                pluginCtrl.FilterAdd(attr.Name, result);
            }
        }

        /// <summary>
        /// Call to setup the plugin's services
        /// </summary>
        /// <param name="services"></param>
        public virtual void LoadServices(ref IServiceCollection services){

        }

        /// <summary>
        /// Configure Web Application (Add Endpoints, Get Services...)
        /// </summary>
        public virtual void LoadApp(ref IApplicationBuilder app)
        {
            Provider = Provider == null ? app.ApplicationServices.GetRequiredService<IServiceProvider>() : Provider;
            Load();
        }

        /// <summary>
        /// Remove plugin and its related data (especially secure data)
        /// </summary>
        public virtual void Uninstall(){

        }

        /// <summary>
        /// Load Data (Once at Server Start) <br/>
        /// Load Static Hooks Action and Filters (Wordpress Style)
        /// </summary>
        public virtual void Load()
        {
            // Register Singleton Plugin
            var pluginCtrl = Provider.GetRequiredService<IPluginController>();
            pluginCtrl.PluginRegister(this);
            Load();

            // Load Static Hooks
            LoadStaticHookAction();
            LoadStaticHookActionVoid();
            LoadStaticFilters();
        }



    }
}
