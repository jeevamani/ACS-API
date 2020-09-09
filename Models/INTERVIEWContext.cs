using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Interview.Models
{
    public partial class InterviewContext : DbContext
    {
        public InterviewContext()
        {
        }

        public InterviewContext(DbContextOptions<InterviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConfigurationMaster> ConfigurationMaster { get; set; }
        public virtual DbSet<InConfiguration> InConfiguration { get; set; }
        public virtual DbSet<InUsers> InUsers { get; set; }
        public virtual DbSet<TblDepatment> TblDepatment { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Interview;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationMaster>(entity =>
            {
                entity.HasKey(e => e.ConfigId)
                    .HasName("PK__Configur__C3BC335C8A63AF21");

                entity.Property(e => e.ConfigId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccoutExpiryDate)
                    .HasColumnName("Accout_Expiry_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BaseUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BrandCode)
                    .HasColumnName("Brand_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrandLogo)
                    .HasColumnName("Brand_logo")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MaxDurationOfConference)
                    .HasColumnName("Max_Duration_of_Conference")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxNoOfVideoRecording).HasColumnName("Max_No_of_Video_Recording");

                entity.Property(e => e.MaxParticipantInConference).HasColumnName("Max_Participant_in_Conference");

                entity.Property(e => e.NoOfBranches).HasColumnName("No_of_Branches");

                entity.Property(e => e.NoOfStaff).HasColumnName("No_of_Staff");

                entity.Property(e => e.NoOfStudent).HasColumnName("No_of_Student");

                entity.Property(e => e.NoOfVideoConferenceDaily).HasColumnName("No_of_Video_Conference_Daily");

                entity.Property(e => e.PageTitle)
                    .HasColumnName("Page_title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InConfiguration>(entity =>
            {
                entity.HasKey(e => e.ConfId)
                    .HasName("PK__In_Confi__67769963426CC7E4");

                entity.ToTable("In_Configuration");

                entity.Property(e => e.ConfId)
                    .HasColumnName("Conf_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

              
            });

            modelBuilder.Entity<InUsers>(entity =>
            {
                entity.ToTable("In_Users");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BaseUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDepatment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__tbl_Depa__63E61362F59EF89D");

                entity.ToTable("tbl_Depatment");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tbl_Empl__CBA14F48445E5A30");

                entity.ToTable("tbl_Employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EMPLOYEE_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATED_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeDepartment)
                    .HasColumnName("EMPLOYEE_DEPARTMENT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeDob)
                    .HasColumnName("EMPLOYEE_DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeEmail)
                    .HasColumnName("EMPLOYEE_EMAIL")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeGender)
                    .HasColumnName("EMPLOYEE_GENDER")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("EMPLOYEE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePhone)
                    .HasColumnName("EMPLOYEE_PHONE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Isactive)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UPDATED_BY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("UPDATED_DATE")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
