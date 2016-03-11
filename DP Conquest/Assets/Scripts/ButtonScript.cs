using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Presents game options, ex button to lead into main game sequence
 * 
 */
public class ButtonScript : MonoBehaviour {

	/*
	 * Returns the player to the main scene so they can escape the currently 
	 * incomplete minigame scene.
	 */
	//Precondition: Currently in minigamescene
	//Postcondition: returns to main game scene
    public void onMapButtonPress()
    {
        if (PlayerController.TotalGames >= 4 && PlayerController.BAC < 30)
        {
            PlayerController.BAC = 0;
            PlayerController.TotalGames = 0;
            HouseScript.triggerTags = null;
            SceneManager.LoadScene("WinningScene");
        }
        else if (PlayerController.BAC < 30)
            SceneManager.LoadScene("MainGameScene");
        else
        {
            PlayerController.BAC = 0;
            PlayerController.TotalGames = 0;
            HouseScript.triggerTags = null;
            SceneManager.LoadScene("LosingScene");
        }

    }

    public void onQuitButtonPress()
    {
        Application.Quit();
    }

    public void onExitButtonPress()
    {
        PlayerController.BAC = PlayerController.TotalGames = 0;
        HouseScript.triggerTags = null;
        SceneManager.LoadScene("TitleScreenScene");
    }
    
}
