using Grpc.Core;
using OpenCodeDev.NetCMS.Core.Shared.Api.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.Extensions
{
    public static class MessageExt
    {
        /// <summary>
        /// Validate Form Using Data Annotation (This Process is used on client side too with EditForm and EditContext), Single Validation for Both Server and Client
        /// </summary>
        /// <param name="context"></param>
        /// <param name="throwOnError"></param>
        /// <returns></returns>
        public static bool ValidateForm(this object context, bool throwOnError = true)
        {
            try
            {
                var ctx = new ValidationContext(context);
                bool rez = Validator.TryValidateObject(context, ctx, null, true);
                if (!rez)
                {
                    if (throwOnError)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return rez;
                    }

                }
                else
                {
                    return rez;
                }
            }
            catch
            {

                throw new RpcException(new Status(StatusCode.InvalidArgument, "Error cannot validate the form."));
            }

        }

        /// <summary>
        /// Return the underlying type defined by the system to ensure 100% maatch when it occurs
        /// </summary>
        public static string ToSystemString(this FieldTypes type)
        {
            switch (type)
            {
                case FieldTypes.String:
                    return typeof(string).ToString();
                case FieldTypes.Int:
                    return typeof(int).ToString();
                case FieldTypes.Float:
                    return typeof(float).ToString();
                case FieldTypes.Double:
                    return typeof(double).ToString();
                case FieldTypes.Bool:
                    return typeof(bool).ToString();
                case FieldTypes.Guid:
                    return typeof(Guid).ToString();
                case FieldTypes.Long:
                    return typeof(long).ToString();
                default:
                    Console.WriteLine($@"ERROR (ConditionHandler): The Field Type ${type} isn't supported by NetCMS.");
                    throw new RpcException(new Status(StatusCode.Internal, "An unknown error has occured, the admin has been notified. try again later or contact support."));

            }
        }

    }
}
