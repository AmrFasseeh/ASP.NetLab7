using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NetLab6.Models;

namespace ASP.NetLab6.Controllers
{
    public class StudentController : Controller
    {
        ASPModel1 db = new ASPModel1();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students);
        }

        public ActionResult Create()
        {
            SelectList deptlist = new SelectList(db.Departments.ToList(), "DeptId", "Name");
            ViewBag.depts = deptlist;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList deptlist = new SelectList(db.Departments.ToList(), "DeptId", "Name");
            ViewBag.depts = deptlist;
            return View();
        }

        [HttpGet]
        public ActionResult Post(int id)
        {
            Student stud = db.Students.Find(id);
            SelectList deptlist = new SelectList(db.Departments.ToList(), "DeptId", "Name", stud.DeptId);
            ViewBag.depts = deptlist;
            return View(stud);
        }
        public ActionResult Post(Student st, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Student s = db.Students.Find(id);
                    s.Name = st.Name;
                    s.Age = st.Age;
                    s.Email = st.Email;
                    if (s.UserName != st.UserName)
                    {
                        s.UserName = st.UserName;
                    }
                    s.Password = st.Password;
                    s.DeptId = st.DeptId;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join(" ; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
            Student stud = db.Students.Find(id);
            SelectList deptlist = new SelectList(db.Departments.ToList(), "DeptId", "Name", stud.DeptId);
            ViewBag.depts = deptlist;
            return View(stud);
        }

        public ActionResult Delete(int id)
        {
            Student st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult checkUserName(string UserName)
        {
            Student std = db.Students.FirstOrDefault(s => s.UserName == UserName);
            if (std == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

       /* public ActionResult checkPassword(string Password, string CPassword, int id)
        {
            Student std = db.Students.FirstOrDefault(s => s.id == id);
            if (std == null && Password == CPassword)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            if(std.id == id && Password == CPassword)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }*/
    }
}