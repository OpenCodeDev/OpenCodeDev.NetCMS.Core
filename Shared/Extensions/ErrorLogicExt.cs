using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.Extensions
{
    public static class ErrorLogicExt
    {

        /// <summary>
        /// Will throw rpc error whenever specified object is null.
        /// </summary>
        public static T ThrowWhenNull<T>(this object obj, StatusCode code, string message)
        {
            if (obj == null)
            {
                throw new RpcException(new Status(code, message));
            }
            return (T)obj;
        }


        /// <summary>
        /// Throw rpc error when value is false.
        /// </summary>
        public static void ThrowWhenFalse(this bool tester, StatusCode code, string message)
        {
            if (!tester)
            {
                throw new RpcException(new Status(code, message));
            }
        }

        /// <summary>
        /// Throw Rpc Error when value is true
        /// </summary>
        public static void ThrowWhenTrue(this bool tester, StatusCode code, string message)
        {
            if (tester)
            {
                (!tester).ThrowWhenFalse(code, message);
            }
        }
    }
}
