using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime NewDate;
           var isValid = DateTime.TryParseExact(
               Convert.ToString(value),
               "d MMM yyyy",
               CultureInfo.CurrentCulture,
               DateTimeStyles.None,
               out NewDate);
            return (isValid && NewDate > DateTime.Now);
        }
    }
}