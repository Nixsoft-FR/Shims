using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public partial interface IReturns<TMock, TResult>
        where TMock : class
    {
        IReturnsResult<TMock, TResult> Returns(TResult value);

        IReturnsResult<TMock, TResult> Returns(Delegate valueFunction);

        IReturnsResult<TMock, TResult> Returns(Func<TResult> valueFunction);

        IReturnsResult<TMock, TResult> Returns<T>(Func<T, TResult> valueFunction);

    }
}
