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
    public class MedicalController : Controller
    {
        private HospitalContext db = new HospitalContext();

        //
        // GET: /Medical/

        public ActionResult Index(string searchString)
        {
            if (User.IsInRole("AttendingPhysician"))
            {
                AttendingPhysician self = db.AttendingPhysicians.FirstOrDefault(
                    item => item.UserName.Equals(User.Identity.Name));
                if (self == null)
                {
                    return HttpNotFound();
                }
                var tmp = db.MedicalRecords.Where(
                    item => item.Physician.UserId == self.UserId);
                if (!String.IsNullOrEmpty(searchString))
                {
                    string[] keywords = searchString.Split(new char[] { ' ', '\t' });
                    foreach (string key in keywords)
                    {
                        tmp = tmp.Where(s => s.Patient.Name.Contains(key));
                    }
                }
                var medicalRecords = tmp.Select(item => new ListMedicalRecordModel
                    {
                        MedicalRecordID = item.MedicalRecordID,
                        PatientName = item.Patient.Name,
                        PhysicianName = item.Physician.Name,
                        StartTime = item.CreatedTime,
                        UnderTreatment = !item.IsFinished
                    });
                return View(medicalRecords);
            }
            else if (User.IsInRole("Patient"))
            {
                Patient self = db.Patients.FirstOrDefault(
                    item => item.UserName.Equals(User.Identity.Name));
                if (self == null)
                {
                    return HttpNotFound();
                }
                var tmp = db.MedicalRecords.Where(
                    item => item.Patient.UserId == self.UserId);
                if (!String.IsNullOrEmpty(searchString))
                {
                    string[] keywords = searchString.Split(new char[] { ' ', '\t' });
                    foreach (string key in keywords)
                    {
                        tmp = tmp.Where(s => s.Physician.Name.Contains(key));
                    }
                }
                var medicalRecords = tmp.Select(item => new ListMedicalRecordModel
                    {
                        MedicalRecordID = item.MedicalRecordID,
                        PatientName = item.Patient.Name,
                        PhysicianName = item.Physician.Name,
                        StartTime = item.CreatedTime,
                        UnderTreatment = !item.IsFinished
                    });
                return View(medicalRecords);
            }
            return HttpNotFound();
        }

        //
        // GET: /Medical/Details/5

        public ActionResult Details(int id = 0)
        {
            MedicalRecord medicalrecord = db.MedicalRecords.Find(id);
            if (medicalrecord == null)
            {
                return HttpNotFound();
            }
            return View(medicalrecord);
        }

        //
        // GET: /Medical/Create/5

        public ActionResult Create(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(new CreateMedicalRecordModel {
                PatientID = id,
                PatientName = patient.Name,
                Physicians = new SelectList(
                    db.AttendingPhysicians,
                    "UserID", "Name", 
                    db.AttendingPhysicians.First())
            });
        }

        //
        // POST: /Medical/Create

        [HttpPost]
        public ActionResult Create(CreateMedicalRecordModel medicalrecordInfo)
        {
            if (ModelState.IsValid)
            {
                MedicalRecord medicalrecord = new MedicalRecord {
                    Comment = medicalrecordInfo.Comment,
                    IsFinished = false,
                    CreatedTime = DateTime.Now,
                    Physician = db.AttendingPhysicians.Find(medicalrecordInfo.PhysicianID),
                    Patient = db.Patients.Find(medicalrecordInfo.PatientID)
                };
                db.MedicalRecords.Add(medicalrecord);
                db.SaveChanges();
                return RedirectToAction("Index", "Patient");
            }

            return View(medicalrecordInfo);
        }

        //
        // GET: /Medical/Attach

        public ActionResult Attach(int id = 0)
        {
            MedicalRecord medicalRecord = db.MedicalRecords.Find(id);
            if (medicalRecord == null)
            {
                return HttpNotFound();
            }
            return View(new AttachTreatmentRecordModel
            {
                MedicalRecordID = medicalRecord.MedicalRecordID,
                PatientName = medicalRecord.Patient.Name,
                Comment = medicalRecord.Comment,
                CreatedTime = medicalRecord.CreatedTime,
                IsFinished = false
            });
        }

        //
        // POST: /Medical/Attach

        [HttpPost]
        public ActionResult Attach(AttachTreatmentRecordModel treatmentRecord)
        {
            if (ModelState.IsValid)
            {
                MedicalRecord medicalrecord = db.MedicalRecords.Find(
                    treatmentRecord.MedicalRecordID);
                medicalrecord.TreatmentRecords.Add(new TreatmentRecord
                {
                    CreatedTime = DateTime.Now,
                    Description = treatmentRecord.Description
                });
                medicalrecord.IsFinished = treatmentRecord.IsFinished;
                db.Entry(medicalrecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = treatmentRecord.MedicalRecordID });
            }

            return View(treatmentRecord);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}