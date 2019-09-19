using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DevExtremeMvcApp1.Models
{
    public class UserAccount
    {

        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword  is Required.")]
        [Compare("Password", ErrorMessage = "Please Confirm Your Password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "SirketAdi  is Required.")]
        public string SirketAdi { get; set; }
        [Required(ErrorMessage = "CepTelefon  is Required.")]
        public string CepTelefon { get; set; }
        [Required(ErrorMessage = "EvTelefon  is Required.")]
        public string EvTelefon { get; set; }
        [Required(ErrorMessage = "SirketTelefon  is Required.")]
        public string SirketTelefon { get; set; }
      
        public int TCNo { get; set; }
        [Required(ErrorMessage = "Meslek  is Required.")]
        public string Meslek { get; set; }
        [Required(ErrorMessage = "İl  is Required.")]
        public string İl { get; set; }
        [Required(ErrorMessage = "İlçe  is Required.")]
        public string İlçe { get; set; }
        [Required(ErrorMessage = "Adres  is Required.")]
        public string Adres { get; set; }
   

        public Cinsiyet CinsiyetName { get; set; }

    }

    public enum Cinsiyet
    {
        Kadın,Erkek
    }


}