using System.Reflection;
using AmongUs.GameOptions;
using vRoles.VanillaPort.Networking;
using MiraAPI.Hud;
using Reactor.Networking.Attributes;
using vRoles.VanillaPort.Buttons;

namespace vRoles.VanillaPort.Networking;

public static class RpcManager
{
    private static readonly FieldInfo RoleAssignedField = 
        typeof(PlayerControl).GetField("roleAssigned", BindingFlags.NonPublic | BindingFlags.Instance);
    
    [MethodRpc((uint)RPCs.SetRole)]
    public static void SetRoleRpc(PlayerControl player, RoleTypes roleType, bool canOverrideRole)
    {
        if (player == null || player.Data == null) return;

        RoleManager.Instance.SetRole(player, roleType);
    }

    [MethodRpc((uint)RPCs.Zap)]
    public static void RpcZap(PlayerControl player)
    {
        if (player != PlayerControl.LocalPlayer) return;
        
        var infect = CustomButtonSingleton<Infect>.Instance;
        infect.ResetCooldownAndOrEffect();
    }

    [MethodRpc((uint)RPCs.SetBody)]
    public static void RpcSetBody(PlayerControl player, PlayerBodyTypes playerBodyType)
    {
        player.MyPhysics.SetBodyType(playerBodyType);
    }
}