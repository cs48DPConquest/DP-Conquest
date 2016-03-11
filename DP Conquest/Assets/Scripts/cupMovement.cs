using UnityEngine;
using System.Collections;

public class CupMovement : MonoBehaviour {

	public int cupSpeed = 1;
	public Vector3 pos;

	void Update () {
		float yCoor = gameObject.transform.position.x + (Input.GetAxis ("Horizontal") * cupSpeed);
		pos = new Vector3 ((Mathf.Clamp (yCoor,-8, 8)), -5, 0);
		gameObject.transform.position = pos;
	}
}
