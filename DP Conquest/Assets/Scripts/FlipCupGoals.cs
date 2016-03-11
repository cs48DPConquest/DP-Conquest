using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FlipCupGoals : Goals
{
    //This class inherits from the parent class Goals
    //The Start() method is inherited as well as the numWins variable

    public static int numLosses = 0; //A new variable is added to keep track of the number of times the player misses

    /* Overrides the CheckWin() method inherited from Goals class
     * Checks to see whether or not the player has won the minigame
     * 
     * Precondition: Player is currently in a FlipCupMinigame
     * Postcondition: Player is removed from the game if they win or lose
     */
    protected override void CheckWin()
    {
        if (numWins >= 3)
        {
            numWins = numLosses = 0;
            PlayerController.BAC += 5;
            PlayerController.TotalGames += 1;
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false; //This makes the check and X in the minigame invisible
            SceneManager.LoadScene("MiniGameWinScene");
        }
        else if (numLosses >= 3)
        {
            numLosses = numWins = 0;
            PlayerController.BAC += 10;
            PlayerController.TotalGames += 1;
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false; //This makes the check and X in the minigame invisible
            SceneManager.LoadScene("MiniGameLossScene");
        }
    }
	
}
