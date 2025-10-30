using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YurtYonetimSistemi.Application.Features.Users;

namespace YurtYonetimSistemi.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserExt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUserService, UserService>();


            return services;
        }

    }

}
