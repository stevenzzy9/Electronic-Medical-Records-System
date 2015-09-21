using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMRS.Models;
using EMRS.Filters;

namespace EMRS.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class InsuranceCompanyController : Controller
    {
        private HospitalContext db = new HospitalContext();

        //
        // GET: /InsuranceCompany/

        public ActionResult Index()
        {
            return View(db.InsuranceCompanies.ToList());
        }

        //
        // GET: /InsuranceCompany/Details/5

        public ActionResult Details(int id = 0)
        {
            InsuranceCompany insurancecompany = db.InsuranceCompanies.Find(id);
            if (insurancecompany == null)
            {
                return HttpNotFound();
            }
            return View(insurancecompany);
        }

        //
        // GET: /InsuranceCompany/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InsuranceCompany/Create

        [HttpPost]
        public ActionResult Create(InsuranceCompany insurancecompany)
        {
            if (ModelState.IsValid)
            {
                db.InsuranceCompanies.Add(insurancecompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurancecompany);
        }

        //
        // GET: /InsuranceCompany/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InsuranceCompany insurancecompany = db.InsuranceCompanies.Find(id);
            if (insurancecompany == null)
            {
                return HttpNotFound();
            }
            return View(insurancecompany);
        }

        //
        // POST: /InsuranceCompany/Edit/

        [HttpPost]
        public ActionResult Edit(InsuranceCompany insurancecompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurancecompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurancecompany);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}