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
        protected virtual bool ConditionTypeDelegator(ConditionTypes conditionType, object a, string b, FieldTypes typef)
        {
            switch (conditionType)
            {
                case ConditionTypes.Contains:
                    break;
                case ConditionTypes.EndsWith:
                    break;
                case ConditionTypes.StartsWith:
                    break;
                case ConditionTypes.Equals:
                    break;
                case ConditionTypes.GreaterThan:
                    return GreaterThan(a, b, typef);
                case ConditionTypes.LesserThan:
                    break;
                case ConditionTypes.GreaterEqualThan:
                    break;
                case ConditionTypes.LesserEqualThan:
                    break;
                default:
                    break;
            }
            return false;
        }


    }
}
