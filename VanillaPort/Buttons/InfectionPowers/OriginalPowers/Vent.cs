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
using vRoles.VanillaPort.Utils;

namespace vRoles.VanillaPort.Buttons.InfectionPowers.OriginalPowers
{
    public class VentAbility : CustomActionButton<Vent>
    {
        public override string Name => "Vent";
        public override float Cooldown => 0f;
        public override float EffectDuration => 10f;
        public override LoadableAsset<Sprite> Sprite => AssetManager.Vent;
        public override bool PauseTimerInVent => false;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;
        public override int MaxUses => 1;
        public override bool IsEffectCancellable() => true;

        public override Vent? GetTarget() => PlayerControl.LocalPlayer.GetClosestVent(1, false);

        public override void SetOutline(bool active)
        {
            Target?.SetOutline(active, active);
        }

        protected override void OnClick()
        {
            var player = PlayerControl.LocalPlayer;
            
            player.MyPhysics.RpcEnterVent(Target.Id);
            Target.SetButtons(true); 
        }

        public override void OnEffectEnd()
        {
            var player = PlayerControl.LocalPlayer;

            player.MyPhysics.RpcExitVent(Target.Id);
            Target.SetButtons(false);
        }

        public override bool Enabled(RoleBehaviour? role)
        {
            var settings = OptionGroupSingleton<Infection>.Instance;
            SetButtonLocation(ButtonLocation.BottomRight);

            return role is CrewmateTag && !settings.LTEEnabled && CustomGameModeManager.ActiveMode is TagGamemode;
        }
    }
}