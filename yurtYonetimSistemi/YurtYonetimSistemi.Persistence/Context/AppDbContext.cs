using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using YurtYonetimSistemi.Domain.Entities;
using YurtYonetimSistemi.Identity.Models;

namespace YurtYonetimSistemi.Persistence.Context;
public class AppDbContext: IdentityDbContext<ApplicationUser, Role, int>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    

        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityUserRole<int>>();
        modelBuilder.Ignore<IdentityUserClaim<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityRoleClaim<int>>();
        modelBuilder.Ignore<IdentityRole<int>>();

    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Fault> Faults { get; set; }
    public DbSet<Announcement> Announcements { get; set; }  
    public DbSet<Dorm> Dorms { get; set; }
    public DbSet<StudentLeave> StudentLeaves { get; set; }


}
