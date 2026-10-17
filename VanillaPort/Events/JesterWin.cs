using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;
using vRoles.VanillaPort.Resources;
using vRoles.VanillaPort.Roles.Neutral;

namespace vRoles.VanillaPort.Events
{
    public class JesterWin : CustomGameOver
    {
        public override bool VerifyCondition(PlayerControl playerControl, NetworkedPlayerInfo[] winners)
        {
            return winners is [{ Role: Jester }];
        }

        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = $"Jester Wins!";
            endGameManager.WinText.color = Color.magenta;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.magenta);
            endGameManager.ImpostorStinger = AssetManager.VigiIntro.LoadAsset();
        }
        public override bool BeforeEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.ImpostorStinger = AssetManager.VigiIntro.LoadAsset();
            return true;
        }
    }
}
