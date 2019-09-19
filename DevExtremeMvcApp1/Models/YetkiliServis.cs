using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevExtremeMvcApp1.Models
{
    public class YetkiliServis
    {
        [Key]
        public int ServisUserID { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string ServisUserEmail { get; set; }
        [Required(ErrorMessage = "User Name is Required.")]
        public string ServisUsername { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string ServisUserPassword { get; set; }


    }
}