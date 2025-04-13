using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.Util;
using DiscordCore.UI;

namespace DiscordCore
{
    internal class SettingsMenuManager
    {
        private static bool DidInit { get; set; } = false;

        private const string MenuName = "Discord Core";
        private const string ResourcePath = "DiscordCore.UI.SettingsViewController.bsml";

        public static void Initialize()
        {
            if (!DidInit)
            {
                MainMenuAwaiter.MainMenuInitializing += InitOnMainMenuLoaded;
                DidInit = true;
            }
        }

        private static void InitOnMainMenuLoaded()
        {
            BSMLSettings.Instance.AddSettingsMenu(MenuName, ResourcePath, Settings.instance);
        }
    }
}
