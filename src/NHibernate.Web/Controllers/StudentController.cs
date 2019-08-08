using NHibernate.Web.Models;
using NHibernate.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace NHibernate.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            IList<Student> Students;

            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                Students = session.Query<Student>().ToList(); //  Querying to get all the Students
            }

            ViewBag.GenderList = ((Gender[])Enum.GetValues(typeof(Gender))).Select(c => c.ToString()).ToList();

            //string name = Enum.GetName(typeof(Gender), 2);

            return View(Students);
        }
        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = new Student();

            using (ISession session = NHibernateSession.OpenSession())
            {
                student = session.Query<Student>().Where(b => b.ID == id).FirstOrDefault();
            }

            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ////var GenderList = Gender.ToList();

            // A list of Values only, does away with the need of EnumModel 
            List<int> myValues = ((Gender[])Enum.GetValues(typeof(Gender))).Select(c => (int)c).ToList();

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Student student = new Student
                {
                    ID = 115,
                    FirstName = collection["FirstName"].ToString(),
                    LastName = collection["LastName"].ToString(),
                    Email = collection["Email"].ToString(),
                    Phone = Convert.ToInt32(collection["Phone"])
                };     //  Creating a new instance of the Student
                
                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Save(student); //  Save the Student in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();

            using (ISession session = NHibernateSession.OpenSession())
            {
                student = session.Query<Student>().Where(b => b.ID == id).FirstOrDefault();
            }

            ViewBag.SubmitAction = "Save";
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Student student = new Student
                {
                    ID = id,
                    FirstName = collection["FirstName"].ToString(),
                    LastName = collection["LastName"].ToString(),
                    Email = collection["Email"].ToString(),
                    Phone = Convert.ToInt32(collection["Phone"])
                };

                // TODO: Add insert logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(student);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Student student = session.Query<Student>().Where(b => b.ID == id).FirstOrDefault();

                    using (ITransaction trans = session.BeginTransaction())
                    {
                        session.Delete(student);
                        trans.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }        
    }
}