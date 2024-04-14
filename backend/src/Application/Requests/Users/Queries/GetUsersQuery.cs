using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Linq.PredicateBuilder;
using MediatR;

namespace Application.Requests.Users.Queries;

public class GetUsersQuery : IRequest<IList<UserDto>>
{
}

public class GetUsersQueryHandler : BaseGetQuery<User>, IRequestHandler<GetUsersQuery, IList<UserDto>>
{
    public GetUsersQueryHandler(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
        : base(applicationDbContext, mapper)
    {
    }

    public Task<IList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return Get<UserDto>(builder => builder.Where(x => true), cancellationToken: cancellationToken);
    }
}
