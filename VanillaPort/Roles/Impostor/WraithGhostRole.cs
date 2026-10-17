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
    public class WraithGhostRole : ImpostorGhostRole, ICustomRole
    {
        public string RoleName => "Wraith";
        public string RoleLongDescription => "Once dead, haunt and kill Crewmates.";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.ImpostorRed;
        public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;
        
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            UseVanillaKillButton = false,
            CanModifyChance = false,
            HideSettings = true,
            CanUseVent = false,
            Icon = AssetManager.WraithIcon,
        };
    }
}
