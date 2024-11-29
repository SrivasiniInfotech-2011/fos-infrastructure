using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetUserByUserNameAndPassword
    {
        public class Query : IRequest<User?>
        {
            public string UserName { get; }
            public string Password { get; }
            public Query(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }
        }

        public class Handler(IUserRepository repository) : IRequestHandler<Query, User?>
        {
            public async Task<User?> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.FindByUsername(request.UserName);
        }
    }
}
