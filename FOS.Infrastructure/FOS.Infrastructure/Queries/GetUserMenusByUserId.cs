using FOS.Models.Entities;
using FOS.Repository.Interfaces;
using MediatR;

namespace FOS.Infrastructure.Queries
{
    public class GetUserMenusByUserId
    {
        public class Query : IRequest<List<UserMenu>>
        {
            public int UserId { get; }
            public Query(int userId)
            {
                UserId = userId;
            }
        }

        public class Handler : IRequestHandler<Query, List<UserMenu>>
        {
            private readonly IUserRepository userRepository;

            public Handler(IUserRepository repository)
            {
                userRepository = repository;
            }
            public async Task<List<UserMenu>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await userRepository.GetUserMenus(request.UserId);
            }
        }
    }
}
