using MiraAPI.GameModes;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;

namespace vRoles.VanillaPort.Roles.Infection.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class CrewmateTag : CrewmateRole, ICustomRole
    {
        public string RoleName => "Crewmate";
        public string RoleLongDescription => "Complete tasks and Survive the Infected";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.CrewmateRoleBlue;
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            AffectedByLightOnAirship = false,
            MaxRoleCount = 0,
            CanModifyChance = false,
            HideSettings = true,
            CanUseVent = false,
            ShowInFreeplay = false,
        };
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is TagGamemode;

        public override void OnRoleSet()
        {

        }
        public override void Initialize(PlayerControl player)
        {

        }

        public override void Deinitialize(PlayerControl targetPlayer)
        {

        }

        public bool CanLocalPlayerSeeRole(PlayerControl player) => true;
    }
}