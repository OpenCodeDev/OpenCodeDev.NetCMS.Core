﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Plugin.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HookActionAttribute : Attribute
    {
        public string Name { get; set; }
        public HookActionAttribute(string name)
        {
            Name = name;
        }
    }
}