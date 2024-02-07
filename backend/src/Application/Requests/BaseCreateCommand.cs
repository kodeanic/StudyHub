using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Requests;

public abstract class BaseCreateCommand<TEntity> where TEntity : class, IBaseEntity, new()
{
    protected readonly IApplicationDbContext ApplicationDbContext;
    protected readonly IMapper Mapper;

    protected BaseCreateCommand(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        ApplicationDbContext = applicationDbContext;
        Mapper = mapper;
    }

    protected virtual async Task<Guid> Create<TRequest>(TRequest request,
        CancellationToken cancellationToken = default) where TRequest : IBaseRequest
    {
        var entity = Mapper.Map<TEntity>(request);

        ApplicationDbContext.Set<TEntity>().Add(entity);
        await ApplicationDbContext.SaveChangesAsync();

        return entity.Id;
    }
}
