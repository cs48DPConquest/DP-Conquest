using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Presents game options, ex button to lead into main game sequence
 * 
 */
public class ButtonScript : MonoBehaviour 
{

	/* Determines where the player will go when pressing the map button
     * 
     * Preconditions: Currently in MiniGameScene or PauseScene
     * Postconditions: returns to main game scene if BAC is valid
     * Displays losing/winning scene based on BAC value
     */
    public void onMapButtonPress()
    {
        if (PlayerController.TotalGames >= 4 && PlayerController.BAC < 30)
        {
            PlayerController.BAC = 0;
            PlayerController.TotalGames = 0; //Reset winning values
            HouseScript.triggerTags = null; //Make all the minigames available to play again
            SceneManager.LoadScene("WinningScene");
        }
        else if (PlayerController.BAC < 30)
            SceneManager.LoadScene("MainGameScene");
        else
        {
            PlayerController.BAC = 0;
            PlayerController.TotalGames = 0; //Reset winning values
            HouseScript.triggerTags = null; //Make all the minigames available to play again
            SceneManager.LoadScene("LosingScene");
        }

    }

    /* Function for controlling the Quit button
     * 
     * Precondition: Quit button is onscreen
     * Postcondition: Application closes
     */
    public void onQuitButtonPress()
    {
        Application.Quit();
    }

    /* Function for controlling the exit button
     * 
     * Precondition: Exit button is onscreen
     * Postcondition: Returns the user to the title screen
     */
    public void onExitButtonPress()
    {
        PlayerController.BAC = PlayerController.TotalGames = 0; //Reset winning values
        HouseScript.triggerTags = null; //Make all the minigames available to play again
        SceneManager.LoadScene("TitleScreenScene");
    }
    
}
