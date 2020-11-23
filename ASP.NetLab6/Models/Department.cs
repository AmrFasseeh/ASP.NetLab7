using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NetLab6.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}