
using FOS.Infrastructure.Services.IdentityServices;
using FOS.Repository.Implementors;
using FOS.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomIdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddUserStore(this IIdentityServerBuilder builder,IConfiguration configuration)
        {
            builder.Services.AddSingleton<IUserRepository, UserRepository>(s=>new UserRepository(configuration.GetConnectionString("FOSConnectionString")!));
            builder.AddProfileService<UserProfileService>();
            builder.AddResourceOwnerValidator<UserResouceOwnerPasswordValidator>();

            return builder;
        }
    }
}