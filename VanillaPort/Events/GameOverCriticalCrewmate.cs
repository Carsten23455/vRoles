using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;

namespace vRoles.VanillaPort.Events
{
    internal class GameOverCriticalCrewmate : CustomGameOver
    {

        public override void AfterEndGameSetup(EndGameManager endGameManager)
        {
            endGameManager.WinText.text = "All Critical Crewmates Died!";
            endGameManager.WinText.color = Color.white;
            endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.black);
        }
    }
}
