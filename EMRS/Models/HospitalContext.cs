using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace EMRS.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<TreatmentRecord> TreatmentRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<AttendingPhysician> AttendingPhysicians { get; set; }        
    }
}
