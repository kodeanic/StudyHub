using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Users.Commands;

public class CreateUserCommand : IMapTo<User>, IRequest<Guid>
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public int Role { get; set; }

    public List<string> Contacts { get; set; }

    public Guid? GroupId { get; set; }

    public void MappingTo(Profile profile)
    {
        profile.CreateMap<CreateUserCommand, User>()
            .ForMember(x => x.Contacts, opt => opt
                .MapFrom(x => x.Contacts.Select(y => new Contact { Link = y })));
    }
}

public class CreateUserCommandHandler : BaseCreateCommand<User>, IRequestHandler<CreateUserCommand, Guid>
{
    public CreateUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        : base(applicationDbContext, mapper)
    {
    }

    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Create(request, cancellationToken);
    }
}
