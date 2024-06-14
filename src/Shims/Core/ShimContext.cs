using HarmonyLib;
using Shims;
using Shims.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

public class ShimContext : IDisposable
{
    private readonly Harmony harmonyInstance;

    internal Dictionary<MethodBase, ISetup> Instances { get; private set; } = new Dictionary<MethodBase, ISetup>();

    public ShimContext(string instanceId)
    {
        harmonyInstance = new Harmony(instanceId);
    }

    public Harmony HarmonyInstance => harmonyInstance;

    public void Dispose()
    {
        harmonyInstance.UnpatchAll(harmonyInstance.Id);
    }
}
