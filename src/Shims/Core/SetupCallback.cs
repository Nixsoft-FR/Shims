using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Core
{
    internal abstract class SetupCallback : Setup, ISetupCallback, ICallback, ICallbackResult
    {
        public Delegate MethodCallback { get; private set; } = null;

        #region Callback
        public ICallbackResult Callback(Delegate callback)
        {
            MethodCallback = callback;
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

        public ICallbackResult Callback(Action action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1>(Action<T1> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1, T2>(Action<T1, T2> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        public ICallbackResult Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            Delegate callback = action;
            return Callback(callback);
        }

        #endregion

    }
}
