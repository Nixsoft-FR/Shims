using Shims.Interfaces;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Shims.Core
{
    internal class PropertySetterSetup<TMock, TValue> : SetupCallback, ISetupSetter<TMock, TValue>
        where TMock : class
    {
        internal Expression<Func<TMock, TValue>> OriginalExpression { get; private set; }

        public PropertySetterSetup(Expression<Func<TMock, TValue>> expression, object instance = null)
        {
            if (expression.Body is MemberExpression memberExpr && memberExpr.Member is PropertyInfo property)
            {
                MethodInfo setMethod = property.GetSetMethod(true);
                if (setMethod == null)
                {
                    throw new ArgumentException("La propriété spécifiée n'a pas d'accesseur set.", nameof(expression));
                }

                OriginalExpression = expression;
                TargetMethod = setMethod;
                ShimContextManager.CurrentContext.Instances[(TargetMethod, instance)] = this;
            }
            else
            {
                throw new ArgumentException("L'expression doit être une propriété", nameof(expression));
            }
        }
    }
}
