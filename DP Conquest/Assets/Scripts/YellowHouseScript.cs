using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Minigame script that looks for collisions and can return to main game sequence
 * 
 */
public class YellowHouseScript : MonoBehaviour {
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

    // note game levels not yet implemented

	//Determines type of game to be loaded
    public string gameType1;
	public string gameType2;


	//If object that was collide with was the character, starts minigame. 
	//Precondition: Player is in main game scene
	//Postcondition: Player is moved to the minigame
    private void OnTriggerEnter2D(Collider2D hit)
    { 
		if (hit.tag == "Player")
        	SceneManager.LoadScene(gameType1);
    } 

	//Currently unimplemented.
	//void OnMapButtonPress()


}
