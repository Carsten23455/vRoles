using vRoles.VanillaPort.Options;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;
using vRoles.VanillaPort.Resources;
using vRoles.VanillaPort.Roles.Infection.Crewmate;

namespace vRoles.VanillaPort.Buttons.InfectionPowers.UnUsedPowers
{
    public class Sabotage : CustomActionButton
    {
        public override string Name => "Sabotage";
        public override float Cooldown => 0f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Sabotage;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.TertiaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            if (!AmongUsClient.Instance.AmHost && IsSabotageActiveOrCoolingDown()) return;

            foreach (SystemTypes room in CheckMap().FastRooms._keys)
            {
                CheckMap().RpcCloseDoorsOfType(room);
            }
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            var sabotage = OptionGroupSingleton<InfectionUnusedOrRemovePowers>.Instance;
            return role is CrewmateTag && sabotage.SabotageEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
        public static ShipStatus CheckMap()
        {
            return ShipStatus.Instance;
        }

        public static bool IsSabotageActiveOrCoolingDown()
        {
            ShipStatus instance = CheckMap();
            if (instance == null) return false;

            if (instance.Systems.TryGetValue(SystemTypes.Sabotage, out ISystemType system))
            {
                SabotageSystemType sabSystem = system.TryCast<SabotageSystemType>();
                if (sabSystem == null) return false;

                bool isActive = sabSystem.AnyActive;
                bool isCoolingDown = sabSystem.Timer > 0f && !sabSystem.AnyActive;

                return isActive || isCoolingDown;
            }

            return false;
        }
    }
}
