using Microsoft.AspNetCore.Builder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCms.Core.Extensions
{
    public static class ServerSetupPluginExt
    {
        /// <summary>
        /// Locate and Find Backend Plugins
        /// </summary>
        public static void UsePlugins(this IApplicationBuilder app) { 
        
        }

        /// <summary>
        /// Locate all plugins and register in Database, If active, Run Setup().
        /// </summary>
        public static void AddPlugins(IServiceCollection services)
        {

        }

    }
}
