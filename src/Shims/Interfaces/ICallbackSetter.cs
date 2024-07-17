using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public interface ICallbackSetter<TMock, TValue> : ICallback
        where TMock : class
    {
    }

}
