using HarmonyLib;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Shims.Core
{
    internal class NonVoidSetup<TMock, TResult> : SetupMethod, ISetup<TMock, TResult>, IReturnsResult<TMock, TResult>
        where TMock : class
    {
        public object ReturnValue { get; private set; } = default;

        public NonVoidSetup(Expression<Func<TMock, TResult>> expression) : base(expression)
        {
        }


        #region Returns

        public IReturnsResult<TMock, TResult> Returns(TResult value)
        {
            ReturnValue = value;
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

        public IReturnsResult<TMock, TResult> Returns(Delegate valueFunction)
        {
            return Returns((TResult)valueFunction.DynamicInvoke());
        }

        public IReturnsResult<TMock, TResult> Returns(Func<TResult> valueFunction)
        {
            return Returns(valueFunction());
        }

        public IReturnsResult<TMock, TResult> Returns<T>(Func<T, TResult> valueFunction)
        {
            return Returns(valueFunction(default));
        }


        #endregion
    }
}
