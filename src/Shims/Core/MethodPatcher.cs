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
            else if (setup is ISetupGetter)
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

        public static void ReturnResultPostfix(MethodBase __originalMethod, object __instance, ref object __result)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, __instance), out ISetup specificSetup))
            {
                ISetupNonVoid nonVoidInstance = (ISetupNonVoid)specificSetup;
                __result = nonVoidInstance.ReturnValue;
            }
            if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, null), out ISetup instance))
            {
                ISetupNonVoid nonVoidInstance = (ISetupNonVoid)instance;
                __result = nonVoidInstance.ReturnValue;
            }
        }

        public static void ReturnResultGetterPostfix(MethodBase __originalMethod, object __instance, ref object __result)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, __instance), out ISetup specificSetup))
            {
                ISetupGetter nonVoidInstance = (ISetupGetter)specificSetup;
                __result = nonVoidInstance.ReturnValue;
            }
            else if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, null), out ISetup globalSetup))
            {
                ISetupGetter nonVoidInstance = (ISetupGetter)globalSetup;
                __result = nonVoidInstance.ReturnValue;
            }
        }

        public static bool ThrowExceptionPrefix(MethodBase __originalMethod, object __instance, object[] __args)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, null), out ISetup instance))
            {
                ISetupMethod methodInstance = (ISetupMethod)instance;
                methodInstance.MethodCallback?.DynamicInvoke(__args);
                throw methodInstance.ThrowedException;
            }

            return false;
        }

        public static bool InvokeMethodCallbackPrefix(MethodBase __originalMethod, object __instance, object[] __args)
        {
            if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, __instance), out ISetup specificSetup))
            {
                ISetupMethod methodInstance = (ISetupMethod)specificSetup;
                methodInstance.MethodCallback?.DynamicInvoke(__args);
            }
            else if (ShimContextManager.CurrentContext.Instances.TryGetValue((__originalMethod, null), out ISetup globalSetup))
            {
                ISetupMethod methodInstance = (ISetupMethod)globalSetup;
                methodInstance.MethodCallback?.DynamicInvoke(__args);
            }

            return false;
        }

        #endregion

    }
}
