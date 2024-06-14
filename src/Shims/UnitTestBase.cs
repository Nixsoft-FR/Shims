using System;

namespace Shims
{
    public abstract class UnitTestBase : IDisposable
    {
        protected UnitTestBase()
        {
            ShimContextManager.Initialize("com.example.test");
        }

        public void Dispose()
        {
            ShimContextManager.Cleanup();
        }
    }

}
