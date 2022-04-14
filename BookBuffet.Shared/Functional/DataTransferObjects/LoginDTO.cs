using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuffet.Shared
{
    public class LoginDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string UserEmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
