using vRoles.VanillaPort.Options;
using vRoles.VanillaPort.Options.RoleOptions;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;
using vRoles.VanillaPort.Resources;

namespace vRoles.VanillaPort.Roles.Crewmate
{
    public class Scanner : CrewmateRole, ICustomRole
    {
        public string RoleName => "Scanner";
        public string RoleLongDescription => "Complete tasks and Scan the Impostors";
        public string RoleDescription => "Do Tasks and Scan";
        public Color RoleColor => Palette.PlayerColors[5];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        public List<NetworkedPlayerInfo> winnerslist = new System.Collections.Generic.List<NetworkedPlayerInfo>();
        ScannerOption scanner = OptionGroupSingleton<ScannerOption>.Instance;
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            UseVanillaKillButton = false,
            MaxRoleCount = 1,
            IntroSound = AssetManager.ScannerRoleReveal,
            HideSettings = OptionGroupSingleton<CriticalCargo>.Instance.Enabled,
            Icon = AssetManager.CriticalCrewmateIcon,
        };
        
        
        
        public bool CanLocalPlayerSeeRole(PlayerControl player)
        {
            var localPlayer = PlayerControl.LocalPlayer;

            return localPlayer.Data.Role.TeamType == RoleTeamTypes.Impostor && scanner.ImpSeeScan;
        }
    }
}
