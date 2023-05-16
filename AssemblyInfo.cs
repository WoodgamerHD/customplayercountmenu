using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(CustomPlayerCount.BuildInfo.Description)]
[assembly: AssemblyDescription(CustomPlayerCount.BuildInfo.Description)]
[assembly: AssemblyCompany(CustomPlayerCount.BuildInfo.Company)]
[assembly: AssemblyProduct(CustomPlayerCount.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + CustomPlayerCount.BuildInfo.Author)]
[assembly: AssemblyTrademark(CustomPlayerCount.BuildInfo.Company)]
[assembly: AssemblyVersion(CustomPlayerCount.BuildInfo.Version)]
[assembly: AssemblyFileVersion(CustomPlayerCount.BuildInfo.Version)]
[assembly: MelonInfo(typeof(CustomPlayerCount.CustomPlayerCount), CustomPlayerCount.BuildInfo.Name, CustomPlayerCount.BuildInfo.Version, CustomPlayerCount.BuildInfo.Author, CustomPlayerCount.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]