using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public interface ICallback
    {
        ICallbackResult Callback(Delegate callback);

        ICallbackResult Callback(Action action);

        ICallbackResult Callback<T1>(Action<T1> action);

        ICallbackResult Callback<T1, T2>(Action<T1, T2> action);

        ICallbackResult Callback<T1, T2, T3>(Action<T1, T2, T3> action);

        ICallbackResult Callback<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);

        ICallbackResult Callback<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);

        ICallbackResult Callback<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action);

    }

}
