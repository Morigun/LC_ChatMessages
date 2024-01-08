using BepInEx;

using M0r19un.LC_Lib;

namespace M0r19un.LC_ChatMessages
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, ModName, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin{
        public const string ModGUID = PluginInfo.PLUGIN_GUID;
        public const string ModName = "Message information mod";
        public const string ModVersion = PluginInfo.PLUGIN_VERSION;

        private void Awake(){
            M0r19unLogger.Initialize(ModGUID);
            M0r19unLogger.Log($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Messaging.Init();
        }
    }
}