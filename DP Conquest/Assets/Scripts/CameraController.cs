using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform player;

	private void FixedUpdate ()
	{
		transform.position = Vector3.Lerp(transform.position,new Vector3(player.transform.position.x, player.transform.position.y, -10), 1);
	}
}
