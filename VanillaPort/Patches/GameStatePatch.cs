using HarmonyLib;
using MiraAPI.Hud;
using vRoles.VanillaPort.Buttons;
using vRoles.VanillaPort.Managers;

namespace vRoles.VanillaPort.Patches
{
    [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.FixedUpdate))]
    public static class ShipStatusUpdatePatch
    {
        public static void Postfix()
        {
            /*
            switch (AmongUsClient.Instance.AmHost)
            {
                case true when ContainmentManager.ContainmentEnabled:
                    ContainmentManager.RandomSabSystem();
                    break;
                case false:
                    return;
            }
            */
            var infectButton = CustomButtonSingleton<Infect>.Instance;

            foreach (var player in PlayerControl.AllPlayerControls)
            {
                KnowledgePowerManager.UpdateCooldown(player.PlayerId, infectButton.Timer);
            }
        }
    }


    [HarmonyPatch(typeof(GameManager), nameof(GameManager.RpcEndGame))]
    public static class EndGamePatch
    {
        public static void PostFix()
        {
            /*
            if (AmongUsClient.Instance.AmHost && ContainmentManager.ContainmentEnabled)
            {
                ContainmentManager.SabotageCooldown = 35;
            }
            */
        }
    }
}
