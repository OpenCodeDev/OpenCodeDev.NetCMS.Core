using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.NetCMS.Core.Shared.Extensions
{
    public static class ReflectionExt
    {

        /// <summary>
        /// Get Property By Name, The difference ? it will never throw will only ever return the value or null so it can be chained which null check extensions.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfoByName(this Type type, string name){
            var prop = type.GetProperty(name);
            try { return prop == null ? null : prop; } catch (Exception) { return null; }            
        }

        /// <summary>
        /// Teste Nullable and return it if available otherwise we'll return the normal prop type value or null.
        /// </summary>
        public static Type GetUnderlyingPropertyTypeIfPossible(this PropertyInfo prop){
            try { return Nullable.GetUnderlyingType(prop.PropertyType) == null ? prop.PropertyType : Nullable.GetUnderlyingType(prop.PropertyType); } 
            catch (Exception) { return null; }
        }

        /// <summary>
        /// Validate the type of this property matches the string (most likely the intent of the editor)<br/>
        /// Will return null when match fails and will return back the propertyinfo when match occurs.
        /// </summary>
        public static PropertyInfo ValidateTypeMatch(this PropertyInfo prop, string fieldTypeName)
        {
            var propType = prop.GetUnderlyingPropertyTypeIfPossible();
            if (propType == null) { return null; }
            try
            {
                if (propType.ToString() == fieldTypeName) { return prop; }
            } catch (Exception) { }
           
            return null;
        }

        /// <summary>
        /// Return true when property type is allowed
        /// </summary>
        public static bool ValidationPropTypeAllowed(this PropertyInfo prop)
        {
            string type = prop.GetUnderlyingPropertyTypeIfPossible().ToString();
           return ValidationPropTypeAllowed(type);
        }

        public static bool ValidationPropTypeAllowed(this string prop){
            string type = prop;
            if (typeof(string).ToString() == type || typeof(int).ToString() == type || typeof(float).ToString() == type ||
                typeof(double).ToString() == type || typeof(Guid).ToString() == type || typeof(long).ToString() == type)
            {
                return true;
            }
            return false;
        }

 


    }
}
