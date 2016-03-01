using UnityEngine;
using System.Collections;

public class cupMovement : MonoBehaviour {

	public int cupSpeed = 1;
	public Vector3 pos;

	void Update () {
		float ycoor = gameObject.transform.position.x + (Input.GetAxis ("Horizontal") * cupSpeed);
		pos = new Vector3 ((Mathf.Clamp (ycoor,-8, 8)), -5, 0);
		gameObject.transform.position = pos;
	}
}
