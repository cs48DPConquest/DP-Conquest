using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Presents game options, ex button to lead into main game sequence
 * 
 */
public class MainMapScript : MonoBehaviour {

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
            SceneManager.LoadScene("WinningScene");
        }
        else if (PlayerController.BAC < 30)
            SceneManager.LoadScene("MainGameScene");
        else
        {
            PlayerController.BAC = 0;
            PlayerController.TotalGames = 0;
            SceneManager.LoadScene("LosingScene");
        }

    }

    public void onQuitButtonPress()
    {
        Application.Quit();
    }
	/*
	 * Called on the frame of the object’s creation and overrides the MonoBehaviour.Start() method.
	 * Currently does nothing but functionality may be included later.
	 */
	private void Start () {
        //onMapButtonPress();
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
    
}
