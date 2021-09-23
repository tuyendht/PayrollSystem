using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PayrollSystem.Models.DB
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

        public virtual DbSet<Atribute> Atributes { get; set; }
        public virtual DbSet<AtributeGroup> AtributeGroups { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ComponentItem> ComponentItems { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAtribute> EmployeeAtributes { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<PayPeroid> PayPeroids { get; set; }
        public virtual DbSet<PaySlip> PaySlips { get; set; }
        public virtual DbSet<PaySlipItem> PaySlipItems { get; set; }
        public virtual DbSet<PeroidAtribute> PeroidAtributes { get; set; }
        public virtual DbSet<SalaryComponent> SalaryComponents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SE140046;Initial Catalog=PayrollSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Atribute>(entity =>
            {
                entity.HasKey(e => e.AtrId)
                    .HasName("PK__Atribute__0971CCFD149C1602");

                entity.ToTable("Atribute");

                entity.Property(e => e.AtrId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("atrID");

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Atributes)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__Atribute__ID__48CFD27E");
            });

            modelBuilder.Entity<AtributeGroup>(entity =>
            {
                entity.ToTable("AtributeGroup");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("comID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.AtributeGroups)
                    .HasForeignKey(d => d.ComId)
                    .HasConstraintName("FK__AtributeG__comID__45F365D3");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.ComId)
                    .HasName("PK__Company__9052B576308AE046");

                entity.ToTable("Company");

                entity.HasIndex(e => e.Email, "UQ__Company__A9D10534331288D7")
                    .IsUnique();

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("comID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComponentItem>(entity =>
            {
                entity.HasKey(e => e.ComponentItemId)
                    .HasName("PK__Componen__114B3873B051351A");

                entity.ToTable("ComponentItem");

                entity.Property(e => e.ComponentItemId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ComponentItemID");

                entity.Property(e => e.Formula).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.ComponentItems)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__ComponentIte__ID__6477ECF3");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK__Departme__00D7A2936789A461");

                entity.ToTable("Department");

                entity.Property(e => e.DepId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("depID");

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("comID");

                entity.Property(e => e.MgrCode).HasColumnName("mgrCode");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NumEmployee).HasColumnName("numEmployee");

                entity.Property(e => e.Office).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ComId)
                    .HasConstraintName("FK__Departmen__comID__398D8EEE");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AFB3EC6D5534F950");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "UQ__Employee__AB6E616407E65607")
                    .IsUnique();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("empID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DepId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("depID");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasDefaultValueSql("((1))");

                entity.Property(e => e.StillWorking)
                    .HasColumnName("stillWorking")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Employee__depID__4316F928");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__Employee__ID__4222D4EF");
            });

            modelBuilder.Entity<EmployeeAtribute>(entity =>
            {
                entity.ToTable("EmployeeAtribute");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.AtrId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("atrID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("empID");

                entity.Property(e => e.QuantityValue).HasColumnName("quantityValue");

                entity.Property(e => e.UpdateBy).HasMaxLength(100);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Atr)
                    .WithMany(p => p.EmployeeAtributes)
                    .HasForeignKey(d => d.AtrId)
                    .HasConstraintName("FK__EmployeeA__atrID__4D94879B");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmployeeAtributes)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__EmployeeA__empID__4CA06362");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.TypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<PayPeroid>(entity =>
            {
                entity.HasKey(e => e.PayPeriodId)
                    .HasName("PK__PayPeroi__66B8DF9EBA6B1F23");

                entity.ToTable("PayPeroid");

                entity.Property(e => e.PayPeriodId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PayPeriodID");

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("comID");

                entity.Property(e => e.PayPeriodName).HasMaxLength(100);

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.PayPeroids)
                    .HasForeignKey(d => d.ComId)
                    .HasConstraintName("FK__PayPeroid__comID__5070F446");
            });

            modelBuilder.Entity<PaySlip>(entity =>
            {
                entity.ToTable("PaySlip");

                entity.Property(e => e.PaySlipId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaySlipID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("empID");

                entity.Property(e => e.PayPeriodId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PayPeriodID");

                entity.Property(e => e.Payment).HasMaxLength(100);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__PaySlip__empID__5812160E");

                entity.HasOne(d => d.PayPeriod)
                    .WithMany(p => p.PaySlips)
                    .HasForeignKey(d => d.PayPeriodId)
                    .HasConstraintName("FK__PaySlip__PayPeri__59063A47");
            });

            modelBuilder.Entity<PaySlipItem>(entity =>
            {
                entity.ToTable("PaySlipItem");

                entity.Property(e => e.PaySlipItemId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaySlipItemID");

                entity.Property(e => e.ComponentItemId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ComponentItemID");

                entity.Property(e => e.Deduction).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Earning).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaySlipId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PaySlipID");

                entity.Property(e => e.PaySlipItemName).HasMaxLength(100);

                entity.HasOne(d => d.ComponentItem)
                    .WithMany(p => p.PaySlipItems)
                    .HasForeignKey(d => d.ComponentItemId)
                    .HasConstraintName("FK__PaySlipIt__Compo__6754599E");

                entity.HasOne(d => d.PaySlip)
                    .WithMany(p => p.PaySlipItems)
                    .HasForeignKey(d => d.PaySlipId)
                    .HasConstraintName("FK__PaySlipIt__PaySl__68487DD7");
            });

            modelBuilder.Entity<PeroidAtribute>(entity =>
            {
                entity.ToTable("PeroidAtribute");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.AtrId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("atrID");

                entity.Property(e => e.AtributeName)
                    .HasMaxLength(100)
                    .HasColumnName("atributeName");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("empID");

                entity.Property(e => e.PayPeriodId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PayPeriodID");

                entity.HasOne(d => d.Atr)
                    .WithMany(p => p.PeroidAtributes)
                    .HasForeignKey(d => d.AtrId)
                    .HasConstraintName("FK__PeroidAtr__atrID__534D60F1");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.PeroidAtributes)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__PeroidAtr__empID__5535A963");

                entity.HasOne(d => d.PayPeriod)
                    .WithMany(p => p.PeroidAtributes)
                    .HasForeignKey(d => d.PayPeriodId)
                    .HasConstraintName("FK__PeroidAtr__PayPe__5441852A");
            });

            modelBuilder.Entity<SalaryComponent>(entity =>
            {
                entity.ToTable("SalaryComponent");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ComId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("comID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.SalaryComponents)
                    .HasForeignKey(d => d.ComId)
                    .HasConstraintName("FK__SalaryCom__comID__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
