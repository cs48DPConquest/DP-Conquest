using UnityEngine;
using System.Collections;

/*
 * Controller updates frame of view to follow the player controlled character around the map
 * 
 */

public class CameraController : MonoBehaviour {
	// Position of the player in world space
	public Transform player;


	// Update camera position
	//Precondition: None
	//Postcondition: Camera moves to follow along player
	private void FixedUpdate ()
	{
		/*
		 * Interpolates camera’s current transform position with player’s transform position 
		 * to update new camera position (current interpolant is 1, ie player’s position)
		 * */
		transform.position = Vector3.Lerp(transform.position,new Vector3(player.transform.position.x, player.transform.position.y, -10), 1);
	}
}
