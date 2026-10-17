using MiraAPI.GameModes;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;
using static vRoles.VanillaPort.Resources.AssetManager;

namespace vRoles.VanillaPort.Roles.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Vigilante : CrewmateRole, ICustomRole
    {
        public string RoleName => "Vigilante";
        public string RoleLongDescription => "Do your Tasks and Kill";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.PlayerColors[10];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;
        
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 3,
            Icon = VigiIcon,
            IntroSound = VigiIntro,
        };
        public override void OnRoleSet()
        {

        }
        public bool CanLocalPlayerSeeRole(PlayerControl player) => false;
    }
}
