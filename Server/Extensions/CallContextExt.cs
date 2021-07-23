using Grpc.Core;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Server.Extensions
{
    public static class CallContextExt
    {
        /// <summary>
        /// if server setting are set, will log the error in plugin's log file.<br/>
        /// if in Debug when log is called, console message will be printed.
        /// </summary>
        /// <param name="message">Log message (usually plain exception message)</param>
        public static CallContext LogError(this CallContext context, string message) {
            string error = $"[{DateTime.Now}] ERROR -> {message}";
            #if DEBUG
                Console.WriteLine(error);
            #endif
            //TODO: Write error in actual file.
            return context;
        }



        private static RpcException CreateRpcException(StatusCode stat, string message)
        {
            return new RpcException(new Status(stat, message));
        }

        /// <summary>
        /// The action is not implemented or available on this service.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorUnimplemented(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Unimplemented, message);
        }

        /// <summary>
        /// The action is currently not available on the this service.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorUnavailable(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Unavailable, message);
        }

        /// <summary>
        /// Error has occured during action, therefore it wasn't able to complete.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorAborted(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Aborted, message);
        }

        /// <summary>
        /// Entry, Query, File already exist?.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorAlreadyExists(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.AlreadyExists, message);
        }

        /// <summary>
        /// Most likely cancelled by the client.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorCancelled(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Cancelled, message);
        }

        /// <summary>
        /// Data related to the action was loss or corrupted?
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorDataLoss(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.DataLoss, message);
        }

        /// <summary>
        /// Timeout, action took too long or related service didn't responded quick enough.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorDeadlineExceeded(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.DeadlineExceeded, message);
        }

        /// <summary>
        /// Precondition has failed, like form validation? or maybe system is not ready?.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorFailedPrecondition(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.FailedPrecondition, message);
        }

        /// <summary>
        /// Internal error, underlying system error.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorInternal(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Internal, message);
        }

        /// <summary>
        /// Possibly invalid form validation or data provided are invalid like password conditions.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorInvalidArgument(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.InvalidArgument, message);
        }

        /// <summary>
        /// Self-Explanatory ? Not Found... Entry, Resource, File....
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorNotFound(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.NotFound, message);
        }

        /// <summary>
        /// Well... thats out of range! oooh i see maybe if i limit number of x relation?
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorOutOfRange(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.OutOfRange, message);
        }

        /// <summary>
        /// Not allowed to perform the requested action!
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorPermissionDenied(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.PermissionDenied, message);
        }

        /// <summary>
        /// Reached system capacity? or... reached your service capacity or/and... api rate hit?.
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorResourceExhausted(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.ResourceExhausted, message);
        }

        /// <summary>
        /// Action requires authentication
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorUnauthenticated(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Unauthenticated, message);
        }


        /// <summary>
        /// Just really dont know but i should sure log it
        /// </summary>
        /// <param name="message">User's error message</param>
        public static void ErrorUnknown(this CallContext context, string message)
        {
            throw CreateRpcException(StatusCode.Unknown, message);
        }


    }
}
