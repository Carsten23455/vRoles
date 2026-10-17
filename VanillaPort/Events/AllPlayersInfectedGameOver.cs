using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;

namespace vRoles.VanillaPort.Events
{
    public class AllPlayersInfectedGameOver : CustomGameOver
    {
        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = "Infected Win!";
            endGameManager.WinText.color = Color.green;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.black);
        }
    }
}
