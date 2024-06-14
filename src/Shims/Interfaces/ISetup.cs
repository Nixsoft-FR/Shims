using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shims.Interfaces
{
    public interface ISetup
    {
    }

    public interface ISetupMethod : ISetup, ICallback, IThrows
    {
        Delegate MethodCallback { get; }
        
        Exception ThrowedException { get; }
    }

    public interface ISetupNonVoid : ISetupMethod
    {
        object ReturnValue { get; }
    }

    public interface ISetup<TMock, TResult> : ISetupNonVoid, IReturns<TMock, TResult>
        where TMock : class
    {
    }

    public interface ISetup<TMock> : ISetupMethod
        where TMock : class
    {
    }


    public interface ISetupGetter : ISetup
    {
        object ReturnValue { get; }
    }

    public interface ISetupGetter<TMock, TProperty> : ISetupGetter, IReturnsGetter<TMock, TProperty>
        where TMock : class
    {
    }
}
