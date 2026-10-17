using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using CorsacCosmetics;
using CorsacCosmetics.Cosmetics;
using HarmonyLib;
using MiraAPI;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace vRoles
{
    [BepInPlugin("TeamMessHall.vRoles", "vRoles", "0.1.0")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency(MiraApiPlugin.Id)]
    [BepInDependency(CorsacCosmeticsPlugin.Id)]
    [BepInDependency(ModCompatibility.SubmergedId, BepInDependency.DependencyFlags.SoftDependency)]
    [ReactorModFlags(ModFlags.RequireOnAllClients | ModFlags.DisableServerAuthority)]
    public class Core : BasePlugin, IMiraPlugin
    {

        public Harmony Harmony { get; } = new("TeamMessHall.vRoles");
        public string OptionsTitleText => "vRoles";
        public ConfigFile GetConfigFile() => Config;
        public static bool IsMobile = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();

        public override void Load()
        {
            ReactorCredits.Register("vRoles", "0.1.0", false, ReactorCredits.AlwaysShow);
            Harmony.PatchAll();
            byte[] bundleData;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AU3DPort.VanillaPort.Assets.Bundles.au3dhats.ccb"))
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bundleData = ms.ToArray();
            }

            PluginCompat.AddBundleBytes(bundleData);
        }

    }
}