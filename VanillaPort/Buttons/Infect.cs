using AmongUs.GameOptions;
using vRoles.VanillaPort.Options;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Keybinds;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using vRoles.VanillaPort.Modifiers;
using vRoles.VanillaPort.Modifiers.OGInfection;
using vRoles.VanillaPort.Resources;
using vRoles.VanillaPort.Roles.Infection.Impostor;
using static vRoles.VanillaPort.Networking.RpcManager;

namespace vRoles.VanillaPort.Buttons
{
    public class Infect : CustomActionButton<PlayerControl>
    {
        Infection infection = OptionGroupSingleton<Infection>.Instance;
        public override string Name => "Infect";
        public override float Cooldown => infection.InfectedKCD;
        public override LoadableAsset<Sprite> Sprite => AssetManager.InfectIcon;
        public override bool PauseTimerInVent => true;
        public override BaseKeybind? Keybind => MiraGlobalKeybinds.PrimaryAbility;

        protected override void OnClick()
        {
            if (Target == null) return;
            if (Target.Data.Role is Infected) return;
            if (Target.ProtectedByGa())
            {
               Target.ShowFailedMurder();
                return;
            }

            var settings = OptionGroupSingleton<Infection>.Instance;

            if (!settings.LTEEnabled)
            {
                var roleID = RoleId.Get<Infected>();
                var roleType = (RoleTypes)roleID;

                SetRoleRpc(Target, roleType, true);
                Target.RpcAddModifier<InfectedModifier>();
            }
            else
            {
                var roleID = RoleId.Get<Zomburrito>();
                var roleType = (RoleTypes)roleID;

                SetRoleRpc(Target, roleType, true);
                Target.RpcAddModifier<ZomburritoModifier>();
            }
        }

        public override PlayerControl? GetTarget()
            => PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);

        public override void SetOutline(bool active)
            => Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.PlayerColors[11]));

        public override bool IsTargetValid(PlayerControl? target)
        {
            if (target == null) return false;
            if (target.PlayerId == PlayerControl.LocalPlayer.PlayerId) return false;
            if (target.Data.Role is Infected) return false;
            if (target.Data.IsDead) return false;
            if (target.inVent) return false;
            
            return true;
        }

        public override bool Enabled(RoleBehaviour? role)
        {
            SetButtonLocation(ButtonLocation.BottomRight);
            return role is Infected or Zomburrito;
        }
    }
}