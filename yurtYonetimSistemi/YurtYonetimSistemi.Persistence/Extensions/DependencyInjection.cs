using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YurtYonetimSistemi.Application.Contracts.Persistence;
using YurtYonetimSistemi.Persistence.Context;
using YurtYonetimSistemi.Persistence.Faults;
using YurtYonetimSistemi.Persistence.Meals;
using YurtYonetimSistemi.Persistence.Menus;
using YurtYonetimSistemi.Persistence.Options;
using YurtYonetimSistemi.Persistence.Rooms;
using YurtYonetimSistemi.Persistence.Students;

namespace YurtYonetimSistemi.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceExt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStrings =
                configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

            options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
            {
    
                sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
            });

        });
        // use scrutor to register all repositories in assembly (later)
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IDormRepository, DormRepository>();
        services.AddScoped<IFaultRepository, FaultRepository>();
        services.AddScoped<IMealRepository, MealRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));


        return services;
    }

}
