using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with enums
    /// </summary>
    public static class EnumHelper
    {

        /// <summary>
        /// Returns the description of a given enum value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(int value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var enumValues = Enum.GetValues(typeof(T)).OfType<Enum>().Select(e => new { Id = Convert.ToByte(e), Name = GetDescription(e) });

            var a = enumValues.FirstOrDefault(x => x.Id == value);
            var name = a != null ? (String.IsNullOrEmpty(a.Name) ? String.Empty : a.Name) : String.Empty;

            return name;
        }

        /// <summary>
        /// Returns the description of a given enum type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDictionary<T, string> GetEnumValuesWithDescription<T>(this Type type) where T : struct, IConvertible
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return type.GetEnumValues()
                .OfType<T>()
                .ToDictionary(
                    key => key,
                    val => val.ToString()
                );
        }

        /// <summary>
        /// Looks for a [Display(Name="Some Name")] Attribute on the enum
        /// </summary>
        public static Func<Enum, string> GetDescription = en =>
        {
            Type type = en.GetType();
            System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((DisplayAttribute)attrs[0]).Name;
            }

            return en.ToString();
        };

    }
}