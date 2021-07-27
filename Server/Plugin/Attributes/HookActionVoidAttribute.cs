using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HookActionVoidAttribute : Attribute
    {        
        public string Name { get; set; }
        public HookActionVoidAttribute(string name){
            Name = name;
        }
    }
}
