using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public interface IReturnsResult<TMock, TResult> : ICallback
        where TMock : class
    {
    }
}
