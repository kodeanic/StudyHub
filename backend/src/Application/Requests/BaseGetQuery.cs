using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Linq.PredicateBuilder;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests
{
    public class BaseGetQuery<TEntity> where TEntity : class, IBaseEntity
    {
        protected readonly IApplicationDbContext ApplicationDbContext;
        protected readonly IMapper Mapper;

        public BaseGetQuery(
            IApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            ApplicationDbContext = applicationDbContext;
            Mapper = mapper;
        }

        protected virtual async Task<IList<TDto>> Get<TDto>(
            Func<IAndOrOperator<TEntity>, IResult<TEntity>> builder,
            CancellationToken cancellationToken = default,
            BuilderOptions options = BuilderOptions.IgnoreCase | BuilderOptions.IgnoreDefaultInputs | BuilderOptions.Trim)
        {
            return await GetQueryEntities(builder, options)
                .ProjectTo<TDto>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        protected IQueryable<TEntity> GetQueryEntities(
            Func<IAndOrOperator<TEntity>, IResult<TEntity>> builder,
            BuilderOptions options)
        {
            var queryEntities = ApplicationDbContext
                .Set<TEntity>()
                .Build(builder, options);

            return queryEntities;
        }
    }
}
