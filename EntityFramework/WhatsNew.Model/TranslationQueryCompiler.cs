using System.Linq.Expressions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace WhatsNew.Model
{
    internal class TranslationQueryCompiler : QueryCompiler
    {
        public TranslationQueryCompiler(IQueryContextFactory queryContextFactory, ICompiledQueryCache compiledQueryCache, ICompiledQueryCacheKeyGenerator compiledQueryCacheKeyGenerator, IDatabase database, IInterceptingLogger<LoggerCategory.Query> logger, INodeTypeProviderFactory nodeTypeProviderFactory, ICurrentDbContext currentContext) : base(queryContextFactory, compiledQueryCache, compiledQueryCacheKeyGenerator, database, logger, nodeTypeProviderFactory, currentContext)
        {
        }

        public override TResult Execute<TResult>(Expression query)
        {
            return base.Execute<TResult>(query);
        }
    }
}