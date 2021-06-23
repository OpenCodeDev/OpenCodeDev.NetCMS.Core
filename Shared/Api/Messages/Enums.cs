﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.Api.Messages
{
    /// <summary>
    /// List of Available Search Functions
    /// </summary>
    public enum ConditionTypes
    {
        Contains,
        EndsWith,
        StartsWith,
        Equals,
        GreaterThan,
        LesserThan,
        GreaterEqualThan,
        LesserEqualThan
    }

    /// <summary>
    /// Type of the Selected Field (will be casted and if fails will throw a validation error)
    /// </summary>
    public enum FieldTypes
    {
        String,
        Int,
        Float,
        Double,
        Bool,
        Guid,
        Long
    }

    /// <summary>
    /// Logic thant will be use to transpile And = &&, Or = ||, End = None, Null;
    /// </summary>
    public enum LogicTypes
    {
        And,
        Or,
        End
    }

    /// <summary>
    /// Used to explicitly load a specific reference
    /// </summary>
    public enum ReferenceFetchBehavior{
        Load,
        Ignore
    }
    
    /// <summary>
    /// Used to define the logic to follow while processing references
    /// </summary>
    public enum ReferenceEditBehavior{
        Process,
        Ignore
    }
}
