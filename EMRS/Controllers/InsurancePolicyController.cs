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
    public class InsurancePolicyController : Controller
    {
        private HospitalContext db = new HospitalContext();

        //
        // GET: /InsurancePolicy/

        public ActionResult Index()
        {
            return View(db.InsurancePolicies.ToList());
        }

        //
        // GET: /InsurancePolicy/Details/5

        public ActionResult Details(int id = 0)
        {
            InsurancePolicy insurancepolicy = db.InsurancePolicies.Find(id);
            if (insurancepolicy == null)
            {
                return HttpNotFound();
            }
            return View(insurancepolicy);
        }

        //
        // GET: /InsurancePolicy/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InsurancePolicy/Create

        [HttpPost]
        public ActionResult Create(InsurancePolicy insurancepolicy)
        {
            if (ModelState.IsValid)
            {
                db.InsurancePolicies.Add(insurancepolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurancepolicy);
        }

        //
        // GET: /InsurancePolicy/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InsurancePolicy insurancepolicy = db.InsurancePolicies.Find(id);
            if (insurancepolicy == null)
            {
                return HttpNotFound();
            }
            return View(insurancepolicy);
        }

        //
        // POST: /InsurancePolicy/Edit/

        [HttpPost]
        public ActionResult Edit(InsurancePolicy insurancepolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurancepolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurancepolicy);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}