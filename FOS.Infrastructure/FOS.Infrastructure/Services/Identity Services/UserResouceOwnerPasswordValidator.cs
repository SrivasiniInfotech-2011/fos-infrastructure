using FOS.Repository.Interfaces;
using IdentityModel;
using IdentityServer4.Validation;
using Newtonsoft.Json;

namespace FOS.Infrastructure.Services.IdentityServices
{
    public class UserResouceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userRepository;
        public UserResouceOwnerPasswordValidator(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userRepository.FindByUsername(context.UserName);
            context.Result = new GrantValidationResult(Convert.ToString(user?.UserId), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
