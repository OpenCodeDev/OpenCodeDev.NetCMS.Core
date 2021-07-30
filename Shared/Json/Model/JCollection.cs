using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.JSON
{
    /// <summary>
    /// Information about the model such as name, creation date, last update...
    /// </summary>
    public class JCollection
    {
        /// <summary>
        /// Name of the model (API)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// True: entries is owned by user
        /// </summary>
        public bool HasOwner{ get; set; }

        /// <summary>
        /// True: Api Endpoints are accessible only internally (winthin the server any external call will throw unimplemented)
        /// </summary>
        public bool Internal { get; set; }

        /// <summary>
        /// Domain of this model (base namespace)
        /// </summary>
        public string Domain { get; set; }
    }
}
