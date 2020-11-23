using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetLab6.Models;

namespace ASP.NetLab6.Controllers
{
    public class CourseController : Controller
    {
        ASPModel1 db = new ASPModel1();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course c)
        {
            if(ModelState.IsValid)
            {
                db.Courses.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Post(int id)
        {
            Course c = db.Courses.Find(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Post(Course c, int id)
        {
            if(ModelState.IsValid)
            {
                Course cr = db.Courses.Find(id);
                cr.CourseName = c.CourseName;
                cr.Duration = c.Duration;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            Course c = db.Courses.Find(id);
            db.Courses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}