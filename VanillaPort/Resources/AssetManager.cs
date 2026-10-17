using System.Reflection;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace vRoles.VanillaPort.Resources
{
    public static class AssetManager
    {
        // Buttons
        public static LoadableResourceAsset UnleashWraithAsset { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Unleash_Wraith.png");

        public static LoadableResourceAsset WraithKillAsset { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Wraith_Icon.png");

        public static LoadableResourceAsset ScannerAsset { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Scanner.png");

        public static LoadableResourceAsset DeputyButtonIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.DeputyIcon.png");

        public static LoadableResourceAsset VigiKillIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.VigiKillIcon.png");

        public static LoadableResourceAsset InfectIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.InfectIcon.png");

        // Powers
        public static LoadableResourceAsset Detect { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Detect.png");

        public static LoadableResourceAsset DisInfect { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Disinfect.png");

        public static LoadableResourceAsset LightsOut { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Lights_Out_Power.png");

        public static LoadableResourceAsset Sabotage { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Sabotage_Power.png");

        public static LoadableResourceAsset Shield { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Shield.png");

        public static LoadableResourceAsset Vanish { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Vanish.png");

        public static LoadableResourceAsset Vanished { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Vanished.png");

        public static LoadableResourceAsset Zap { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.3D_Zap.png");

        public static LoadableResourceAsset Vent { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.Vent.png");
        public static LoadableResourceAsset GuardPink { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.PowerUps.Guard_Pink.png");

        // Scan Sprites
        public static LoadableResourceAsset Checkmark { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Scan_Crewmate.png");

        public static LoadableResourceAsset Exclamation { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Scan_Important.png");

        public static LoadableResourceAsset TryAgain { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.Buttons.Scan_Inconclusive.png");

        // Role Icons
        public static LoadableResourceAsset VigiIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.RoleIcons.Vigilante_icon_tut.png");

        public static LoadableResourceAsset WraithIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.RoleIcons.wraith_icon_tut.png");

        public static LoadableResourceAsset DeputyIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.RoleIcons.Deputy_icon_tut.png");

        public static LoadableResourceAsset CriticalCrewmateIcon { get; } =
            new("vRoles.VanillaPort.Resources.Sprites.RoleIcons.CC_icon_tut.png");

        // Role Reveals
        public static LoadableAudioResourceAsset VigiIntro { get; } =
            new("vRoles.VanillaPort.Resources.Audio.Vigilante_Intro.wav");

        public static LoadableAudioResourceAsset InfectedRoleReveal { get; } =
            new("vRoles.VanillaPort.Resources.Audio.infectedReveal.wav");

        public static LoadableAudioResourceAsset WraithRoleReveal { get; } =
            new("vRoles.VanillaPort.Resources.Audio.wraithReveal.wav");

        public static LoadableAudioResourceAsset ScannerRoleReveal { get; } =
            new("vRoles.VanillaPort.Resources.Audio.scannerReveal.wav");

        // Asset Bundle
        public static AssetBundle LoadAssetBundle()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream =
                   assembly.GetManifestResourceStream("vRoles.VanillaPort.Resources.Bundles.au2.5d-data"))
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return AssetBundle.LoadFromMemory(bytes);
            }
        }

        public static AssetBundle LoadMobileAssetBundle()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream =
                   assembly.GetManifestResourceStream("vRoles.VanillaPort.Resources.Bundles.au2.5d-data-android"))
            {
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                return AssetBundle.LoadFromMemory(bytes);
            }
        }
        // SFX
        public static LoadableAudioResourceAsset ScanSfx { get; } = new("vRoles.VanillaPort.Resources.Audio.Scan_Progress.wav");
        public static LoadableAudioResourceAsset ScanCompleteSfx { get; } = new("vRoles.VanillaPort.Resources.Audio.Scan_Completed_1.wav");
    }
}
