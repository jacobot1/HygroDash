using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using HygroDash.Patches;
using BepInEx.Configuration;

namespace HygroDash
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class HygroDashMod : BaseUnityPlugin
    {
        // Mod metadata
        public const string modGUID = "jacobot5.HygroDash";
        public const string modName = "HygroDash";
        public const string modVersion = "1.0.0";

        // Initalize Harmony
        private readonly Harmony harmony = new Harmony(modGUID);

        // Create static instance
        private static HygroDashMod Instance;

        // Configuration
        public static ConfigEntry<float> configSpeedMultiplier;

        // Initialize logging
        public static ManualLogSource mls;

        private void Awake()
        {
            // Ensure static instance
            if (Instance == null)
            {
                Instance = this;
            }

            // Send alive message
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("HygroDash has awoken.");

            // Bind configuration
            configSpeedMultiplier = Config.Bind("General.Toggles",
                                                "SpeedMultiplier",
                                                10f,
                                                "How much to multiply Hygrodere Speed by. 1 is normal speed, defaults to 10.");

            // Do the patching
            harmony.PatchAll(typeof(HygroDashMod));
            harmony.PatchAll(typeof(BlobAIPatch));
        }
    }
}
