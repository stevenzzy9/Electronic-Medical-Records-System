using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMRS.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [DisplayName("Department name")]
        public string DepartmentName { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public virtual ICollection<AttendingPhysician> AttendingPhysicians { get; set; }
    }
}