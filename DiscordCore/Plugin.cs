using IPA;

namespace DiscordCore
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal const string Name = "DiscordCore";
        internal static IPA.Logging.Logger log;

        [Init]
        public void Init(IPA.Logging.Logger log)
        {
            Plugin.log = log;
            DiscordManager manager = DiscordManager.instance;
        }

        [OnEnable, OnDisable]
        public void OnState() { /* On State */ }
    }
}
