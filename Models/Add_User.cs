using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Add_User
    {
        [DisplayName("USER NAME")]
        [Required(ErrorMessage = "USER NAME IS REQUIRED!")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DisplayName("PASSWORD")]
        [Required(ErrorMessage = "USER PASSWORD IS REQUIRED!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("EMAIL")]
        [Required(ErrorMessage = "USER EMAILID IS REQUIRED!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("PHONE NUMBER")]
        [Required(ErrorMessage = "USER PHONE NUMBER IS REQUIRED!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}