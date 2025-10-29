using YurtYonetimSistemi.Identity.Models;
using YurtYonetimSistemi.Persistence.Context;

namespace YurtYonetimSistemi.API.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityExt(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>();

        return services;    
    }

}
