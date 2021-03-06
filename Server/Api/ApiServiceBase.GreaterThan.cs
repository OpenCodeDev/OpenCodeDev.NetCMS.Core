using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using OpenCodeDev.NetCMS.Core.Shared.Api.Messages;
namespace OpenCodeDev.NetCMS.Core.Server.Api
{
    public partial class ApiServiceBase
    {

        /// <summary>
        /// Handle int
        /// </summary>
        protected virtual bool GreaterThan(int a, int b)
        {
            return a > b;
        }

        /// <summary>
        /// Handle float
        /// </summary>
        protected virtual bool GreaterThan(float a, float b)
        {
            return a > b;
        }

        /// <summary>
        /// Handle boolean
        /// </summary>
        protected virtual bool GreaterThan(bool a, bool b)
        {
            return (a == true && b == false);
        }

        /// <summary>
        /// Handle double
        /// </summary>
        protected virtual bool GreaterThan(double a, double b)
        {
            return a > b;
        }


        /// <summary>
        /// Handle long
        /// </summary>
        protected virtual bool GreaterThan(long a, long b)
        {
            return a > b;
        }

        /// <summary>
        /// Handle string
        /// </summary>
        protected virtual bool GreaterThan(string a, string b)
        {
            return a.Length > b.Length;
        }

        /// <summary>
        /// Evaluate 2 Values passed based on its type, you should refer to official documentation for understanding how certain types are evaluated.
        /// </summary>
        /// <param name="a">Value 1</param>
        /// <param name="b">Value 2 (Always String)</param>
        /// <param name="dataType">Data Type (generic primitive like Guid, Int, Float, Double, String...)</param>
        protected virtual bool GreaterThan(object a, string b, Type dataType)
        {
            if (dataType.Equals(typeof(string)))
            {
                return GreaterThan((string)a, b);
            }
            else if (dataType.Equals(typeof(int)))
            {
                return GreaterThan((int)a, int.Parse(b));
            }
            else if (dataType.Equals(typeof(float)))
            {
                return GreaterThan((float)a, float.Parse(b));
            }
            else if (dataType.Equals(typeof(double)))
            {
                return GreaterThan((double)a, double.Parse(b));
            }
            else if (dataType.Equals(typeof(bool)))
            {
                return GreaterThan((bool)a, bool.Parse(b));
            }
            else if (dataType.Equals(typeof(long)))
            {
                return GreaterThan((long)a, long.Parse(b));
            }
            throw new Exception($"Function GreaterThan doesn't support type {dataType}. See Documentation for more details.");
        }
    }
}
