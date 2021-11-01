using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PayrollSystem.Models
{
    public partial class PayrollSystemContext : DbContext
    {
        public PayrollSystemContext()
        {
        }

        public PayrollSystemContext(DbContextOptions<PayrollSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Hraccount> Hraccounts { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<LegalStructure> LegalStructures { get; set; }
        public virtual DbSet<ManagePayroll> ManagePayrolls { get; set; }
        public virtual DbSet<PaySchedule> PaySchedules { get; set; }
        public virtual DbSet<PayScheduleType> PayScheduleTypes { get; set; }
        public virtual DbSet<PaySlip> PaySlips { get; set; }
        public virtual DbSet<PaySlipDetail> PaySlipDetails { get; set; }
        public virtual DbSet<PayStatus> PayStatuses { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=PayrollSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TaxCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("taxCode");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.BankNumber).HasColumnName("bankNumber");

                entity.Property(e => e.CitizenIdentification).HasColumnName("citizenIdentification");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentID");

                entity.Property(e => e.FirstDayAtWork)
                    .HasColumnType("date")
                    .HasColumnName("firstDayAtWork");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.PaymentType).HasColumnName("paymentType");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.SalaryId).HasColumnName("salaryID");

                entity.Property(e => e.TaxCode).HasColumnName("taxCode");

                entity.Property(e => e.WorkEmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("workEmailAddress");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Company");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<FeedBack>(entity =>
            {
                entity.ToTable("FeedBack");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.PaySlipId).HasColumnName("paySlipID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__FeedBack__employ__3A4CA8FD");

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.PaySlipId)
                    .HasConstraintName("FK_FeedBack_PaySlip");
            });

            modelBuilder.Entity<Hraccount>(entity =>
            {
                entity.ToTable("HRAccount");

                entity.HasIndex(e => e.EmailAddress, "UQ__HRAccoun__347C3027EE957465")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industry");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Industries)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Industry_Company");
            });

            modelBuilder.Entity<LegalStructure>(entity =>
            {
                entity.ToTable("LegalStructure");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.LegalStructures)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_LegalStructure_Company");
            });

            modelBuilder.Entity<ManagePayroll>(entity =>
            {
                entity.ToTable("ManagePayroll");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.HrId).HasColumnName("hrID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ManagePayrolls)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagePayroll_Company");

                entity.HasOne(d => d.Hr)
                    .WithMany(p => p.ManagePayrolls)
                    .HasForeignKey(d => d.HrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagePayroll_HRAccount");
            });

            modelBuilder.Entity<PaySchedule>(entity =>
            {
                entity.ToTable("PaySchedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.OtherPayDay)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("otherPayDay");

                entity.Property(e => e.PayDay)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payDay");

                entity.Property(e => e.PayScheduleTypeId).HasColumnName("payScheduleTypeID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaySchedules)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySchedule_Company");

                entity.HasOne(d => d.PayScheduleType)
                    .WithMany(p => p.PaySchedules)
                    .HasForeignKey(d => d.PayScheduleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySchedule_PayScheduleType");
            });

            modelBuilder.Entity<PayScheduleType>(entity =>
            {
                entity.ToTable("PayScheduleType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PaySlip>(entity =>
            {
                entity.ToTable("PaySlip");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.PayDate)
                    .HasColumnType("date")
                    .HasColumnName("payDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PayPeriodBeginDate)
                    .HasColumnType("date")
                    .HasColumnName("payPeriodBeginDate");

                entity.Property(e => e.PayPeriodEndDate)
                    .HasColumnType("date")
                    .HasColumnName("payPeriodEndDate");

                entity.Property(e => e.PaySlipDetailId).HasColumnName("paySlipDetailID");

                entity.Property(e => e.PayStatusId).HasColumnName("payStatusID");

                entity.Property(e => e.TotalNetPayroll).HasColumnName("totalNetPayroll");

                entity.Property(e => e.TotalPayrollCost).HasColumnName("totalPayrollCost");

                entity.Property(e => e.Totaltax).HasColumnName("totaltax");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__PaySlip__employe__19DFD96B");

                entity.HasOne(d => d.PaySlipDetail)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.PaySlipDetailId)
                    .HasConstraintName("FK__PaySlip__paySlip__2739D489");

                entity.HasOne(d => d.PayStatus)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.PayStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlip_PayStatus");
            });

            modelBuilder.Entity<PaySlipDetail>(entity =>
            {
                entity.ToTable("PaySlipDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Benefit).HasColumnName("benefit");

                entity.Property(e => e.Bonus).HasColumnName("bonus");

                entity.Property(e => e.Deduction).HasColumnName("deduction");

                entity.Property(e => e.DoubletimeWorkingHours).HasColumnName("doubletimeWorkingHours");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.GrossPay).HasColumnName("grossPay");

                entity.Property(e => e.HoursOff).HasColumnName("hoursOff");

                entity.Property(e => e.NetPay).HasColumnName("netPay");

                entity.Property(e => e.OvertimeWorkingHours).HasColumnName("overtimeWorkingHours");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.WorkingHours).HasColumnName("workingHours");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PaySlipDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaySlipDetail_Employee");
            });

            modelBuilder.Entity<PayStatus>(entity =>
            {
                entity.ToTable("PayStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Salary");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_Salary_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
