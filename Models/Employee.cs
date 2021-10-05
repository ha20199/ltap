using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ltap.Models
{
    public class Employee: Person
    {
        public string Company { get; set; }
        public string Address { get; set; }
    }
}