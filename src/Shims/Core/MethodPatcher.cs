using HarmonyLib;
using Shims.Interfaces;
using System.Reflection;

namespace Shims.Core
{
    internal static class MethodPatcher
    {

        public static void PatchMethod(ISetup setup, MethodBase method)
        {
            HarmonyMethod prefix = new HarmonyMethod(typeof(MethodPatcher), nameof(PrefixBypass)); ;
            HarmonyMethod postfix = null;

            if (setup is ISetupNonVoid)
            {
                postfix = new HarmonyMethod(typeof(MethodPatcher), nameof(ReturnResultPostfix));
            } 
            else if(setup is ISetupGetter)
            {
                postfix = new HarmonyMethod(typeof(MethodPatcher), nameof(ReturnResultGetterPostfix));
            }

            if (setup is ISetupMethod setupMethod)
            {
                prefix = new HarmonyMethod(typeof(MethodPatcher), nameof(InvokeMethodCallbackPrefix));
                if (setupMethod.ThrowedException != null)
                {
                    prefix = new HarmonyMethod(typeof(MethodPatcher), nameof(ThrowExceptionPrefix));
                }
            }

            ShimContextManager.CurrentContext.HarmonyInstance.Patch(method, prefix, postfix);
        }

        #region Callback Harmony

        public static bool PrefixBypass() => false;

        public static void ReturnResultPostfix(MethodBase __originalMethod, ref object __result)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue(__originalMethod, out var instance))
            {
                var nonVoidInstance = (ISetupNonVoid)instance;
                __result = nonVoidInstance.ReturnValue;
            }
        }

        public static void ReturnResultGetterPostfix(MethodBase __originalMethod, ref object __result)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue(__originalMethod, out var instance))
            {
                var nonVoidInstance = (ISetupGetter)instance;
                __result = nonVoidInstance.ReturnValue;
            }
        }

        public static bool ThrowExceptionPrefix(MethodBase __originalMethod, object __instance, object[] __args)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue(__originalMethod, out var instance))
            {
                var methodInstance = (ISetupMethod)instance;
                methodInstance.MethodCallback?.DynamicInvoke(__args);
                throw methodInstance.ThrowedException;
            }

            return false;
        }

        public static bool InvokeMethodCallbackPrefix(MethodBase __originalMethod, object __instance, object[] __args)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue(__originalMethod, out var instance))
            {
                var methodInstance = (ISetupMethod)instance;
                methodInstance.MethodCallback?.DynamicInvoke(__args);
            }

            return false;
        }

        #endregion

    }
}
