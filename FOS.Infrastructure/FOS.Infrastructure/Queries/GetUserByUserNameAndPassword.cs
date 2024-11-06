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
            public Query(string userName,string password)
            {
                UserName = userName;
                Password = password;
            }
        }

        public class Handler : IRequestHandler<Query, User?>
        {
            private readonly IUserRepository userRepository;

            public Handler(IUserRepository repository)
            {
                userRepository = repository;
            }
            public async Task<User?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await userRepository.FindByUsername(request.UserName);
            }
        }
    }
}
