using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMRS.Models
{
    public enum PolicyType : int
    {
        HMO = 1,
        PPO = 2,
        POS = 3
    }

    public class InsurancePolicy
    {
        [Key]
        public int InsurancePolicyID { get; set; }
        [DisplayName("Policy name")]
        public string PolicyName { get; set; }
        [DisplayName("Policy number")]
        public string PolicyNumber { get; set; }
        [DisplayName("Policy type")]
        public PolicyType PolicyType { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}