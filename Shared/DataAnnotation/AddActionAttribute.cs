using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Plugin.Core.DataAnnotation
{
    /// <summary>
    /// Overrides are fully support
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AddActionAttribute: Attribute
    {
        public string ActionName { get; set; }
        public string ReflectionFunc { get; set; }
        /// <summary>
        /// System will look up at activation if fails th whole plugin is disabled and cannot be activated.
        /// </summary>
        /// <param name="action">Registered Action Name</param>
        /// <param name="methodname">Current Method Name (Must be Exact: "MyPluginMethod")</param>
        public AddActionAttribute(string action, string methodname){
            ActionName = action;
            ReflectionFunc = methodname;
        }
    }
}
