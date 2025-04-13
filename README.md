# DiscordCore

A utility mod for easily doing Discord management and handling priority between rich presence systems.

Requires:
 * BSIPA 4 
 * [BeatSaberMarkupLanguage](https://github.com/monkeymanboy/BeatSaberMarkupLanguage)
 * DiscordGameSDK 3.2.1 (provided in the release zip)
   * Can be downloaded from https://discord.com/developers/docs/game-sdk/sdk-starter-guide
   * The correct (`x86_64`) DLL must be placed in the `Libs/Native` folder (create it if it does not exist)
   * The `DiscordGameSDK.manifest` file must also be placed in the `Plugins` folder

## Credits

* [@FizzyApple12](https://github.com/FizzyApple12) - original author
* [@qe201020335](https://github.com/qe201020335) - BSMT migration
* [@DJDavid98](https://github.com/DJDavid98) - minor updates/re-compilation/distribution

## For developers
### Building DiscordCore
- Download [Discord Game SDK v3.2.1](https://discord.com/developers/docs/game-sdk/sdk-starter-guide) and extract the `x86_64` `discord_game_sdk.dll` into `Refs/Libs/Native`
- Create `DiscordCore/DiscordCore.csproj.user` and add your Beat Saber game path to it

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project>
   <PropertyGroup>
      <!-- Change this path to your Beat Saber install path -->
      <BeatSaberDir>U:/SteamLibrary/steamapps/common/Beat Saber</BeatSaberDir>
   </PropertyGroup>
</Project>
```
- The compiled binaries and all related files will be automatically copied into your game upon build
