using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with reflection
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Returns all the attributes of a given type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<string> GetAllAttributeNames(Type type)
        {
            List<string> propertyNames = type.GetProperties().Select(prop => prop.Name).ToList();
            return propertyNames;
        }
    }
}