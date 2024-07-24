using Shims.Interfaces;
using System.Reflection;

namespace Shims.Core
{
    internal abstract class Setup : ISetup
    {
        internal MethodBase TargetMethod { get; set; }

        public void ConfigureInstance(object instance)
        {
            ShimContextManager.CurrentContext.Instances.Remove((TargetMethod, null));
            ShimContextManager.CurrentContext.Instances[(TargetMethod, instance)] = this;
        }

    }
}
