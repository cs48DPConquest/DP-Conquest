using UnityEngine;
using System.Collections;

public class flipCupController : MonoBehaviour {

	public float spin = 190f; //200??
	private bool movingRight = true;
	private bool isSpinning = true;

	// Update is called once per frame
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

	public void checkRight()
	{
		if (gameObject.transform.position.x > 5.74f) {
			movingRight = false;
		}
		if (gameObject.transform.position.x < -5.74f) {
			movingRight = true;
		}
	}
	public void checkSpin()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			isSpinning = !isSpinning;
		}
	}
}
