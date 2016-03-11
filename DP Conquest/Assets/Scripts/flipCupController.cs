using UnityEngine;
using System.Collections;

public class FlipCupController : MonoBehaviour
{

	public float spin = 190f; //200??
	private bool movingRight = true;
	private bool isSpinning = true;

	/* Update is called once per frame
     * It moves the cup around in an arc on screen in time with the bar
     * 
     * Precondition: Minigame is loaded into flipcup scene
     * Postcondition: Cup position is updated on screen relative to the moving bar
     */
	void Update () {
		checkRight ();
		checkSpin ();
		if (isSpinning) {
			if (gameObject.transform.position.x > 0 && movingRight == true) {
				transform.Rotate (0, 0, -spin*Time.deltaTime);
			} else if (gameObject.transform.position.x > 0 && movingRight == false) {
				transform.Rotate (0, 0, spin*Time.deltaTime);
			}	
			if (gameObject.transform.position.x < 0 && movingRight == false) {
				transform.Rotate (0, 0, spin*Time.deltaTime);
			} else if (gameObject.transform.position.x < 0 && movingRight == true) {
				transform.Rotate (0, 0, -spin*Time.deltaTime);
			}	
		}
	}

    /* Changes the direction of the cup based on how far to the left or right it is
     * 
     * Precondition: Cup is in motion
     * Postcondition: Cup is prevented from going out of bounds
     */
	public void checkRight()
	{
		if (gameObject.transform.position.x > 5.74f) {
			movingRight = false;
		}
		if (gameObject.transform.position.x < -5.74f) {
			movingRight = true;
		}
	}

    /* Controls cup movement based on player input
     * 
     * Precondition: Cup is initialized on screen
     * Postcondition: Cup is either stopped or started when player presses Space
     */
	public void checkSpin()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			isSpinning = !isSpinning;
		}
	}
}
