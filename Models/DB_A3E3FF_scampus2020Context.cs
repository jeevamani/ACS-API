using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Interview.Models
{
    public partial class DB_A3E3FF_scampus2020Context : DbContext
    {
        public DB_A3E3FF_scampus2020Context()
        {
        }

        public DB_A3E3FF_scampus2020Context(DbContextOptions<DB_A3E3FF_scampus2020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalCourse> AdditionalCourse { get; set; }
        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        public virtual DbSet<CertificateUpload> CertificateUpload { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseModule> CourseModule { get; set; }
        public virtual DbSet<InBranch> InBranch { get; set; }
        public virtual DbSet<InDepartment> InDepartment { get; set; }
        public virtual DbSet<InDesignation> InDesignation { get; set; }
        public virtual DbSet<InFileUpload> InFileUpload { get; set; }
        public virtual DbSet<InStaff> InStaff { get; set; }
        public virtual DbSet<InState> InState { get; set; }
        public virtual DbSet<InSubUser> InSubUser { get; set; }
        public virtual DbSet<InUserRole> InUserRole { get; set; }
        public virtual DbSet<MainCourse> MainCourse { get; set; }
        public virtual DbSet<StudentDetails> StudentDetails { get; set; }
        public virtual DbSet<StudentFee> StudentFee { get; set; }
        public virtual DbSet<StudentIdupload> StudentIdupload { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sql6009.site4now.net;Database=DB_A3E3FF_scampus2020;User Id= DB_A3E3FF_scampus2020_admin; Password=Admin@526474;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalCourse>(entity =>
            {
                entity.HasKey(e => e.AditionalCourseId)
                    .HasName("PK__Addition__C14FCABB5347A6A1");

                entity.Property(e => e.AditionalCourseId)
                    .HasColumnName("AditionalCourseID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CourseEndDate).HasColumnType("datetime");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AdminUsers>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__AdminUse__CBA1B257C68C369B");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccountStatus)
                    .HasColumnName("account_status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Baseurl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigSettings).HasColumnName("configSettings");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CertificateUpload>(entity =>
            {
                entity.HasKey(e => e.CertificteUploadId)
                    .HasName("PK__Certific__2E3E151CB37DDBB9");

                entity.Property(e => e.CertificteUploadId)
                    .HasColumnName("CertificteUploadID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RefNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadFileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadFileTitile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadFileType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdditionalCourseId).HasColumnName("AdditionalCourseID");

                entity.Property(e => e.Batch)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CourseStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountAmount)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeeDiscountApplicable).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdproofNumber)
                    .HasColumnName("IDProofNumber")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdproofType)
                    .HasColumnName("IDProofType")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MainCourseId).HasColumnName("MainCourseID");

                entity.Property(e => e.ReferredPerson)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RegistratioinNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RollNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfEnquiry)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TypeOfDiscount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AdditionalCourse)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.AdditionalCourseId)
                    .HasConstraintName("FK__Course__Addition__7755B73D");

                entity.HasOne(d => d.MainCourse)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.MainCourseId)
                    .HasConstraintName("FK__Course__MainCour__76619304");
            });

            modelBuilder.Entity<CourseModule>(entity =>
            {
                entity.ToTable("Course_Module");

                entity.Property(e => e.CourseModuleId)
                    .HasColumnName("CourseModuleID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ContentDuration).IsUnicode(false);

                entity.Property(e => e.ContentMaterial).IsUnicode(false);

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CourseContent).IsUnicode(false);

                entity.Property(e => e.CourseDuration)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CourseFee)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CourseSubject).IsUnicode(false);

                entity.Property(e => e.CourseTitle)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CourseTopics).IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FeeDiscountforReference)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeeDiscountforjoin)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeeInstallment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeePaymentDuration)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeeRemainder)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__In_Branc__A1682FA5723D10C9");

                entity.ToTable("In_Branch");

                entity.Property(e => e.BranchId)
                    .HasColumnName("BranchID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Apikey)
                    .HasColumnName("APIKey")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchLogo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigId).HasColumnName("ConfigID");

                entity.Property(e => e.ContactNumber1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrintFooterFile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PrintHeaderFile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SenderId)
                    .HasColumnName("SenderID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Smsapiurl)
                    .HasColumnName("SMSAPIURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InDepartment>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__In_Depar__0148818ED8E62C71");

                entity.ToTable("In_Department");

                entity.Property(e => e.DeptId)
                    .HasColumnName("DeptID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InDesignation>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__In_Desig__BABD603E7B99348B");

                entity.ToTable("In_Designation");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("DesignationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InFileUpload>(entity =>
            {
                entity.HasKey(e => e.UploadId)
                    .HasName("PK__In_FileU__6D16C86DA8300501");

                entity.ToTable("In_FileUpload");

                entity.Property(e => e.UploadId)
                    .HasColumnName("UploadID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FileTitle)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FileType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<InStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__In_Staff__96D4AAF7FB144238");

                entity.ToTable("In_Staff");

                entity.Property(e => e.StaffId)
                    .HasColumnName("StaffID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CertificateTitle).IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeContactNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdcardType)
                    .HasColumnName("IDCardType")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idnumber)
                    .HasColumnName("IDNumber")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PreviousCompany)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadId)
                    .HasColumnName("UploadID")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.InStaff)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__In_Staff__Branch__70DDC3D8");
            });

            modelBuilder.Entity<InState>(entity =>
            {
                entity.ToTable("In_State");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InSubUser>(entity =>
            {
                entity.ToTable("In_SubUser");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ConfigId).HasColumnName("Config_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasColumnName("Email_id")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubUserName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InUserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__In_UserR__8AFACE3A51228E92");

                entity.ToTable("In_UserRole");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MainCourse>(entity =>
            {
                entity.Property(e => e.MainCourseId)
                    .HasColumnName("MainCourseID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentDetails>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Student___32C52A7920410605");

                entity.ToTable("Student_Details");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdditionalCourseId).HasColumnName("AdditionalCourseID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.AlternateMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CourseStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MainCourseId).HasColumnName("MainCourseID");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParentMobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ParentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistratioinNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RollNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfEnquiry)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFname)
                    .HasColumnName("StudentFName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentLname)
                    .HasColumnName("StudentLName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentMname)
                    .HasColumnName("StudentMName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentPhoto)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdditionalCourse)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.AdditionalCourseId)
                    .HasConstraintName("FK__Student_D__Addit__0B5CAFEA");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Student_D__Branc__09746778");

                entity.HasOne(d => d.MainCourse)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.MainCourseId)
                    .HasConstraintName("FK__Student_D__MainC__0A688BB1");
            });

            modelBuilder.Entity<StudentFee>(entity =>
            {
                entity.Property(e => e.StudentFeeId)
                    .HasColumnName("StudentFeeID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DiscountAmount)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FeeAmmount)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ReferedPerson)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentIdupload>(entity =>
            {
                entity.HasKey(e => e.StudentUploadId)
                    .HasName("PK__StudentI__79DC0FD395A5F40E");

                entity.ToTable("StudentIDUpload");

                entity.Property(e => e.StudentUploadId)
                    .HasColumnName("StudentUploadID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RefNumber)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadFileName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadFileTitile)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadFileType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UploadPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
