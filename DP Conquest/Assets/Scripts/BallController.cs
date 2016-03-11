using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	Rigidbody rb; //Unity Physics object to represent the ball
	public float ballSpeed;
	bool isOn; //Boolean representing whether or not the ball has been released
	int rando; //Random number for determining the direction the ball travels

    /* Called as soon as the object is initialized
     * 
     * Preconditions: None
     * Postconditions: Object is initialized and rb is assigned to the ball
     */
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rando = Random.Range (1, 2);
	}

    /* Function that is called once per frame
     * Releases the ball from the cup to start bouncing around
     * 
     * Preconditions: Ball has been initialized in the scene
     * Postconditions: Ball begins bouncing around once space is pressed
     */
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space) == true && isOn == false) {
			transform.parent = null;
			isOn = true; 
			rb.isKinematic = false;

			if (rando == 1) {
				rb.AddForce (new Vector3 (ballSpeed, ballSpeed, 0));
			}

			if (rando == 2) {
				rb.AddForce (new Vector3 (-ballSpeed-1, -ballSpeed, 0));
			}

		}
	}

}
