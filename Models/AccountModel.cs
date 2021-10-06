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
        [Required(ErrorMessage = "use name is requeid.")]
        public string UseName { get; set; }
        [Required(ErrorMessage = "pass is requeid.")]

        [DataType(DataType.Password)] //Dùng để biến kí tự thành "".""
        public string PassWord { get; set; }

        [StringLength(10)]
        public string RoleID { get; set; }
    }
}