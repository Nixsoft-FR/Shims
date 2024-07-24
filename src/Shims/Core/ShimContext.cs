using HarmonyLib;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Shims.Core
{
    public class ShimContext : IDisposable
    {
        internal Dictionary<(MethodBase method, object instance), ISetup> Instances { get; private set; } = new Dictionary<(MethodBase, object), ISetup>();

        public ShimContext(string instanceId)
        {
            HarmonyInstance = new Harmony(instanceId);
        }

        public Harmony HarmonyInstance { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
            }
        }

        ~ShimContext()
        {
            Dispose(false);
        }
    }
}
