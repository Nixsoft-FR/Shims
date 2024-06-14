using System;
using System.Collections.Generic;
using System.Text;

namespace Shims.Interfaces
{
    public interface IThrows
    {
        IThrowsResult Throws(Exception exception);

        IThrowsResult Throws<TException>() where TException : Exception, new();

        IThrowsResult Throws(Delegate exceptionFunction);

        IThrowsResult Throws<TException>(Func<TException> exceptionFunction) where TException : Exception;

    }
}
