using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;

namespace vRoles.VanillaPort.Modifiers.OGInfection
{
    public class ChefModifier : GameModifier
    {
        public override string ModifierName => "";
        private int _originalColor;
        private string _originalHat;
        public override string GetDescription() => "";
        public override void OnActivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                _originalColor = Player.Data.DefaultOutfit.ColorId;
                _originalHat = Player.Data.DefaultOutfit.HatId;
                Player.RpcSetColor(7);
                Player.RpcSetHat("hat_ChefWhiteBlue");
                if (Player.GetModifier<ZomburritoModifier>() != null)
                {
                    Player.RpcRemoveModifier<ZomburritoModifier>();
                }
            }
        }

        public override int GetAssignmentChance() => 0;
        public override int GetAmountPerGame() => 0;

        public override void OnDeactivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                if (!GameManager.Instance.GameHasStarted)
                {
                    Player.RpcSetColor((byte)_originalColor);
                    Player.RpcSetHat(_originalHat);
                }
            }
        }
    }
}
