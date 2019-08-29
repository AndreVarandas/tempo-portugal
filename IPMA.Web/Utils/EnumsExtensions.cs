using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace IPMA.Web.Utils
{
    public static class EnumsExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var name = enumValue.GetType()?
                .GetMember(enumValue.ToString())?
                .First()?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name;

            return name ?? enumValue.ToString();
        }
    }
}