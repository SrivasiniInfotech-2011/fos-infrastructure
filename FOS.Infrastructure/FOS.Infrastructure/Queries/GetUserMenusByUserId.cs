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

        public class Handler(IUserRepository repository) : IRequestHandler<Query, List<UserMenu>>
        {
            public async Task<List<UserMenu>> Handle(Query request, CancellationToken cancellationToken) =>
                await repository.GetUserMenus(request.UserId);
        }
    }
}
