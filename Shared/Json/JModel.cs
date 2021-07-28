using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.JSON
{
    /// <summary>
    /// Represent Model.JSON, Necessary to Build Relationships
    /// </summary>
    [Serializable]
    public class JModel
    {
        /// <summary>
        /// Collection information representing the Model.
        /// </summary>
        public JCollection Collection { get; set; }
        /// <summary>
        /// Attributes (data annotation) used by Public Model 
        /// </summary>
        public List<JAttribute> Attributes { get; set; }
        /// <summary>
        /// Using namespaces used by the Public Model.
        /// </summary>
        public List<string> Usings { get; set; }
        /// <summary>
        /// Properties included in Private and Public Model.
        /// </summary>
        public List<JProperty> Properties { get; set; }
        /// <summary>
        /// Relationship included in Private and Public Model.
        /// </summary>
        public List<JRelation> Relations { get; set; }
    }
}
