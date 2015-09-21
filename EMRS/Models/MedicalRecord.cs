using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMRS.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordID { get; set; }
        public bool IsFinished { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Patient")]
        public virtual Patient Patient { get; set; }
        public DateTime CreatedTime { get; set; }
        [Display(Name = "Attending Physician")]
        public virtual AttendingPhysician Physician { get; set; }
        public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; }
    }


    public class ListMedicalRecordModel
    {
        public int MedicalRecordID { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        [Display(Name = "Attending Physician")]
        public string PhysicianName { get; set; }

        [Display(Name = "Start time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Under treatment")]
        public bool UnderTreatment { get; set; }

    }

    public class CreateMedicalRecordModel
    {
        [Required]
        public int PatientID { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Attending Physician")]
        public int PhysicianID { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public SelectList Physicians;
    }
}