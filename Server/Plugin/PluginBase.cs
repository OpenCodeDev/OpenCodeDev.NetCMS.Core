using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OpenCodeDev.NetCMS.Core.Plugin
{
    /// <summary>
    /// Plugins should be signed, the NetCMS core system will validate the plugin signature with the remote plugin on NetCMS package server to ensure integraty against tamper or license removal.
    /// </summary>
    public class PluginBase
    {
        /// <summary>
        /// Common Singleton Across All Plugins, to Request other plugin or services.
        /// </summary>
        public static IServiceProvider Provider { get; set; }
        /// <summary>
        /// Common Singleton Across All Plugins to call plugin core functionalities.
        /// </summary>
        public static IPluginController PluginCtrl { get; set; }

        /// <summary>
        /// Called Before _INIT_, First thing Called
        /// </summary>
        public void Setup(IServiceProvider provider){
            Provider = Provider == null ? provider : Provider;
            PluginCtrl = PluginCtrl == null ? Provider.GetService<IPluginController>() : PluginCtrl;
        }
    }
}
