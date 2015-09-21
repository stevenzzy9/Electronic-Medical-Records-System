using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMRS.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace EMRS.Controllers
{
    public class PhysicianController : Controller
    {
        private HospitalContext db = new HospitalContext();

        //
        // GET: /Physician/

        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {

                var physicians = from m in db.AttendingPhysicians select m;

                string[] keywords = searchString.Split(new char[] { ' ', '\t' });
                foreach (string key in keywords)
                {
                    physicians = physicians.Where(s => s.Name.Contains(key));
                }

                return View(physicians);
            }
            else
            {
                return View(db.AttendingPhysicians.ToList());
            }
        }

        //
        // GET: /Physician/Details/5

        public ActionResult Details(int id = 0)
        {
            AttendingPhysician attendingphysician = db.AttendingPhysicians.Find(id);
            if (attendingphysician == null)
            {
                return HttpNotFound();
            }
            return View(attendingphysician);
        }

        //
        // GET: /Physician/Create

        public ActionResult Create()
        {
            var physicianInfo = new CreatePhysicianModel();
            physicianInfo.Departments = new SelectList(
                    db.Departments,
                    "DepartmentID", "DepartmentName",
                    db.InsuranceCompanies.First());
            return View(physicianInfo);
        }

        //
        // POST: /Physician/Create

        [HttpPost]
        public ActionResult Create(CreatePhysicianModel physicianInfo)
        {
            if (ModelState.IsValid)
            {
                if (!WebSecurity.UserExists(physicianInfo.UserName))
                {
                    db.AttendingPhysicians.Add(new AttendingPhysician
                    {
                        UserName = physicianInfo.UserName,
                        Email = physicianInfo.Email,
                        Name = physicianInfo.Name,
                        Phone = physicianInfo.Phone,
                        SSN = physicianInfo.SSN,
                        Department = db.Departments.Find(physicianInfo.DepartmentID)
                    });
                    db.SaveChanges();
                    WebSecurity.CreateAccount(physicianInfo.UserName, physicianInfo.Password);
                    Roles.AddUsersToRoles(new[] { physicianInfo.UserName }, new[] { "AttendingPhysician" });
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Login name \"{0}\" already exists.", physicianInfo.UserName));
                }
            }
            return View(physicianInfo);
        }

        //
        // GET: /Physician/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AttendingPhysician attendingphysician = db.AttendingPhysicians.Find(id);
            if (attendingphysician == null)
            {
                return HttpNotFound();
            }
            return View(attendingphysician);
        }

        //
        // POST: /Physician/Edit/5

        [HttpPost]
        public ActionResult Edit(AttendingPhysician physicianinfo)
        {
            if (ModelState.IsValid)
            {
                AttendingPhysician physician = db.AttendingPhysicians.Find(physicianinfo.UserId);
                physician.Email = physicianinfo.Email;
                physician.Phone = physicianinfo.Phone;
                db.Entry(physician).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(physicianinfo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}