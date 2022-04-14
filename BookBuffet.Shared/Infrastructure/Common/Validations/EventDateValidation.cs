using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class EventDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime eventDate = Convert.ToDateTime(value);
                if (eventDate > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult
                        ("Event date has been passed.Please Choose another date.");
                }
            }
            return new ValidationResult("Event date is null.Please Choose date.");
        }
    }
}
