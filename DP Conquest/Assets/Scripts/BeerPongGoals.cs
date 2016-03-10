using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class BeerPongGoals : Goals
{
    public static bool isOver = false;

    protected override void CheckWin()
    {
        if (numWins >= 6)
        {
            numWins = 0;
            PlayerController.BAC += 5;
            PlayerController.TotalGames += 1;
            SceneManager.LoadScene("MiniGameWinScene");
        }

        else if (isOver)
        {
            numWins = 0;
            isOver = false;
            PlayerController.BAC += 10;
            PlayerController.TotalGames += 1;
            SceneManager.LoadScene("MiniGameLossScene");
        }
    }
}
