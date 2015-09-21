using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMRS.Models;
using WebMatrix.WebData;
using Microsoft.Web.WebPages.OAuth;
using System.Web.Security;
using EMRS.Filters;

namespace EMRS.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class PatientController : Controller
    {
        private HospitalContext db = new HospitalContext();

        //
        // GET: /Patient/

        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {

                var patients = from m in db.Patients select m;

                string[] keywords = searchString.Split(new char[] { ' ', '\t' });
                foreach (string key in keywords)
                {
                    patients = patients.Where(s => s.Name.Contains(key));
                }

                return View(patients);
            }
            else
            {
                return View(db.Patients.ToList());
            }
        }

        //
        // GET: /Patient/Details/5

        public ActionResult Details(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // GET: /Patient/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Patient/Create

        [HttpPost]
        public ActionResult Create(CreatePatientModel patientInfo)
        {
            if (ModelState.IsValid)
            {
                if (!WebSecurity.UserExists(patientInfo.UserName))
                {
                    db.Patients.Add(new Patient { 
                        Address = patientInfo.Address,
                        UserName = patientInfo.UserName,
                        Email = patientInfo.Email,
                        Name = patientInfo.Name,
                        Phone = patientInfo.Phone,
                        SSN = patientInfo.SSN,
                        BirthDate = patientInfo.BirthDate,
                        Gender = patientInfo.Gender,
                        EMCName = patientInfo.EMCName,
                        EMCEmail = patientInfo.EMCEmail,
                        EMCPhone = patientInfo.EMCPhone,
                        EMCAddress = patientInfo.EMCAddress
                    });
                    db.SaveChanges();
                    WebSecurity.CreateAccount(patientInfo.UserName, patientInfo.Password);
                    Roles.AddUsersToRoles(new[] { patientInfo.UserName }, new[] { "Patient" });
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Login name \"{0}\" already exists.", patientInfo.UserName));
                }
            }
            return View(patientInfo);
        }

        //
        // GET: /Patient/Insurance/5

        public ActionResult Insurance(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            var insuranceInfo = new EditPatientInsuranceModel(patient);
            insuranceInfo.InsuranceCompanies = new SelectList(
                    db.InsuranceCompanies,
                    "InsuranceCompanyID", "CompanyName",
                    db.InsuranceCompanies.First());
            insuranceInfo.InsurancePolicies = new SelectList(
                    db.InsurancePolicies,
                    "InsurancePolicyID", "PolicyName",
                    db.InsurancePolicies.First());
            return View(insuranceInfo);
        }

        //
        // POST: /Patient/Insurance/5

        [HttpPost]
        public ActionResult Insurance(EditPatientInsuranceModel insuranceInfo)
        {
            if (ModelState.IsValid)
            {
                Patient patient = db.Patients.Find(insuranceInfo.UserId);
                patient.InsuranceCompany = db.InsuranceCompanies.Find(insuranceInfo.InsuranceCompanyID);
                patient.InsurancePolicy = db.InsurancePolicies.Find(insuranceInfo.InsurancePolicyID);
                patient.InsuranceExpiryDate = insuranceInfo.InsuranceExpiryDate;
                patient.InsurancePolicyNumber = insuranceInfo.InsurancePolicyNumber;
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuranceInfo);
        }

        //
        // GET: /Patient/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(new EditPatientModel(patient));
        }

        //
        // POST: /Patient/Edit/5

        [HttpPost]
        public ActionResult Edit(EditPatientModel patientInfo)
        {
            if (ModelState.IsValid)
            {
                Patient patient = db.Patients.Find(patientInfo.UserId);
                patient.Email = patientInfo.Email;
                patient.Phone = patientInfo.Phone;
                patient.Address = patientInfo.Address;
                patient.EMCName = patientInfo.EMCName;
                patient.EMCAddress = patientInfo.EMCAddress;
                patient.EMCEmail = patientInfo.EMCEmail;
                patient.EMCPhone = patientInfo.EMCPhone;
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientInfo);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}