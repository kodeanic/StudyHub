using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Requests.Users.Commands;

public class DeleteUserCommand : IBaseCommand, IRequest
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler : BaseDeleteCommand<User>, IRequestHandler<DeleteUserCommand>
{
    public DeleteUserCommandHandler(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
        : base(applicationDbContext, mapper)
    {
    }

    public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return Delete(request, cancellationToken);
    }
}
