using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	Rigidbody rb;
	public float ballSpeed;
	bool isOn;
	int rando;


	void Awake () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rando = Random.Range (1, 2);

	}

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
