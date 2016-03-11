using UnityEngine;
using System.Collections;

public class BAC : MonoBehaviour 
{

	public float newBAC = 0; //The default BAC value
	public GameObject Life; //The lifebar on screen

	// Update is called once per frame
    // Preconditions: None
    // Postconditions: MiniBAC is invoked
	void Update () {
		MiniBAC ();
	}

    /* Performs calculations on the BAC
     * To make it inversely proportional
     * Since as BAC goes up, the lifebar goes down
     * 
     * Preconditions: Player is on screen and BAC has been initialized
     * Postconditions: BAC has been inversely scaled for the life bar
     */
	public void MiniBAC()
	{
		if (PlayerController.BAC >= 30) {
			newBAC = 0;
			setBAC (0f);
		} 
		else {
			newBAC = ((30f - PlayerController.BAC) / 30f);
			setBAC (newBAC);
		}
	}
	
    /* Scales the lifebar with the player's BAC
     * 
     * Preconditions: Lifebar has been intialized
     * Postconditions: Lifebar is updated to reflect change in BAC value
     */
	public void setBAC(float myBAC)
	{
		Life.transform.localScale = new Vector3 (Mathf.Clamp (myBAC, 0f, 1f), Life.transform.localScale.y, Life.transform.localScale.z);
	}

}
