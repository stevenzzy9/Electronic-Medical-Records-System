
#region

using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using EMRS.Models;
using WebMatrix.WebData;

#endregion

namespace EMRS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HospitalContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "Users",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Patient"))
                Roles.CreateRole("Patient");
            if (!Roles.RoleExists("AssistantDoctor"))
                Roles.CreateRole("AssistantDoctor");
            if (!Roles.RoleExists("AttendingPhysician"))
                Roles.CreateRole("AttendingPhysician");
            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");
            
            if (!WebSecurity.UserExists("Admin"))
                WebSecurity.CreateUserAndAccount(
                    "Admin",
                    "123456");

            if (!Roles.GetRolesForUser("Admin").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "Admin" }, new[] { "Administrator" });

            if (!WebSecurity.UserExists("Assistant"))
                WebSecurity.CreateUserAndAccount(
                    "Assistant",
                    "123456");

            if (!Roles.GetRolesForUser("Assistant").Contains("AssistantDoctor"))
                Roles.AddUsersToRoles(new[] { "Assistant" }, new[] { "AssistantDoctor" });

            if (!WebSecurity.UserExists("Jane.Doe"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Jane.Doe",
                    Email = "Jane.Doe@gmail.com",
                    Name = "Jane William Doe",
                    Phone = "608-782-2209",
                    SSN = "330-78-1209",
                    Address = "1357 Pine Street, La Crosse WI 54601.",
                    BirthDate = new System.DateTime(1975, 2, 20),
                    Gender = Gender.Female,
                    EMCName = "Kelly Roraff",
                    EMCEmail = "Kelly.roraff@gmail.com",
                    EMCPhone = "608-387-7716",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Jane.Doe", "123456");
                Roles.AddUsersToRoles(new[] { "Jane.Doe" }, new[] { "Patient" });
            }

            if (!WebSecurity.UserExists("Robin.S"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Robin.S",
                    Email = "Robin.S@gmail.com",
                    Name = "Robin S Stins",
                    Phone = "608-782-2209",
                    SSN = "330-79-2311",
                    Address = "1517,King Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1989, 2, 10),
                    Gender = Gender.Female,
                    EMCName = "Kelly Roraff",
                    EMCEmail = "Kelly.roraff@gmail.com",
                    EMCPhone = "608-387-7716",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Robin.S", "123456");
                Roles.AddUsersToRoles(new[] { "Robin.S" }, new[] { "Patient" });
            }

            if (!WebSecurity.UserExists("Larry.Mosby"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Larry.Mosby",
                    Email = "Jane.Doe@gmail.com",
                    Name = "Larry Mosby",
                    Phone = "785-507-2223",
                    SSN = "678-79-2311",
                    Address = "2317,Alien Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1989, 8, 18),
                    Gender = Gender.Male,
                    EMCName = "Leonardo Bekins",
                    EMCEmail = "Leonardo.roraff@gmail.com",
                    EMCPhone = "608-387-7716",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Larry.Mosby", "123456");
                Roles.AddUsersToRoles(new[] { "Larry.Mosby" }, new[] { "Patient" });
            }

            if (!WebSecurity.UserExists("Tiger.Woo"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Tiger.Woo",
                    Email = "Tiger.Woo@gmail.com",
                    Name = "Tiger Woods",
                    Phone = "782-313-2244",
                    SSN = "878-72-3431",
                    Address = "0417,Queen Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1990, 6, 25),
                    Gender = Gender.Male,
                    EMCName = "Leonardo Bekins",
                    EMCEmail = "Leonardo.roraff@gmail.com",
                    EMCPhone = "608-387-0982",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Tiger.Woo", "123456");
                Roles.AddUsersToRoles(new[] { "Tiger.Woo" }, new[] { "Patient" });
            }


            if (!WebSecurity.UserExists("Lily.Phi"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Lily.Phi",
                    Email = "Lily.Phi@gmail.com",
                    Name = "Lily Philips",
                    Phone = "602-313-2244",
                    SSN = "808-72-3231",
                    Address = "1417,Queen Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1967, 5, 25),
                    Gender = Gender.Female,
                    EMCName = "Mark Bekins",
                    EMCEmail = "Mark.roraff@gmail.com",
                    EMCPhone = "608-387-0982",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Lily.Phi", "123456");
                Roles.AddUsersToRoles(new[] { "Lily.Phi" }, new[] { "Patient" });
            }

            if (!WebSecurity.UserExists("Ask.Phi"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Ask.Phi",
                    Email = "Ask.Phi@gmail.com",
                    Name = "Shelly Q Bush",
                    Phone = "602-985-2501",
                    SSN = "972-33-4234",
                    Address = "1417,Lary Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1980, 4, 19),
                    Gender = Gender.Female,
                    EMCName = "Matin Rolls",
                    EMCEmail = "Mark.roraff@gmail.com",
                    EMCPhone = "608-387-0982",
                    EMCAddress = "1234 Park Ave. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Ask.Phi", "123456");
                Roles.AddUsersToRoles(new[] { "Ask.Phi" }, new[] { "Patient" });
            }

            if (!WebSecurity.UserExists("Jones.Ok"))
            {
                context.Patients.Add(new Patient
                {
                    UserName = "Jones.Ok",
                    Email = "Jones.Ok@gmail.com",
                    Name = "Damon One Jones",
                    Phone = "602-985-3879",
                    SSN = "972-33-6829",
                    Address = "1489,La Crosse Street,La Crosse WI,54601.",
                    BirthDate = new System.DateTime(1990, 2, 18),
                    Gender = Gender.Male,
                    EMCName = "Matin Alex",
                    EMCEmail = "Liffy.Luck@gmail.com",
                    EMCPhone = "608-387-9082",
                    EMCAddress = "1223 BarkSt. La Crosse, WI 54601."
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Jones.Ok", "123456");
                Roles.AddUsersToRoles(new[] { "Jones.Ok" }, new[] { "Patient" });
            }

            if (context.Departments.Count() == 0)
            {
                context.Departments.Add(new Department
                {
                    DepartmentName = "Accident and emergency",
                    Description = "This department (sometimes called Casualty) is where you're likely to be taken if you've called an ambulance in an emergency. It's also where you should come if you've had an accident, but can make your own way to hospital. These departments operate 24 hours a day, every day and are staffed and equipped to deal with all emergencies. Patients are assessed and seen in order of need, usually with a separate minor injuries area supported by nurses."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Anaesthetics",
                    Description = "Doctors in this department give anaesthetic for operations. They are responsible for the provision of: acute pain services (pain relief after an operation); chronic pain services (pain relief in long-term conditions such as arthritis); critical care services (pain relief for those who have had a serious accident or trauma); obstetric anaesthesia and analgesia (epidurals in childbirth and anaesthetic for Caesarean sections)."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Breast screening",
                    Description = "This unit screens women for breast cancer, either through routine mammogram examinations or at the request of doctors. It's usually linked to an X-ray department."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Cardiology",
                    Description = "This department provides medical care to patients who have problems with their heart or circulation. It treats people on an inpatient and outpatient basis. Typical procedures performed include: electrocardiogram (ECG) and exercise tests to measure heart function; echocardiograms (ultrasound scan of the heart); scans of the carotid artery in your neck to determine stroke risk; 24-hour blood pressure tests; insertion of pacemakers; cardiac catheterisation (coronary angiography) to see if there are any blocks in your arteries."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Chaplaincy",
                    Description = "Chaplains promote the spiritual and pastoral wellbeing of patients, relatives and staff. They are available to all members of staff for confidential counsel and support irrespective of religion or race. A hospital chapel is also usually available."
                });

                context.Departments.Add(new Department
                {
                    DepartmentName = "Critical care",
                    Description = "Sometimes called intensive care, this unit is for the most seriously ill patients. It has a relatively small number of beds and is manned by specialist doctors and nurses, as well as by consultant anaesthetists, physiotherapists and dietitians. Patients requiring intensive care are often transferred from other hospitals or from other departments in the same hospital."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Discharge lounge",
                    Description = "Many hospitals now have discharge lounges to help your final day in hospital go smoothly.Patients who don't need to stay on the ward are transferred to the lounge on the day of discharge. Staff will inform the pharmacy, transport and relatives of your transfer.To help pass the time, there are usually facilities such as a TV, radio, magazines, puzzles, books and newspapers.If someone feels unwell while waiting, nurses contact a doctor to come and see you before discharge. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Ear nose and throat (ENT)",
                    Description = " The ENT department provides care for patients with a variety of problems, including: general ear, nose and throat diseases; neck lumps; cancers of the head and neck areatear duct problemsfacial skin lesions;balance and hearing disorders;snoring and sleep apnoea;ENT allergy problems;salivary gland diseases;voice disorders."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "General surgery",
                    Description = "The general surgery ward covers a wide range of surgery and includes:day surgery;thyroid surgery;kidney transplants;colon surgery;laparoscopic cholecystectomy (gallbladder removal);endoscopy;breast surgery. Day surgery units have a high turnover of patients who attend for minor surgical procedures such as hernia repairs.  "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Gynaecology",
                    Description = "These departments investigate and treat problems of the female urinary tract and reproductive organs, such as endometritis, infertility and incontinence. They also provide a range of care for cervical smear screening and post-menopausal bleeding checks. They usually have:a specialist ward;day surgery unit;emergency gynaecology assessment unit;outpatient clinics. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Haematology",
                    Description = "Haematology services work closely with the hospital laboratory. These doctors treat blood diseases and malignancies linked to the blood, with both new referrals and emergency admissions being seen. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Maternity departments",
                    Description = "Women now have a choice of who leads their maternity care and where they give birth. Care can be led by a consultant, a GP or a midwife.  wards provide antenatal care, care during childbirth and postnatal support.Antenatal clinics provide monitoring for both routine and complicated pregnancies.High-dependency units can offer one-to-one care for women who need close monitoring when there are complications in pregnancy or childbirth. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Microbiology",
                    Description = "The microbiology department looks at all aspects of microbiology, such as bacterial and viral infections.They have become increasingly high profile following the rise of hospital-acquired infections, such as MRSA and C. difficile. A head microbiology consultant and team of microbiologists test patient samples sent to them by medical staff from the hospital and from doctors' surgeries. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Nephrology",
                    Description = "This department monitors and assesses patients with kidney (renal) problems. Nephrologists (kidney specialists) will liaise with the transplant team in cases of kidney transplants.They also supervise the dialysis day unit for people who are waiting for a kidney transplant or who are unable to have a transplant for any reason. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Nutrition and dietetics",
                    Description = "Trained dieticians and nutritionists provide specialist advice on diet for hospital wards and outpatient clinics, forming part of a multidisciplinary team. The department works across a wide range of specialities such as:diabetes;cancer;kidney problems;paediatrics;elderly care;surgery and critical care;gastroenterology. They also provide group education to patients with diabetes, heart disease and osteoarthritis, and work closely with weight management groups."
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Obstetrics and gynaecology units",
                    Description = "These units provide maternity services such as:antenatal and postnatal care;prenatal diagnosis unit;maternal and foetal surveillance. Overseen by consultant obstetricians and gynaecologists, there is a wide range of attached staff linked to them, including specialist nurses, midwives and imaging technicians.Care can include:general inpatient and outpatient treatment;colposcopy, laser therapy or hysteroscopy for abnormal cervical cells;psychosexual counselling;recurrent miscarriage unit;early pregnancy unit. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Occupational therapy",
                    Description = "This profession helps people who are physically or mentally impaired, including temporary disability after medical treatment. It practices in the fields of both healthcare and social care.The aim of occupational therapy is to restore physical and mental functioning to help people participate in life to the fullest.Occupational therapy assessments often guide hospital discharge planning, with the majority of patients given a home assessment to understand their support needs. Staff also arrange provision of essential equipment and adaptations that are essential for discharge from hospital. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Pharmacy",
                    Description = "The hospital pharmacy is run by pharmacists, pharmacy technicians and attached staff.It's responsible for drug-based services in the hospital, including:the purchasing, supply and distribution of medication and pharmaceuticals;inpatient and outpatient dispensing;clinical and ward pharmacy;the use of drugs. A pharmacy will provide a drug formulary for hospital doctors to use as a guide. It will also help supervise any clinical trial management and ward drug-use review. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Rheumatology",
                    Description = "Specialist doctors called rheumatologists run the unit and are experts in the field of musculoskeletal disorders (bones, joints, ligaments, tendons, muscles and nerves).Their role is to diagnose conditions and recommend appropriate treatment, if necessary from the orthopaedic department.The rheumatologist may need to review you regularly, either in person or via one of the rheumatology team.Alternatively, your condition may be one your GP can manage in the community. Many conditions are managed jointly between the GP and the hospital care team. "
                });
                context.Departments.Add(new Department
                {
                    DepartmentName = "Urology",
                    Description = "The urology department is run by consultant urology surgeons and their surgical teams. It investigates all areas linked to kidney and bladder-based problems.The department performs:flexible cystoscopy bladder checks;urodynamic studies (eg for incontinence);prostate assessments and biopsies;shockwave lithotripsy to break up kidney stones. "
                });
                context.SaveChanges();
            }

            if (!WebSecurity.UserExists("Dr.Mao"))
            {
                context.AttendingPhysicians.Add(new AttendingPhysician
                {
                    UserName = "Dr.Mao",
                    Email = "professor@uwlax.gov",
                    Name = "Mao Zheng",
                    Phone = "608-385-9238",
                    SSN = "987-65-4320",
                    Department = context.Departments.First(item => item.DepartmentName.Equals("Accident and emergency"))
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Dr.Mao", "123456");
                Roles.AddUsersToRoles(new[] { "Dr.Mao" }, new[] { "AttendingPhysician" });
            }

            if (!WebSecurity.UserExists("Dr.Bidden"))
            {
                context.AttendingPhysicians.Add(new AttendingPhysician
                {
                    UserName = "Dr.Bidden",
                    Email = "masterBu@uwlax.gov",
                    Name = "Bush Bidden",
                    Phone = "608-123-4392",
                    SSN = "987-65-3211",
                    Department = context.Departments.First(item => item.DepartmentName.Equals("Cardiology"))
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Dr.Bidden", "123456");
                Roles.AddUsersToRoles(new[] { "Dr.Bidden" }, new[] { "AttendingPhysician" });
            }

            if (!WebSecurity.UserExists("Dr.Allen"))
            {
                context.AttendingPhysicians.Add(new AttendingPhysician
                {
                    UserName = "Dr.Allen",
                    Email = "allenTeam@uwlax.gov",
                    Name = "Allen Reed",
                    Phone = "795-122-4393",
                    SSN = "977-65-2131",
                    Department = context.Departments.First(item => item.DepartmentName.Equals("Critical care"))
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Dr.Allen", "123456");
                Roles.AddUsersToRoles(new[] { "Dr.Allen" }, new[] { "AttendingPhysician" });
            }

            if (!WebSecurity.UserExists("Dr.Max"))
            {
                context.AttendingPhysicians.Add(new AttendingPhysician
                {
                    UserName = "Dr.Max",
                    Email = "carlhardworking@uwlax.gov",
                    Name = "Max Carl",
                    Phone = "795-155-2336",
                    SSN = "972-34-2253",
                    Department = context.Departments.First(item => item.DepartmentName.Equals("Nephrology"))
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Dr.Max", "123456");
                Roles.AddUsersToRoles(new[] { "Dr.Max" }, new[] { "AttendingPhysician" });
            }

            if (!WebSecurity.UserExists("Dr.Tim"))
            {
                context.AttendingPhysicians.Add(new AttendingPhysician
                {
                    UserName = "Dr.Tim",
                    Email = "fantascymovie@gmail.com",
                    Name = "Borden Tim",
                    Phone = "652-897-8971",
                    SSN = "762-22-0981",
                    Department = context.Departments.First(item => item.DepartmentName.Equals("Discharge lounge"))
                });
                context.SaveChanges();
                WebSecurity.CreateAccount("Dr.Tim", "123456");
                Roles.AddUsersToRoles(new[] { "Dr.Tim" }, new[] { "AttendingPhysician" });
            }

            if (context.InsuranceCompanies.Count() == 0)
            {
                context.InsuranceCompanies.Add(new InsuranceCompany
                {
                    CompanyName = "Dean Health Plan, Inc.",
                    Address = "N544 Silver Creek Cascade Rd, Random Lake, Wisconsin USA 53075.",
                    ContactInfo = "Tel: 920-994-9433"
                });
                context.InsuranceCompanies.Add(new InsuranceCompany
                {
                    CompanyName = "Arise Health Plan, Inc.",
                    Address = "100 S. Baldwin St, Suite 308, Madison, Wisconsin USA 53708.",
                    ContactInfo = "Tel: 877-229-9201 Fax: 866-762-7496"
                });
                context.InsuranceCompanies.Add(new InsuranceCompany
                {
                    CompanyName = "United Health One",
                    Address = "104 N. Main, Viroqua, Wisconsin USA 54665-1604.",
                    ContactInfo = "Tel: 608-637-2722 Fax: 608-637-6458"
                });
                context.InsuranceCompanies.Add(new InsuranceCompany
                {
                    CompanyName = "Humana",
                    Address = "314 East Maple Street, Woodville, Wisconsin USA 54028.",
                    ContactInfo = "Tel: 715-698-4350 Fax: 877-687-8801"
                });
                context.InsuranceCompanies.Add(new InsuranceCompany
                {
                    CompanyName = "Celtic Ins. Co.",
                    Address = "1500 West Main Street, Suite 300, Sun Prairie, Wisconsin USA 53590.",
                    ContactInfo = "Tel: 608-837-0111 Fax: 608-837-0181"
                });
                context.SaveChanges();
            }

            if (context.InsurancePolicies.Count() == 0)
            {
                context.InsurancePolicies.Add(new InsurancePolicy
                {
                    PolicyName = "Group Criti9",
                    Description = "Group Criti9 is a traditional non participating Group Health Plan. This plan provides protection against 9 critical illnesses where Sum Assured is paid in lump sum on diagnosis of any one of covered critical illnesses. So provides you money at time when you need it most.",
                    PolicyNumber = "UNI00-124J7",
                    PolicyType = PolicyType.HMO
                });
                context.InsurancePolicies.Add(new InsurancePolicy
                {
                    PolicyName = "Hospital Cash",
                    Description = "Good health is the most valuable asset that we have, but nowadays with increasing levels of stress, negligible physical activity and changing lifestyle our vulnerability to diseases is increasing at an alarming pace. ",
                    PolicyNumber = "UNI00-834MC",
                    PolicyType = PolicyType.HMO
                });
                context.InsurancePolicies.Add(new InsurancePolicy
                {
                    PolicyName = "MedicareRx Saver Plus",
                    Description = "Lowest premium, plus coverage for most commonly used prescription drugs.\nThe drug list includes most generic drugs covered by Medicare Part D and many commonly used brand name drugs.\nYou pay no more than 79% of the total cost for generic drugs or 47.5% of the total cost for brand name drugs, for any drug tier during the coverage gap.",
                    PolicyNumber = "UNI00-224J9",
                    PolicyType = PolicyType.POS
                });
                context.InsurancePolicies.Add(new InsurancePolicy
                {
                    PolicyName = "MedicareRx Preferred",
                    Description = "The plan chosen by most of our members. A good value with robust drug coverage.\nThe drug list includes nearly all generic drugs covered by Medicare Part D and most commonly used brand name drugs.\nYou pay no more than 79% of the total cost for generic drugs or 47.5% of the total cost for brand name drugs, for any drug tier during the coverage gap.",
                    PolicyNumber = "UNI00-32432",
                    PolicyType = PolicyType.PPO
                });
                context.InsurancePolicies.Add(new InsurancePolicy
                {
                    PolicyName = "MedicareRx Enhanced",
                    Description = "Best coverage with a more extensive drug list. \nThe drug list includes more than 95% of drugs covered by Medicare Part D.\nThis plan provides coverage in the coverage gap for all Tier 1 and Tier 2 drugs, and select Tier 3, 4, and 5 brand name drugs. In addition, you pay no more than 79% of the total cost for generic drugs or 47.5% of the total cost for brand name drugs, for any drug tier during the coverage gap.",
                    PolicyNumber = "UNI00-03945",
                    PolicyType = PolicyType.HMO
                });
                context.SaveChanges();
            }

        }
    }
}

