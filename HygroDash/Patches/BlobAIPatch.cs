using HarmonyLib;

namespace HygroDash.Patches
{
    [HarmonyPatch(typeof(BlobAI))]
    internal class BlobAIPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void SpeedChangePatch(BlobAI __instance)
        {
            __instance.agent.speed *= HygroDashMod.configSpeedMultiplier.Value;
        }
    }
}
