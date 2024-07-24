using Shims.Core;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Shims
{
    public class Shim<T> : IShim
        where T : class, new()
    {
        internal ShimContext ShimContext { get; private set; }

        private List<ISetup> registreredSetups = new List<ISetup>();

        public Shim()
        {
            ShimContext = ShimContextManager.CurrentContext;
        }

        public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression)
        {
            NonVoidSetup<T, TResult> setup = new NonVoidSetup<T, TResult>(expression);
            registreredSetups.Add(setup);
            return setup;
        }

        public ISetup<T> Setup(Expression<Action<T>> expression)
        {
            VoidSetup<T> setup = new VoidSetup<T>(expression);
            registreredSetups.Add(setup);
            return setup;
        }

        public ISetupGetter<T, TResult> SetupGet<TResult>(Expression<Func<T, TResult>> expression)
        {
            PropertyGetterSetup<T, TResult> setup = new PropertyGetterSetup<T, TResult>(expression);
            registreredSetups.Add(setup);
            return setup;
        }

        public ISetupSetter<T, TValue> SetupSet<TValue>(Expression<Func<T, TValue>> expression)
        {
            PropertySetterSetup<T, TValue> setup = new PropertySetterSetup<T, TValue>(expression);
            registreredSetups.Add(setup);
            return setup;
        }

        public T Object
        {
            get
            {
                IEnumerable<Setup> setups = registreredSetups.FindAll(s => s is Setup).Cast<Setup>();
                T obj = new T();
                foreach (Setup setup in setups)
                {
                    setup.ConfigureInstance(obj);
                }
                return obj;
            }
        }

    }
}