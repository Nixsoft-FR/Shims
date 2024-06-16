using System;

namespace Shims.Core
{
    internal static class ShimContextManager
    {
        private static ShimContext currentContext;

        public static ShimContext CurrentContext
        {
            get
            {
                if (currentContext == null)
                {
                    throw new InvalidOperationException("ShimContext n'a pas été initialisé.");
                }
                return currentContext;
            }
        }

        public static void Initialize(string id)
        {
            currentContext = new ShimContext(id);
        }

        public static void Cleanup()
        {
            currentContext?.Dispose();
            currentContext = null;
        }
    }

}