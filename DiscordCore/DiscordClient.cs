﻿using Discord;
using IPA.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Discord.ActivityManager;

namespace DiscordCore
{
    public static class DiscordClient
    {
        public const long DefaultAppID = 658039028825718827;

        internal static event ActivityJoinHandler OnActivityJoin;
        internal static event ActivityJoinRequestHandler OnActivityJoinRequest;
        internal static event ActivityInviteHandler OnActivityInvite;
        internal static event ActivitySpectateHandler OnActivitySpectate;

        public static long CurrentAppID { get; private set; }

        private static Discord.Discord _discordClient;
        private static Dictionary<LogLevel, Logger.Level> _logLevels = new Dictionary<LogLevel, Logger.Level>() { { LogLevel.Debug, Logger.Level.Debug }, { LogLevel.Info, Logger.Level.Info }, { LogLevel.Warn, Logger.Level.Warning }, { LogLevel.Error, Logger.Level.Error } };

        static DiscordClient()
        {
            CurrentAppID = -1;
            ChangeAppID(DefaultAppID);
        }

        public static void ChangeAppID(long newAppId)
        {
            if((newAppId < 0 ? DefaultAppID : newAppId) != CurrentAppID)
            {
                if(_discordClient != null)
                {
                    var oldActManager = _discordClient.GetActivityManager();
                    oldActManager.OnActivityInvite -= OnActivityInvite;
                    oldActManager.OnActivityJoin -= OnActivityJoin;
                    oldActManager.OnActivityJoinRequest -= OnActivityJoinRequest;
                    oldActManager.OnActivitySpectate -= OnActivitySpectate;

                    _discordClient.Dispose();
                }

                _discordClient = new Discord.Discord(newAppId, (ulong)CreateFlags.NoRequireDiscord);
                CurrentAppID = newAppId;

                _discordClient.SetLogHook(LogLevel.Debug, LogCallback);

                var newActManager = _discordClient.GetActivityManager();
                newActManager.OnActivityInvite += OnActivityInvite;
                newActManager.OnActivityJoin += OnActivityJoin;
                newActManager.OnActivityJoinRequest += OnActivityJoinRequest;
                newActManager.OnActivitySpectate += OnActivitySpectate;
                newActManager.RegisterSteam(620980);
            }
        }


        private static void LogCallback(LogLevel level, string message)
        {
            Plugin.log.Log(_logLevels[level], $"[DISCORD] {message}");
        }

        public static void RunCallbacks()
        {
            _discordClient?.RunCallbacks();
        }

        public static AchievementManager GetAchievementManager() { return _discordClient?.GetAchievementManager(); }
        public static ActivityManager GetActivityManager() { return _discordClient?.GetActivityManager(); }
        public static ApplicationManager GetApplicationManager() { return _discordClient?.GetApplicationManager(); }
        public static ImageManager GetImageManager() { return _discordClient?.GetImageManager(); }
        public static LobbyManager GetLobbyManager() { return _discordClient?.GetLobbyManager(); }
        public static NetworkManager GetNetworkManager() { return _discordClient?.GetNetworkManager(); }
        public static OverlayManager GetOverlayManager() { return _discordClient?.GetOverlayManager(); }
        public static RelationshipManager GetRelationshipManager() { return _discordClient?.GetRelationshipManager(); }
        public static StorageManager GetStorageManager() { return _discordClient?.GetStorageManager(); }
        public static StoreManager GetStoreManager() { return _discordClient?.GetStoreManager(); }
        public static UserManager GetUserManager() { return _discordClient?.GetUserManager(); }
        public static VoiceManager GetVoiceManager() { return _discordClient?.GetVoiceManager(); }

    }
}