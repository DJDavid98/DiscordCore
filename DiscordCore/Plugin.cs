using IPA;

namespace DiscordCore
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal const string Name = "DiscordCore";
        internal static IPA.Logging.Logger log;
        internal DiscordManager manager;

        [Init]
        public void Init(IPA.Logging.Logger log)
        {
            Plugin.log = log;
            manager = DiscordManager.instance;
        }

        [OnEnable]
        public void OnEnable()
        {
            manager.OnEnable();
        }

        [OnDisable]
        public void OnDisable()
        {
            manager.OnDisable();
        }
    }
}
