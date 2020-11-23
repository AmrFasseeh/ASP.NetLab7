using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NetLab6.Models
{
    public class StudentCourses
    {
        [Key, ForeignKey("Student"), Column(Order = 0)]
        public int StudentId { get; set; }
        [Key, ForeignKey("Course"), Column(Order = 1)]
        public int CourseId{ get; set; }
        public int Grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}