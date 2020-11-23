using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NetLab6.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        [Display(Name="Full Name")]
        public string Name { get; set; }

        [Range(10,90)]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "The email format is not valid")]
        public string Email { get; set; }

        [Required]
        [System.Web.Mvc.Remote("checkUserName", "Student")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string CPassword { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Department Department { get; set; }

    }
}