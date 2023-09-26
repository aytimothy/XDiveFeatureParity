using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using XDiveFeatureParity.Entry;

namespace XDiveFeatureParity {
    public static class PluginInfo {
        public const string PLUGIN_GUID = "xyz.aytimothy.bepinex.tw.com.capcom.rxd.parity";
        public const string PLUGIN_NAME = "XDiveFeatureParity";
        public const string PLUGIN_VERSION = "0.1";
        public const string PLUGIN_DESCRIPTION = "Patches in various features from the online version of XDiVE. No server required.";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin {
        public override void Load() {
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
            XDiveFeatureParityLoader.Initialize();
        }
    }
}