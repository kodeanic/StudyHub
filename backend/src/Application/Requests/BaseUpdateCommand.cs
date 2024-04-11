using Application.Common.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests;

public class BaseUpdateCommand<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly IApplicationDbContext ApplicationDbContext;
    protected readonly IMapper Mapper;

    public BaseUpdateCommand(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
    {
        ApplicationDbContext = applicationDbContext;
        Mapper = mapper;
    }

    protected virtual async Task Update<TRequest>(TRequest request,
        Func<TEntity, Task>? beforeUpdate = default,
        CancellationToken cancellationToken = default) where TRequest : IBaseRequest, IBaseCommand
    {
        var entity = await ApplicationDbContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
        throw new Exception($"{nameof(TEntity)}, {request.Id}");

        Mapper.Map(request, entity);

        if (beforeUpdate != null)
        {
            await beforeUpdate(entity);
        }

        await ApplicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
