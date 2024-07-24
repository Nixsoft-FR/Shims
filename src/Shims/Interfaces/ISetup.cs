using Shims.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Shims.Interfaces
{
    public interface ISetup
    {
    }

    public interface ISetupCallback : ISetup
    {
        Delegate MethodCallback { get; }
    }

    public interface ISetupMethod : ISetupCallback, ICallback, IThrows
    {
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

    public interface ISetupSetter : ISetupCallback
    {
    }

    public interface ISetupSetter<TMock, TProperty> : ISetupSetter, ICallbackSetter<TMock, TProperty>
        where TMock : class
    {
    }

}
