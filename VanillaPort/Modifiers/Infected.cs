using MiraAPI.Modifiers.Types;
using static vRoles.VanillaPort.Networking.RpcManager;

namespace vRoles.VanillaPort.Modifiers
{
    public class InfectedModifier : GameModifier
    {
        public override string ModifierName => "";
        private int _originalColor;
        
        public override void OnActivate()
        {
            if (AmongUsClient.Instance.AmHost)
            {
                _originalColor = Player.Data.DefaultOutfit.ColorId;
                Player.RpcSetColor(CustomColors.CustomColors.CheckWatermelon());
                RpcSetBody(Player, PlayerBodyTypes.Seeker);
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
                }
            }
        }

        public override string GetDescription() => "";
    }
}