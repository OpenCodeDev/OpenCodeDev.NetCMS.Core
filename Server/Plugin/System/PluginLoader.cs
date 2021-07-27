using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenCodeDev.NetCMS.Core.Server.Plugin.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.System
{
    public class PluginLoader
    {
        /// <summary>
        /// Create "dependencies.json" if doesn't exist. get list of all plugins added via the admin dashboad.
        /// </summary>
        public List<PluginPackageInfo> Lookup()
        {
            string pluginFile = $"{Directory.GetCurrentDirectory()}\\dependencies.json";
            List<PluginPackageInfo> pluginList = new List<PluginPackageInfo>();

            if (!File.Exists(pluginFile)) { File.WriteAllText(pluginFile, "[]"); }
            else
            {
                pluginList = JsonSerializer
                .Deserialize<List<PluginPackageInfo>>(File.ReadAllText(pluginFile));
            }
            return pluginList;
        }

        /// <summary>
        /// Get Plugin Entry Points (Must Provide with Plugin List)
        /// </summary>
        public List<Type> GetEntryPoints(List<PluginPackageInfo> pluginList)
        {
            pluginList = pluginList == null ? new List<PluginPackageInfo>() : pluginList;
            return pluginList
            .Select(plug => Assembly.Load(plug.Assembly)
                .GetTypes()
                .Where(p => p.Name.Equals("Main") && p.IsSubclassOf(typeof(PluginServerBase)) && !p.IsAbstract && p.IsPublic)
                .Single())
                .ToList();

        }

        /// <summary>
        /// Get Plugin Entry Points (Will Call PluginLookup() for List)
        /// </summary>
        public List<Type> GetEntryPoints()
        {
            return GetEntryPoints(Lookup());
        }

        /// <summary>
        /// Validate Type list is plugin entry point with good format.
        /// </summary>
        /// <param name="types">List of types</param>
        /// <param name="throwOnFailed">Default: False</param>
        /// <returns></returns>
        public List<Type> ValidateEntryTypeList(List<Type> types, bool throwOnFailed = false)
        {
            List<Type> valid = new List<Type>();
            foreach (var type in types)
            {
                if (!type.IsSubclassOf(typeof(PluginServerBase)))
                {
                    if (throwOnFailed)
                        throw new Exception($"Plugin: {type.FullName} type must inherit PluginServerBase.");
                    else
                        break;
                }

                if (type.IsAbstract)
                {
                    if (throwOnFailed)
                        throw new Exception($"Plugin: {type.FullName} type must be concrete class derived of PluginServerBase.");
                    else
                        break;
                }

                if (!type.IsPublic)
                {
                    if (throwOnFailed)
                        throw new Exception($"Plugin: {type.FullName} type must be public class derived of PluginServerBase.");
                    else
                        break;
                }
                valid.Add(type);
            }
            return valid;
        }

        /// <summary>
        /// Execute LoadServices() for each given plugin (Must provide type list).
        /// </summary>
        /// <param name="types">List of Types</param>
        /// <param name="services">Ref IServicesColletion</param>
        /// <param name="throwOnFailed">Default: False</param>
        public void LoadServices(List<Type> types, ref IServiceCollection services, bool throwOnFailed = false)
        {
            types = ValidateEntryTypeList(types, throwOnFailed);
            foreach (var type in types)
            {
                PluginServerBase instance = (PluginServerBase)Activator.CreateInstance(type);
                instance.LoadServices(ref services);
            }
        }

        /// <summary>
        /// Execute LoadServices() for each given plugin. (Will Call GetPluginEntryPoints() for List)
        /// </summary>
        /// <param name="services">Ref IServiceCollection</param>
        /// <param name="throwOnFailed">Default: False</param>
        public void LoadServices(ref IServiceCollection services, bool throwOnFailed = false)
        {
            LoadServices(GetEntryPoints(), ref services, throwOnFailed);
        }

        /// <summary>
        /// Run App Configuration
        /// </summary>
        public void LoadApp(List<Type> types, ref IApplicationBuilder app)
        {
            types = ValidateEntryTypeList(types);
            foreach (var type in types)
            {
                PluginServerBase instance = (PluginServerBase)Activator.CreateInstance(type);
                instance.LoadApp(ref app);
            }
        }

        /// <summary>
        /// Run App Configuration
        /// </summary>
        public void LoadApp(ref IApplicationBuilder app)
        {
            LoadApp(GetEntryPoints(), ref app);
        }

    }
}
