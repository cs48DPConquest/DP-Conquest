using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FlipCupGoals : Goals {
    public static int numLosses = 0;

    protected override void CheckWin()
    {
        if (numWins >= 3)
        {
            numWins = numLosses = 0;
            PlayerController.BAC += 5;
            PlayerController.TotalGames += 1;
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false;
            SceneManager.LoadScene("MiniGameWinScene");
        }
        else if (numLosses >= 3)
        {
            numLosses = numWins = 0;
            PlayerController.BAC += 10;
            PlayerController.TotalGames += 1;
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false;
            SceneManager.LoadScene("MiniGameLossScene");
        }
    }
	
}
