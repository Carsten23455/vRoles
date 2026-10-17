using vRoles.VanillaPort.Options;
using MiraAPI.GameModes;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using vRoles.VanillaPort.Gamemodes.Tag;
using vRoles.VanillaPort.Resources;
using vRoles.VanillaPort.Roles.Infection.Crewmate;
using vRoles.VanillaPort.Roles.Infection.Impostor;
using static vRoles.VanillaPort.Networking.RpcManager;

namespace vRoles.VanillaPort.Buttons.InfectionPowers.OriginalPowers
{
    public class Zap : CustomActionButton<PlayerControl>
    {
        public override string Name => "Zap";
        public override float Cooldown => 0f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Zap;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.TertiaryAbility;
        public override int MaxUses => 1;

        protected override void OnClick()
        {
            RpcZap(Target);
        }
        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            var settings = OptionGroupSingleton<Infection>.Instance;
            return role is CrewmateTag && !settings.LTEEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
        public override PlayerControl? GetTarget()
        {
            return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
        }

        public override void SetOutline(bool active)
        {
            Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.ImpostorRed));
        }

        public override bool IsTargetValid(PlayerControl? target)
        {
            if (target == null) return false;
            if (target.PlayerId == PlayerControl.LocalPlayer.PlayerId) return false;
            if (target.Data.Role is not Infected) return false;

            return true;
        }
    }
}
