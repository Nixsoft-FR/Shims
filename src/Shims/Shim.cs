using HarmonyLib;
using Shims.Core;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;


namespace Shims
{
    public class Shim<T> : IShim
        where T : class
    {
        internal ShimContext ShimContext { get; private set; }
        
        public Shim()
        {
            ShimContext = ShimContextManager.CurrentContext;
        }

        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression)
        {
            return new NonVoidSetup<T, TResult>(expression);

        }

        public ISetup<T> Setup(Expression<Action<T>> expression)
        {
            return new VoidSetup<T>(expression);

        }


        public ISetupGetter<T, TResult> SetupGet<TResult>(Expression<Func<T, TResult>> expression)
        {
            return new PropertyGetterSetup<T, TResult>(expression);
        }

        public ISetupSetter<T, TValue> SetupSet<TValue>(Expression<Func<T, TValue>> expression)
        {
            return new PropertySetterSetup<T, TValue>(expression);
        }

    }
}