using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options
{
    public class LoadPluginOptions
    {
        /// <summary>
        /// Disable only for development of plugins (<b>huge security risk</b>) <br/>
        /// Default: true. All plugin's signature are verified against OpenCodeDev's database.<br/>
        /// Unsigned plugins for production environment is dangerous due to the fact that we cannot ensure the plugin has not been tampered with.
        /// </summary>
        public bool UseSecurePluginOnly { get; set; } = true;

        

         
    }
}
