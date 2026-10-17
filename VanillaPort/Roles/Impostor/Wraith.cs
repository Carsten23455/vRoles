using AmongUs.GameOptions;
using vRoles.VanillaPort.Roles.Impostor;
using MiraAPI.GameModes;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;
using vRoles.VanillaPort.Resources;

namespace vRoles.VanillaPort.Roles.Impostor
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Wraith : ImpostorRole, ICustomRole
    {
        public string RoleName => "Wraith";
        public string RoleLongDescription => "Once dead, haunt and kill Crewmates.";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;
        public RoleHintType RoleHint => RoleHintType.TaskHint;
        public RoleTypes GetRole()
        {
            var roleID = RoleId.Get<WraithGhostRole>();
            return (RoleTypes)roleID;
        }

        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;

        public override void OnDeath(DeathReason reason)
        {

        }

        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            UseVanillaKillButton = false,
            CanModifyChance = true,
            IntroSound = AssetManager.WraithRoleReveal,
            GhostRole = GetRole(),
            Icon = AssetManager.WraithIcon,
        };
    }
}
