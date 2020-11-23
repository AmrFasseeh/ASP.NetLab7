using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetLab6.Models;

namespace ASP.NetLab6.Controllers
{
    public class DepartmentController : Controller
    {
        ASPModel1 db = new ASPModel1();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Post(int id)
        {
            Department dept = db.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Post(Department d, int id)
        {
            if (ModelState.IsValid)
            {
                Department dept = db.Departments.Find(id);
                dept.Name = d.Name;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }

        public ActionResult Delete(int id)
        {
            Department dept = db.Departments.Find(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}