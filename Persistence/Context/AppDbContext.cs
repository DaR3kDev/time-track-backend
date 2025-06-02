using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectAssignment> ProjectAssignments => Set<ProjectAssignment>();
    public DbSet<WorkLog> WorkLogs => Set<WorkLog>();
    public DbSet<DailyAttendance> DailyAttendances => Set<DailyAttendance>();
    public DbSet<Absence> Absences => Set<Absence>();
    public DbSet<Salary> Salaries => Set<Salary>();
    public DbSet<Payroll> Payrolls => Set<Payroll>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Holiday> Holidays => Set<Holiday>();
    public DbSet<MinimumWage> MinimumWages => Set<MinimumWage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Enums como string
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>()
            .HasDefaultValue(RoleEnum.EMPLOYEE);

        modelBuilder.Entity<WorkLog>()
            .Property(w => w.Type)
            .HasConversion<string>();

        modelBuilder.Entity<DailyAttendance>()
            .Property(d => d.Status)
            .HasConversion<string>();

        modelBuilder.Entity<DailyAttendance>()
            .Property(d => d.WorkType)
            .HasConversion<string?>();

        modelBuilder.Entity<Absence>()
            .Property(a => a.Reason)
            .HasConversion<string>();

        modelBuilder.Entity<Holiday>()
            .Property(h => h.Type)
            .HasConversion<string>();

        // Precisión de decimales
        modelBuilder.Entity<Salary>()
            .Property(s => s.Amount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<MinimumWage>()
            .Property(m => m.Amount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<DailyAttendance>()
            .Property(d => d.TotalHours)
            .HasPrecision(5, 2);

        modelBuilder.Entity<DailyAttendance>()
            .Property(d => d.CalculatedPay)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Payroll>()
            .Property(p => p.BaseAmount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Payroll>()
            .Property(p => p.OvertimeAmount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Payroll>()
            .Property(p => p.Deductions)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Payroll>()
            .Property(p => p.TotalPaid)
            .HasPrecision(10, 2);

        modelBuilder.Entity<WorkLog>()
            .Property(w => w.TotalHours)
            .HasPrecision(5, 2);

        // Índices
        modelBuilder.Entity<Holiday>()
            .HasIndex(h => h.Date)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Name)
            .IsUnique();

        modelBuilder.Entity<Project>()
            .HasIndex(p => p.Name);

        modelBuilder.Entity<DailyAttendance>()
            .HasIndex(d => new { d.UserId, d.Date })
            .IsUnique();

        // Relaciones
        modelBuilder.Entity<User>()
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Country)
            .WithMany()
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Holiday>()
            .HasOne(h => h.Country)
            .WithMany()
            .HasForeignKey(h => h.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Holiday>()
            .HasOne(h => h.Department)
            .WithMany()
            .HasForeignKey(h => h.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProjectAssignment>()
            .HasOne(pa => pa.User)
            .WithMany(u => u.ProjectAssignments)
            .HasForeignKey(pa => pa.UserId);

        modelBuilder.Entity<ProjectAssignment>()
            .HasOne(pa => pa.Project)
            .WithMany(p => p.ProjectAssignments)
            .HasForeignKey(pa => pa.ProjectId);

        modelBuilder.Entity<WorkLog>()
            .HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<WorkLog>()
            .HasOne(w => w.Project)
            .WithMany()
            .HasForeignKey(w => w.ProjectId);

        modelBuilder.Entity<Absence>()
            .HasOne(a => a.User)
            .WithMany(u => u.Absences)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<DailyAttendance>()
            .HasOne(d => d.User)
            .WithMany(u => u.DailyAttendances)
            .HasForeignKey(d => d.UserId);

        modelBuilder.Entity<Salary>()
            .HasOne(s => s.User)
            .WithMany(u => u.Salaries)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.User)
            .WithMany(u => u.Payrolls)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<MinimumWage>()
            .HasOne(m => m.Country)
            .WithMany()
            .HasForeignKey(m => m.CountryId);

        // Timestamp automático
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entity.ClrType))
            {
                modelBuilder.Entity(entity.ClrType)
                    .Property("CreatedAt")
                    .HasDefaultValueSql("now()");
            }
        }
    }
}
