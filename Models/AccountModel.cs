using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    public class AccountModel
    {
        [Key]
        //Validation with model
        //UseName khong duoc de trong
        [Required(ErrorMessage = "Usename is required.")]
        public string Username { get; set; }
        //Password khong duoc de trong
        [Required(ErrorMessage = "Password is required.")]
        //Dinh nghia DataType
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}