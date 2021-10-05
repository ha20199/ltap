using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public string StudentID { get; set; }
        [Required(ErrorMessage ="Ten sinh vien khong duoc de trong")]
        [MinLength(3)]
        public string StudentName { get; set; }
        [Required]
        public string Address { get; set; }

    }
}