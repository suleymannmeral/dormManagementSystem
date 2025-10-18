using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YurtYonetimSistemi.Domain.Entities;

namespace YurtYonetimSistemi.Persistence.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<FaultConfiguration> Faults { get; set; }
    public DbSet<Announcement> Announcements { get; set; }  
    public DbSet<Dorm> Dorms { get; set; }

    }
