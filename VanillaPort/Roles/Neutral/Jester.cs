using MiraAPI.GameEnd;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Events;

namespace vRoles.VanillaPort.Roles.Neutral
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class Jester : CrewmateRole, ICustomRole
    {
        public string RoleName => "Jester";
        public string RoleLongDescription => "Get ejected to win, your tasks are fake";
        public string RoleDescription => "Get Ejected to win";
        public Color RoleColor => Palette.PlayerColors[8];
        public ModdedRoleTeams Team => ModdedRoleTeams.Custom;
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 1,
            UseVanillaKillButton = false,
            TasksCountForProgress = false,
        };

        public override void OnDeath(DeathReason reason)
        {
            if (reason == DeathReason.Exile)
            {
                CustomGameOver.Trigger<JesterWin>([Player.Data]);
            }
        }
    }
}
