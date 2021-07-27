using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Options
{
    public class PluginPackageInfo
    {
        /// <summary>
        /// Package's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Base namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Package version
        /// </summary>
        public string Version { get; set; }
       
        /// <summary>
        /// Last Working Version.
        /// </summary>
        public string VersionLW { get; set; } = null;

        /// <summary>
        /// Assembly's name. Use to load plugins
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// Unique Hash to identify the package + version
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// True when user has activated the plugin (wordpress style)
        /// </summary>
        public bool Activated { get; set; } = false;

        /// <summary>
        /// Default: True; Register to Automatically receive updates. (Server Restart Required) <br/>
        /// Crash May Occur, if Server crash on next restart due to plugin, then crashing plugin will skip the update and revert to last working version and will disable AutoUpdate then notify admin.
        /// </summary>
        public bool AutoUpdate { get; set; } = true;
    }
}
