using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Requests;

public abstract class BaseCreateCommand<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly IApplicationDbContext ApplicationDbContext;
    protected readonly IMapper Mapper;

    protected BaseCreateCommand(
        IApplicationDbContext applicationDbContext,
        IMapper mapper)
    {
        ApplicationDbContext = applicationDbContext;
        Mapper = mapper;
    }

    protected virtual async Task<Guid> Create<TRequest>(TRequest request,
        Func<TEntity, Task>? beforeInsert = default,
        CancellationToken cancellationToken = default) where TRequest : IBaseRequest
    {
        var entity = Mapper.Map<TEntity>(request);

        if (beforeInsert != null)
        {
            await beforeInsert.Invoke(entity);
        }

        ApplicationDbContext.Set<TEntity>().Add(entity);
        await ApplicationDbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
