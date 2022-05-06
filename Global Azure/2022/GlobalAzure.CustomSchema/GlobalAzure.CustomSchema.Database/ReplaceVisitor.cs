using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace GlobalAzure.CustomSchema.Database
{
    internal class ReplaceVisitor : ExpressionVisitor
    {
        private MemberInitExpression _search;
        private MemberInitExpression _replace;

        public ReplaceVisitor(MemberInitExpression search, MemberInitExpression replace)
        {
            _search = search;
            _replace = replace;
        }

        [return: NotNullIfNotNull("node")]
        public override Expression? Visit(Expression? node)
        {
            if (node == _search)
            {
                return _replace;
            }
            return base.Visit(node);
        }
    }
}