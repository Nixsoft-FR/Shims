using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public interface IReturnsGetter<TMock, TProperty> 
        where TMock : class
    {
        IReturnsGetterResult<TMock, TProperty> Returns(TProperty value);

        IReturnsGetterResult<TMock, TProperty> Returns(Func<TProperty> valueFunction);
    }
}
