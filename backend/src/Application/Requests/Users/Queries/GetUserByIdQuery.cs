using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Linq.PredicateBuilder;
using MediatR;

namespace Application.Requests.Users.Queries;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid userId)
    {
        Id = userId;
    }
}

public class GetUserByIdQueryHandler : BaseGetQuery<User>, IRequestHandler<GetUserByIdQuery, UserDto>
{
    public GetUserByIdQueryHandler(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
        : base(applicationDbContext, mapper)
    {
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return (await Get<UserDto>(builder => builder
                    .Equals(x => x.Id, request.Id),
                cancellationToken: cancellationToken))
            .SingleOrDefault() ?? throw new Exception();
    }
}
