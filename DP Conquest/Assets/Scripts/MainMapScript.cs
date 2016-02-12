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

        SceneManager.LoadScene("MainGameScene");

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
