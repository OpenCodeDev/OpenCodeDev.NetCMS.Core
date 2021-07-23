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
        protected virtual bool Equals(int a, int b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Handle float
        /// </summary>
        protected virtual bool Equals(float a, float b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Handle boolean
        /// </summary>
        protected virtual bool Equals(bool a, bool b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Handle double
        /// </summary>
        protected virtual bool Equals(double a, double b)
        {
            return a.Equals(b);
        }


        /// <summary>
        /// Handle long
        /// </summary>
        protected virtual bool Equals(long a, long b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Handle string
        /// </summary>
        protected virtual bool Equals(string a, string b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Handle Guids
        /// </summary>
        protected virtual bool Equals(Guid a, Guid b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Evaluate 2 Values passed based on its type, you should refer to official documentation for understanding how certain types are evaluated.
        /// </summary>
        /// <param name="a">Value 1</param>
        /// <param name="b">Value 2 (Always String)</param>
        /// <param name="dataType">Data Type (generic primitive like Guid, Int, Float, Double, String...)</param>
        protected virtual bool Equals(object a, string b, Type dataType)
        {
            if (dataType.Equals(typeof(string)))
            {
                return Equals((string)a, b);
            }
            else if (dataType.Equals(typeof(int)))
            {
                return Equals((int)a, int.Parse(b));
            }
            else if (dataType.Equals(typeof(float)))
            {
                return Equals((float)a, float.Parse(b));
            }
            else if (dataType.Equals(typeof(double)))
            {
                return Equals((double)a, double.Parse(b));
            }
            else if (dataType.Equals(typeof(bool)))
            {
                return Equals((bool)a, bool.Parse(b));
            }
            else if (dataType.Equals(typeof(long)))
            {
                return Equals((long)a, long.Parse(b));
            }
            else if (dataType.Equals(typeof(Guid)))
            {
                return Equals((Guid)a, Guid.Parse(b));
            }
            throw new Exception($"Function LesserThan doesn't support type {dataType}. See Documentation for more details.");
        }
    }
}
