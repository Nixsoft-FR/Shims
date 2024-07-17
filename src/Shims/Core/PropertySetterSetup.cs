using System;
using System.Linq.Expressions;
using System.Reflection;
using Shims.Interfaces;

namespace Shims.Core
{
    internal class PropertySetterSetup<TMock, TValue> : SetupCallback, ISetupSetter<TMock, TValue>
        where TMock : class
    {
        public Action<TValue> SetValueAction { get; private set; }

        public PropertySetterSetup(Expression<Func<TMock, TValue>> expression)
        {
            if (expression.Body is MemberExpression memberExpr && memberExpr.Member is PropertyInfo property)
            {
                var setMethod = property.GetSetMethod(true);
                if (setMethod == null)
                {
                    throw new ArgumentException("La propriété spécifiée n'a pas d'accesseur set.", nameof(expression));
                }

                TargetMethod = setMethod;
                ShimContextManager.CurrentContext.Instances[TargetMethod] = this;
            }
            else
            {
                throw new ArgumentException("L'expression doit être une propriété", nameof(expression));
            }
        }

        public void Sets(Action<TValue> setValueAction)
        {
            SetValueAction = setValueAction;
            MethodPatcher.PatchMethod(this, TargetMethod);
        }
    }
}
