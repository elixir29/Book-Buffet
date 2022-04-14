using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class RegistrationDTO
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("[^@]+@[^@]+\\.[^@]+$", ErrorMessage = "Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        public string UserEmailId { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5, ErrorMessage = "Minimum Password must be 5 in charaters")]
        [DataType(DataType.Password)]
        [RegularExpression("^.*(?=.*\\d)(?=.*[a-zA-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Password must contains one digit,one alphabet and one special character ")]
        public string UserPassword { get; set; }
    }
}
