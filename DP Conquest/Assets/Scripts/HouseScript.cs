using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
 * Minigame script that looks for collisions and can return to main game sequence
 * 
 */
public class HouseScript : MonoBehaviour {
    
	//Determines type of game to be loaded
    public string gameType1;
	public string gameType2;
    public static ArrayList triggerTags;
    
    private void Start()
    {
        if (triggerTags == null)
            triggerTags = new ArrayList();
    }
    //If object that was collide with was the character, starts minigame. 
    //Precondition: Player is in main game scene
    //Postcondition: Player is moved to the minigame
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            if(!triggerTags.Contains(gameObject.tag))
                triggerTags.Add(gameObject.tag);
            SceneManager.LoadScene(gameType1);
        }
    } 

}
