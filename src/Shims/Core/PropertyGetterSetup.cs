using HarmonyLib;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Shims.Core
{
    internal class PropertyGetterSetup<TMock, TResult> : Setup, ISetupGetter<TMock, TResult>, IReturnsGetterResult<TMock, TResult>
        where TMock : class
    {
        public object ReturnValue { get; private set; } = default;

        public PropertyGetterSetup(Expression<Func<TMock, TResult>> expression)
        {
            if (expression.Body is MemberExpression memberExpr && memberExpr.Member is PropertyInfo property)
            {
                var getMethod = property.GetGetMethod(true);
                if (getMethod == null)
                {
                    throw new ArgumentException("La propriété spécifiée n'a pas d'accesseur get.", nameof(expression));
                }

                TargetMethod = getMethod;
                ShimContextManager.CurrentContext.Instances[TargetMethod] = this;
            }
            else
            {
                throw new ArgumentException("L'expression doit être une propriété", nameof(expression));
            }
        }

        public IReturnsGetterResult<TMock, TResult> Returns(TResult value)
        {
            ReturnValue = value;
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

        public IReturnsGetterResult<TMock, TResult> Returns(Func<TResult> valueFunction)
        {
            ReturnValue = valueFunction();
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

    }
}
