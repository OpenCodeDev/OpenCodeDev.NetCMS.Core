using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.JSON
{
    /// <summary>
    /// Single prop used by model.json
    /// </summary>
    public class JProperty
    {
        /// <summary>
        /// Prop's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Prop's full cs type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Prop's default value or initial value.
        /// </summary>
        public string Default { get; set; }
        /// <summary>
        /// Is Prop private or public?
        /// </summary>
        public bool Private { get; set; }
        /// <summary>
        /// Is prop unique in Database? (Such as License Plate, SIN, Email...)
        /// </summary>
        public bool Unique { get; set; }
        /// <summary>
        /// Is prop a Server Side Only? (used for password or sensitive information) <br/>
        /// Prop will never be returned to the user.
        /// </summary>
        public bool ServerSideOnly { get; set; }
        /// <summary>
        /// When can we provide the prop ? <br/>
        /// Create: During creation, prop can be passed to be set. <br/>
        /// Update: During update, prop can be passed to be changed. <br/>
        /// Fetch: During fetch, prop can be passed to search for an entry.
        /// </summary>
        public List<string> ArgumentOf { get; set; }

        /// <summary>
        /// List of Attributes (Data Annotation) on this prop.
        /// </summary>
        public List<JAttribute> Attributes { get; set; }
    }
}
