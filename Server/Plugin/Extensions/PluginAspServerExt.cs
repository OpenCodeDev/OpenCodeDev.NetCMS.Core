using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Options;
using OpenCodeDev.NetCMS.Core.Server.Plugin.System;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Options.Controllers;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Extensions
{

    public static class PluginAspServerExt
    {

        /// <summary>
        /// Locate and Register All Plugin Services.
        /// </summary>
        public static void AddPlugins(this IServiceCollection services, Action<LoadPluginOptions> options)
        {
            var _options = new LoadPluginOptions();
            options.Invoke(_options);

            // If IPluginController is not available, register it.
            if (!services.Any(x => x.ServiceType == typeof(IPluginController)))
            {
                services.AddSingleton<IPluginController, PluginController>();
            }

            PluginLoader loader = new PluginLoader();
            loader.LoadServices(ref services);

        }

        /// <summary>
        /// Add a single plugin (Useful to load plugin via code instead of dashboard)
        /// </summary>
        /// <typeparam name="T">Main Class (derived from PluginServerBase) of the target plugin</typeparam>
        public static void AddPlugins<T>(this IServiceCollection services)
        {

            PluginLoader loader = new PluginLoader();
            loader.LoadServices(new List<Type>() { typeof(T) },  ref services);

        }

        /// <summary>
        /// Use All Plugins (Added via Dashboard)
        /// </summary>
        public static void UsePlugins(this IApplicationBuilder app)
        {
            PluginLoader loader = new PluginLoader();
            loader.LoadApp(ref app);
        }
        
        /// <summary>
        /// Use a specific plugin (Useful to load plugin via code instead of dashboard)
        /// </summary>
        /// <typeparam name="T">Main Class (derived from PluginServerBase) of the target plugin</typeparam>
        public static void UsePlugins<T>(this IApplicationBuilder app)
        {
            PluginLoader loader = new PluginLoader();
            loader.LoadApp(new List<Type>() { typeof(T) }, ref app);
        }

    }
}
