using System.Linq.Expressions;
using System.Reflection;
using GlobalAzure.CustomSchema.Data;
using GlobalAzure.CustomSchema.Data.Metadata;
using GlobalAzure.CustomSchema.Database.Extendable;
using Microsoft.EntityFrameworkCore;

namespace GlobalAzure.CustomSchema.Database
{
    public class AdditionalPropertiesVisitor : ExpressionVisitor
    {
        static AdditionalPropertiesVisitor()
        {
            Expression<Func<IQueryable<object>, IQueryable<object>>> exp = p => p.Select(x => x);
            _selectMethod = ((MethodCallExpression)exp.Body).Method.GetGenericMethodDefinition();

            Expression<Func<object, object>> exp2 = p => EF.Property<object>(p, "test");
            _efPropertyMethod = ((MethodCallExpression)exp2.Body).Method.GetGenericMethodDefinition();


            Expression<Action<Dictionary<string, object>>> exp3 = p => p.Add("abc", null);
            _dictionaryAddMethod = ((MethodCallExpression)exp3.Body).Method;
        }


        private MetadataModel _customizationModel;
        private Dictionary<Type, Type> _mappings;
        private static readonly MethodInfo _selectMethod;
        private static readonly MethodInfo _efPropertyMethod;
        private static readonly MethodInfo _dictionaryAddMethod;

        public AdditionalPropertiesVisitor(MetadataModel customizationModel, IEnumerable<IAdditionalDataEntityMapping> mappings)
        {
            _customizationModel = customizationModel;
            _mappings = mappings.ToDictionary(p => p.Target, p => p.Entity);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsGenericMethod && node.Method.GetGenericMethodDefinition() == _selectMethod)
            {
                var source = node.Method.GetGenericArguments()[0];
                var target = node.Method.GetGenericArguments()[1];

                if (_mappings.ContainsKey(target) && _mappings[target] == source)
                {
                    var entity = _customizationModel.Entities.FirstOrDefault(p => p.EntityName == source.FullName);
                    if (entity != null)
                    {
                        var selectLambda = (LambdaExpression)((UnaryExpression)node.Arguments[1]).Operand;

                        var shadowAccessors = entity.Properties.Select(p =>
                                                    Expression.ElementInit(_dictionaryAddMethod,
                                                    Expression.Constant(p.Name.ToLower(), typeof(string)),
                                                    Expression.Convert(Expression.Call(
                                                        _efPropertyMethod.MakeGenericMethod(CrmContext.GetClrType(p)),
                                                        selectLambda.Parameters[0],
                                                        Expression.Constant(p.Name, typeof(string))), typeof(object))
                                                    )).ToList();

                        var property = typeof(IExtendableObject).GetProperty(nameof(IExtendableObject.AdditionalProperties));

                        var listInitExpression = Expression.ListInit(
                                                                Expression.New(typeof(Dictionary<string, object>)),
                                                                shadowAccessors);

                        var additionasDataBindExpression = Expression.Bind(property, listInitExpression);

                        if (selectLambda.Body is MemberInitExpression initExpression)
                        {
                            var bindings = initExpression.Bindings.ToList();
                            bindings.Add(additionasDataBindExpression);
                            var newInit = Expression.MemberInit(initExpression.NewExpression, bindings);

                            var replaceVisitor = new ReplaceVisitor(initExpression, newInit);
                            return replaceVisitor.Visit(node);
                        }
                    }
                }
            }

            return base.VisitMethodCall(node);
        }
    }
}