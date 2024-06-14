using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shims.Core
{
    internal abstract class Setup
    {
        protected MethodBase TargetMethod { get; set; }
    }
}
