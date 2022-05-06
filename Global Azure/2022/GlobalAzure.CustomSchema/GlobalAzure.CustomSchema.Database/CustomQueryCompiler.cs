using System.Linq.Expressions;
using GlobalAzure.CustomSchema.Database.Extendable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalAzure.CustomSchema.Database
{
    public class CustomQueryCompiler : QueryCompiler
    {
        private readonly ICurrentDbContext _context;

        public CustomQueryCompiler(IQueryContextFactory queryContextFactory,
            ICompiledQueryCache compiledQueryCache,
            ICompiledQueryCacheKeyGenerator compiledQueryCacheKeyGenerator,
            IDatabase database, IDiagnosticsLogger<DbLoggerCategory.Query> logger,
            ICurrentDbContext currentContext,
            IEvaluatableExpressionFilter evaluatableExpressionFilter,
            IModel model)
#pragma warning disable EF1001 // Internal EF Core API usage.
            : base(queryContextFactory,
                  compiledQueryCache,
                  compiledQueryCacheKeyGenerator,
                  database,
                  logger,
                  currentContext,
                  evaluatableExpressionFilter,
                  model)
#pragma warning restore EF1001 // Internal EF Core API usage.
        {
            _context = currentContext;
        }

        public override TResult Execute<TResult>(Expression query)
        {
            return base.Execute<TResult>(Replace(query));
        }

        private Expression Replace(Expression query)
        {
            if (_context.Context is CrmContext ctx)
            {
                var options = ((IInfrastructure<IServiceProvider>)ctx).Instance.GetRequiredService<IDbContextOptions>();
                var sp = options.FindExtension<Microsoft.EntityFrameworkCore.Infrastructure.CoreOptionsExtension>().ApplicationServiceProvider;
                var visitor = new AdditionalPropertiesVisitor(ctx.CustomizationModel, sp.GetServices<IAdditionalDataEntityMapping>());

                return visitor.Visit(query);
            }

            return query;
        }

        public override TResult ExecuteAsync<TResult>(Expression query, CancellationToken cancellationToken = default)
        {
            var target = Replace(query);
            return base.ExecuteAsync<TResult>(target, cancellationToken);
        }
    }
}