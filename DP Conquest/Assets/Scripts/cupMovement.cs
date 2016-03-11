using UnityEngine;
using System.Collections;

public class CupMovement : MonoBehaviour
{

	public int cupSpeed = 1; //Base speed of the cup
	public Vector3 pos; //Vector3 object from the UnityEngine package representing current position

    /* Called once per frame
     * Updates the position of the cup on screen
     * 
     * Preconditions: Cup is initialized on screen
     * Postconditions: Cup position is updated relative to direction pressed
     */
	void Update () {
		float yCoor = gameObject.transform.position.x + (Input.GetAxis ("Horizontal") * cupSpeed);
		pos = new Vector3 ((Mathf.Clamp (yCoor,-8, 8)), -5, 0);
		gameObject.transform.position = pos;
	}
}
