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
        /// Handle string
        /// </summary>
        protected virtual bool StartsWith(string a, string b)
        {
            return a.StartsWith(b);
        }

        /// <summary>
        /// Evaluate 2 Values passed based on its type, you should refer to official documentation for understanding how certain types are evaluated.
        /// </summary>
        /// <param name="a">Value 1</param>
        /// <param name="b">Value 2 (Always String)</param>
        /// <param name="dataType">Data Type (generic primitive like Guid, Int, Float, Double, String...)</param>
        protected virtual bool StartsWith(object a, string b, Type dataType)
        {
            if (dataType.Equals(typeof(string)))
            {
                return StartsWith(a.ToString(), b);
            }
            else if (dataType.Equals(typeof(int)))
            {
                return StartsWith(a.ToString(), b);
            }
            else if (dataType.Equals(typeof(float)))
            {
                return StartsWith(a.ToString(), b);
            }
            else if (dataType.Equals(typeof(double)))
            {
                return StartsWith(a.ToString(), b);
            }
            else if (dataType.Equals(typeof(bool)))
            {
                return StartsWith(a.ToString(), b);
            }
            else if (dataType.Equals(typeof(long)))
            {
                return StartsWith(a.ToString(), b);
            }

            throw new Exception($"Function LesserThan doesn't support type {dataType}. See Documentation for more details.");
        }
    }
}
