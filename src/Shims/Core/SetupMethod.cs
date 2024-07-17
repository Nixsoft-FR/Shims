using Shims.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Shims.Core
{
    internal abstract class SetupMethod : SetupCallback, ISetupMethod, ICallbackResult, IThrowsResult
    {
        public Exception ThrowedException { get; private set; } = null;

        protected SetupMethod(Expression expression)
        {
            if (expression is LambdaExpression lambdaExpression)
            {
                if (lambdaExpression.Body is MethodCallExpression methodCall)
                {
                    if (ShimContextManager.CurrentContext.Instances.ContainsKey(methodCall.Method))
                    {
                        throw new InvalidOperationException("La méthode a déjà été shimmée.");
                    }

                    TargetMethod = methodCall.Method;
                    ShimContextManager.CurrentContext.Instances[TargetMethod] = this;
                }
                else
                {
                    throw new ArgumentException("L'expression doit être un appel de méthode.", nameof(expression));
                }
            }
            else
            {
                throw new ArgumentException("L'expression doit être une lambda expression.", nameof(expression));
            }
        }


        #region Throws

        public IThrowsResult Throws(Exception exception)
        {
            ThrowedException = exception;
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

        public IThrowsResult Throws<TException>() where TException : Exception, new()
        {
            ThrowedException = new TException();
            MethodPatcher.PatchMethod(this, TargetMethod);
            return this;
        }

        public IThrowsResult Throws(Delegate exceptionFunction)
        {
            var parameters = exceptionFunction.Method.GetParameters().Select(x => x.DefaultValue).ToArray();
            object e = exceptionFunction.DynamicInvoke(parameters.Length > 0 ? parameters : null);
            if (e is Exception exception)
            {
                ThrowedException = exception;
                MethodPatcher.PatchMethod(this, TargetMethod);
            }
            else
            {
                throw new InvalidOperationException("La fonction doit retourner une exception.");
            }
            return this;
        }

        public IThrowsResult Throws<TException>(Func<TException> exceptionFunction) where TException : Exception
        {
            TException e = exceptionFunction();
            if (e is Exception exception)
            {
                ThrowedException = exception;
                MethodPatcher.PatchMethod(this, TargetMethod);
            }
            else
            {
                throw new InvalidOperationException("La fonction doit retourner une exception.");
            }
            return this;
        }

        public IThrowsResult Throws<T, TException>(Func<T, TException> exceptionFunction) where TException : Exception
        {
            TException e = exceptionFunction(default);
            if (e is Exception exception)
            {
                ThrowedException = exception;
                MethodPatcher.PatchMethod(this, TargetMethod);
            }
            else
            {
                throw new InvalidOperationException("La fonction doit retourner une exception.");
            }
            return this;
        }

        #endregion

    }
}
