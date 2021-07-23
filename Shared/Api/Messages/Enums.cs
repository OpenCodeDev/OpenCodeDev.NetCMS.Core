using System;
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

    public enum OrderType
    {
        Ascending,
        Descending
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
        /// <summary>
        /// And will start a new set: (Set1) & (Set2) OR (Set1) & (Set2 || Set3) <br/>
        /// if you choose and it means a new set and also all the AndAlso or OrElse will be part of that new set.
        /// </summary>
        And,
        /// <summary>
        /// AndAlso is && operator. (Set1 == "" && Set2 == "") <br/>
        /// A set of condition starts with And or Or and is followed by other condition of the set with AndAlso or OrElse.
        /// </summary>
        AndAlso,
        /// <summary>
        /// Or will start a new set of conditions: (Set1) | (Set2)... <br/>
        /// This is good to chain multiple possible conditions.
        /// </summary>
        Or,
        /// <summary>
        /// AndAlso is || operator. (Set1 == "" || Set2 == "") <br/>
        /// A set of condition starts with And or Or and is followed by other condition of the set with AndAlso or OrElse.
        /// </summary>
        OrElse
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
