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
        /// Handle guid
        /// </summary>
        protected virtual bool GreaterThan(Guid a, Guid b)
        {
            return a.GetHashCode() > b.GetHashCode();
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
        protected virtual bool GreaterThan(object a, string b, FieldTypes dataType)
        {
            switch (dataType)
            {
                case FieldTypes.String:
                    return GreaterThan((string)a, (string)b);
                case FieldTypes.Int:
                    return GreaterThan((int)a, int.Parse(b));
                case FieldTypes.Float:
                    return GreaterThan((float)a, float.Parse(b));
                case FieldTypes.Double:
                    return GreaterThan((double)a, double.Parse(b));
                case FieldTypes.Bool:
                    return GreaterThan((bool)a, bool.Parse(b));
                case FieldTypes.Guid:
                    return GreaterThan((Guid)a, Guid.Parse(b));
                case FieldTypes.Long:
                    return GreaterThan((long)a, long.Parse(b));
            }
            return false;
        }
    }
}
