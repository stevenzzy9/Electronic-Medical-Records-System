using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace EMRS.Models
{
    /*
    public enum UserType : int
    {
        Patient = 1,
        AssistantDoctor = 2,
        AttendingPhysician = 3,
        Administrator = 4
    }
    */

    public abstract class User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [DisplayName("Login name")]
        public string UserName { get; set; }

        [DisplayName("User name")]
        public string Name { get; set; }
        [DisplayName("SSN")]
        public string SSN { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }

    public enum Gender : int
    {
        Male = 1,
        Female = 2,
    }

    [Table("Patients")]
    public class Patient : User
    {
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Emergency contact name")]
        public string EMCName { get; set; }
        [DisplayName("Emergency contact address")]
        public string EMCAddress { get; set; }
        [DisplayName("Emergency contact E-Mail")]
        public string EMCEmail { get; set; }
        [DisplayName("Emergency contact phone")]
        public string EMCPhone { get; set; }
        [DisplayName("Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Gender")]
        public Gender? Gender { get; set; }
        [Display(Name = "Insurance Company")]
        public virtual InsuranceCompany InsuranceCompany { get; set; }
        [Display(Name = "Insurance Policy")]
        public virtual InsurancePolicy InsurancePolicy { get; set; }
        [Display(Name = "Insurance Policy Number")]
        public string InsurancePolicyNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Insurance Expiry Date")]
        public DateTime? InsuranceExpiryDate { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }

    [Table("AttendingPhysicians")]
    public class AttendingPhysician : User
    {
        public virtual Department Department { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class CreatePatientModel
    {
        [Required]
        [Display(Name = "Login name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Patient name")]
        public string Name { get; set; }
        
        [Required]
        [DisplayName("SSN")]
        public string SSN { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Emergency contact name")]
        public string EMCName { get; set; }

        [DisplayName("Emergency contact address")]
        public string EMCAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Emergency contact E-Mail")]
        public string EMCEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Emergency contact phone")]
        public string EMCPhone { get; set; }
    }
    
    public class EditPatientModel
    {
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Emergency contact name")]
        public string EMCName { get; set; }

        [DisplayName("Emergency contact address")]
        public string EMCAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Emergency contact E-Mail")]
        public string EMCEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Emergency contact phone")]
        public string EMCPhone { get; set; }

        public EditPatientModel()
        {
        }

        public EditPatientModel(Patient patient)
        {
            this.UserId = patient.UserId;
            this.PatientName = patient.Name;
            this.Email = patient.Email;
            this.Phone = patient.Phone;
            this.Address = patient.Address;
            this.EMCName = patient.EMCName;
            this.EMCAddress = patient.EMCAddress;
            this.EMCEmail = patient.EMCEmail;
            this.EMCPhone = patient.EMCPhone;
        }
    }

    public class EditPatientInsuranceModel
    {
        [Required]
        public int UserId { get; set; }

        [Display(Name = "Patient")]
        public string PatientName { get; set; }
        
        [Required]
        [Display(Name = "Insurance Company")]
        public int InsuranceCompanyID { get; set; }
        
        [Required]
        [Display(Name = "Insurance Policy")]
        public int InsurancePolicyID { get; set; }

        [Required]
        [Display(Name = "Insurance Policy Number")]
        public string InsurancePolicyNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Insurance Expiry Date")]
        public DateTime InsuranceExpiryDate { get; set; }

        public System.Web.Mvc.SelectList InsuranceCompanies;
        public System.Web.Mvc.SelectList InsurancePolicies;

        public EditPatientInsuranceModel()
        {
        }

        public EditPatientInsuranceModel(Patient patient)
        {
            this.UserId = patient.UserId;
            this.PatientName = patient.Name;
            if (patient.InsuranceCompany != null)
            {
                this.InsuranceCompanyID = patient.InsuranceCompany.InsuranceCompanyID;
            }
            if (patient.InsurancePolicy != null)
            {
                this.InsurancePolicyID = patient.InsurancePolicy.InsurancePolicyID;
            }
            this.InsurancePolicyNumber = patient.InsurancePolicyNumber;
            if (patient.InsuranceExpiryDate != null)
            {
                this.InsuranceExpiryDate = (DateTime)patient.InsuranceExpiryDate;
            }
        }
    }

    public class CreatePhysicianModel
    {
        [Required]
        [Display(Name = "Login name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Physician name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("SSN")]
        public string SSN { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public System.Web.Mvc.SelectList Departments;

    }
}
