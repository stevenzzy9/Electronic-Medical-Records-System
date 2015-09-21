using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMRS.Models
{
    public class TreatmentRecord
    {
        [Key]
        public int TreatmentRecordID { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    public class AttachTreatmentRecordModel
    {
        [Required]
        public int MedicalRecordID { get; set; }

        [DisplayName("Patient")]
        public string PatientName { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        [DisplayName("Treatment Record")]
        public string Description { get; set; }

        [Required]
        [DisplayName("The end of treatment")]
        public bool IsFinished { get; set; }
    }
}