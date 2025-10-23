using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YurtYonetimSistemi.Application.Features.Announcements;
using YurtYonetimSistemi.Application.Features.Dorms;
using YurtYonetimSistemi.Application.Features.Faults;
using YurtYonetimSistemi.Application.Features.Meals;
using YurtYonetimSistemi.Application.Features.Menus;
using YurtYonetimSistemi.Application.Features.Rooms;
using YurtYonetimSistemi.Application.Features.Staffs;
using YurtYonetimSistemi.Application.Features.Students;

namespace YurtYonetimSistemi.Application;



public static class DependencyInjection
{
    public static IServiceCollection AddServicesExt(this IServiceCollection services, IConfiguration configuration)
    {
 
        services.AddScoped<IAnnouncementService,AnnouncementService>();
        services.AddScoped<IDormService, DormService>();
        services.AddScoped<IFaultService, FaultService>();
        services.AddScoped<IMealService, MealService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IStudentService, StudentService>();


        return services;
    }

}
