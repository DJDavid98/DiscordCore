using IPA;
using UnityEngine;

namespace DiscordCore
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal const string Name = "DiscordCore";
        internal static IPA.Logging.Logger log;

        protected GameObject manager;

        [Init]
        public void Init(IPA.Logging.Logger log)
        {
            Plugin.log = log;

            manager = new GameObject("DiscordManager");
            manager.AddComponent<DiscordManager>();

            SettingsMenuManager.Initialize();
        }

        [OnEnable]
        public void OnEnable()
        {
            manager.SetActive(true);
        }

        [OnDisable]
        public void OnDisable()
        {
            manager.SetActive(false);
        }
    }
}
