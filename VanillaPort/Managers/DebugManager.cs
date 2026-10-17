using AmongUs.GameOptions;

namespace vRoles.VanillaPort.Managers
{
    public class DebugManager
    {
        public static void SetRole(PlayerControl player, RoleTypes role, bool canoverride)
        {
            player.RpcSetRole(role, canoverride);
        }
    }
}
