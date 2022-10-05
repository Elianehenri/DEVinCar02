using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DEVinCar.Domain.Enums
{
    public enum Permissoes
    {
        [XmlEnumAttribute("V")]
        [Display(Name = "Vendedor")]
        Vendedor = 1,
        [XmlEnumAttribute("G")]
        [Display(Name = "Gerente ")]
        Gerente = 2,
        [XmlEnumAttribute("C")]
        [Display(Name = "Comprador")]
        Comprador = 3
    }
    public static class EnumExtensions
    {
        public static string GetName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              ?.GetCustomAttribute<DisplayAttribute>()
              ?.GetName();

            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}