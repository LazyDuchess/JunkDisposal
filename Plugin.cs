using BepInEx;
using HarmonyLib;

namespace SmootherTraversal
{
    [BepInPlugin(GUID, Name, Version)]
    internal class Plugin : BaseUnityPlugin
    {
        private const string GUID = "com.LazyDuchess.BRC.JunkDisposal";
        private const string Name = "Junk Disposal";
        private const string Version = "1.0.0";
        private JunkRemover _junkRemover;
        private void Awake()
        {
            JunkDisposalSettings.Initialize(Config);
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
            Logger.LogInfo($"{Name} {Version} loaded!");
            _junkRemover = new JunkRemover();
        }

        private void Update()
        {
            _junkRemover.OnUpdate();
        }
    }
}
