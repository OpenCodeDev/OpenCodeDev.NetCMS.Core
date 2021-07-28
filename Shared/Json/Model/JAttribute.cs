using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.JSON
{
    /// <summary>
    /// Represent a single attribute used in model.json
    /// </summary>
    public class JAttribute
    {
        /// <summary>
        /// Attribute's name (Eg: "ProtoContract", "Required", "RegularExpression"...)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value inside Attribute's "()" <br/>
        /// Eg: = "1" -> [ProtoContract(1)] or [Required(1)]... <br/>
        /// Eg: = "1, ErrorMessage = \"Error X Message Blah Blah and Blah\"" -> [ProtoContract(1, ErrorMessage = "Error X Message Blah Blah and Blah")]
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}
