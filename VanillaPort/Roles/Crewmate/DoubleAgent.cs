using vRoles.VanillaPort.Options.RoleOptions;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;

namespace vRoles.VanillaPort.Roles.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class DoubleAgent : CrewmateRole, ICustomRole
    {
        public string RoleName => "Double Agent";
        public string RoleLongDescription => "Blend in to catch the Impostors";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        DoubleAgentSettings doubleAgent = OptionGroupSingleton<DoubleAgentSettings>.Instance;
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;
        
        public bool CanLocalPlayerSeeRole(PlayerControl player)
        {
            var localPlayer = PlayerControl.LocalPlayer;

            if (localPlayer.Data.Role.TeamType == RoleTeamTypes.Impostor) return true;

            return false;
        }
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            CanUseVent = doubleAgent.CanVent,
        };
    }
}
