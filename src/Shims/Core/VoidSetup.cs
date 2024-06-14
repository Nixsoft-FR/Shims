using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Shims.Core
{
    internal class VoidSetup<TMock> : SetupMethod, ISetup<TMock>
        where TMock : class
    {
        public VoidSetup(Expression<Action<TMock>> expression) : base(expression)
        {
        }
    }
}
