using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NetLab6.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Range(5,100)]
        public int Duration{ get; set; }
        public virtual List<Department> Departments { get; set; }
    }
}