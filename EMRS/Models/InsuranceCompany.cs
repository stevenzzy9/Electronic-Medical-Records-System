using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMRS.Models
{
    public class InsuranceCompany
    {
        [Key]
        public int InsuranceCompanyID { get; set; }
        [DisplayName("Company name")]
        public string CompanyName { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Contact Information")]
        public string ContactInfo { get; set; }
    }
}