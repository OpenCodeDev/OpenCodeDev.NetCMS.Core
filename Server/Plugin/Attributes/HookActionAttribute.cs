using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Attributes
{
    /// <summary>
    /// This Hook is for public static method only which is globally accessible.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class HookActionAttribute : Attribute
    {
        public string Name { get; set; }
        public HookActionAttribute(string name)
        {
            Name = name;
        }
    }
}
