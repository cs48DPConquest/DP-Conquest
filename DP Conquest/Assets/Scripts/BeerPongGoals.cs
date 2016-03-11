using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class BeerPongGoals : Goals
{
    //This class inherits from the parent class Goals
    //The Start() method is inherited as well as the numWins variable

    public static bool isOver = false; //tells whether or not the game is over

    /* Function to check whether or not the beer pong game is over
     * Overridden from the generic CheckWin() method in Goals.cs
     * 
     * Preconditions: Game has been started
     * Postconditions: Game continues if 6 cups have been destroyed
     * otherwise it keeps going
     */
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
