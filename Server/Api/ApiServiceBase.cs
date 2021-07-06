using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCodeDev.NetCMS.Core.Shared.Api.Messages;
namespace OpenCodeDev.NetCMS.Core.Server.Api
{
    public partial class ApiServiceBase 
    {
       
        /// <summary>
        /// Delegate to the correct eval function based on condition type.
        /// </summary>
        /// <param name="conditionType">Condition Type</param>
        /// <param name="a">First Object</param>
        /// <param name="b">Value String</param>
        /// <param name="typef">Type of Data (int, float, double...)</param>
        protected virtual bool ConditionTypeDelegator(ConditionTypes conditionType, object a, string b, Type typef)
        {
            switch (conditionType)
            {
                case ConditionTypes.Contains:
                    return Contains(a, b, typef);
                case ConditionTypes.EndsWith:
                    return Endswith(a, b, typef);
                case ConditionTypes.StartsWith:
                    return StartsWith(a, b, typef);
                case ConditionTypes.Equals:
                    return Equals(a, b, typef);
                case ConditionTypes.GreaterThan:
                    return GreaterThan(a, b, typef);
                case ConditionTypes.LesserThan:
                    return LesserThan(a, b, typef);
                case ConditionTypes.GreaterEqualThan:
                    return (Equals(a, b, typef) || GreaterThan(a, b, typef));
                case ConditionTypes.LesserEqualThan:
                    return (Equals(a, b, typef) || LesserThan(a, b, typef));
                default:
                    break;
            }
            return false;
        }


    }
}
