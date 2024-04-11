using Application.Common.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests;

public abstract class BaseDeleteCommand<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly IApplicationDbContext ApplicationDbContext;
    protected readonly IMapper Mapper;

    protected BaseDeleteCommand(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
    {
        ApplicationDbContext = applicationDbContext;
        Mapper = mapper;
    }

    protected virtual async Task Delete<TRequest>(TRequest request,
        Func<TEntity, Task>? beforeDelete = default,
        CancellationToken cancellationToken = default) where TRequest : IBaseRequest, IBaseCommand
    {
        var entity = await ApplicationDbContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
        throw new Exception($"{nameof(TEntity)}, {request.Id}");

        if (beforeDelete != null)
        {
            await beforeDelete.Invoke(entity);
        }

        ApplicationDbContext.Set<TEntity>().Remove(entity);
        await ApplicationDbContext.SaveChangesAsync(cancellationToken);
    }
}
