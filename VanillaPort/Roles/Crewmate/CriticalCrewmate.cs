using vRoles.VanillaPort.Options;
using MiraAPI.GameEnd;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Roles;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using vRoles.VanillaPort.Events;
using vRoles.VanillaPort.Gamemodes.Tag;
using vRoles.VanillaPort.Resources;

namespace vRoles.VanillaPort.Roles.Crewmate
{
    [ReactorModFlags(ModFlags.RequireOnAllClients)]
    public class CriticalCrewmate : CrewmateRole, ICustomRole
    {
        CriticalCargo cc = OptionGroupSingleton<CriticalCargo>.Instance;
        public string RoleName => "Critical Crewmate";
        public string RoleLongDescription => "Complete tasks and Don't die";
        public string RoleDescription => RoleLongDescription;
        public Color RoleColor => Palette.PlayerColors[5];
        public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
        public List<NetworkedPlayerInfo> winnerslist = new System.Collections.Generic.List<NetworkedPlayerInfo>();
        
        public bool CanSpawnOnCurrentMode() => CustomGameModeManager.ActiveMode is not TagGamemode or HideAndSeekMode;
        
        public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
        {
            MaxRoleCount = 3,
            IntroSound = AssetManager.ScannerRoleReveal,
            Icon = AssetManager.CriticalCrewmateIcon,
            HideSettings = !OptionGroupSingleton<CriticalCargo>.Instance.Enabled
        };

        public override void OnDeath(DeathReason reason)
        {
            if (!AmongUsClient.Instance.AmHost) return;

            bool anyCriticalAlive = PlayerControl.AllPlayerControls
                .ToArray()
                .Any(p => !p.Data.IsDead && p.Data.Role is CriticalCrewmate);

            if (!anyCriticalAlive)
            {
                foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                {
                    if (player.Data.Role.TeamType == RoleTeamTypes.Impostor)
                    {
                        this.winnerslist.Add(player.Data);
                    }
                }

                IEnumerable<NetworkedPlayerInfo> winners = winnerslist.ToArray();

                CustomGameOver.Trigger<GameOverCriticalCrewmate>(winners);
            }
        }
    }
}