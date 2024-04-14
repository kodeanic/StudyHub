using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests.Users.Commands;

public class CreateUserCommand : IMapTo<User>, IRequest<Guid>
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Patronymic { get; set; } = string.Empty;
}

public class CreateUserCommandHandler : BaseCreateCommand<User>, IRequestHandler<CreateUserCommand, Guid>
{
    public CreateUserCommandHandler(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
        : base(applicationDbContext, mapper)
    {
    }

    public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return Create(request, async user =>
        {
            await ThrowIfLoginExists(user.Login);
        }, cancellationToken);
    }

    private async Task ThrowIfLoginExists(string login)
    {
        if (await ApplicationDbContext.Users.AnyAsync(x => x.Login == login))
        {
            throw new Exception($"Пользователь с таким логином уже существует {login}");
        }
    }
}
