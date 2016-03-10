using UnityEngine;
using System.Collections;
/*
 * Randomly generates car instances and handles putting the car on the screen, 
 * the car leaving the screen, and collision of the car with the playe
 * 
 */

public class CarController : EnemyController {

	private bool facingDown = true; //determines car's orientation and side of screen car appears from
	private bool moving = false; //if car is moving, true

	private SpriteRenderer render; //Helps render car on map
	private Rigidbody2D rigid; //Makes car a solid object on screen 
	private int speed; //regeneration time

	// Use this for initialization
	private void Start () {
		//set with retrieved components of type SpriteRenderer and Rigidbody2D 
		render = transform.GetComponent<SpriteRenderer>();
		rigid = transform.GetComponent<Rigidbody2D>();
		// continuously call RandomDrive every 3 seconds
		InvokeRepeating("RandomDrive", 2, 3);
		speed = 3;
	}

	private void RandomDrive () {
		if (!moving) {
			float random = Random.value;
			//car has 0.5 chance of appearing
			if (random <= .5) {
				// Make car visible and start moving
				Vector2 vSpeed = new Vector2(0, 0);
				//match car's speed up or down the page to its pictoral orientation
				if (facingDown)
					vSpeed.y = -Mathf.Abs(speed);
				else 
					vSpeed.y = Mathf.Abs(speed);

				//set velocity of the car
				rigid.velocity = vSpeed;
				//set to render to true, set moving to true
				render.enabled = true;
				moving = true;
			}
		}
	}

	//If car collides with player make car swerve
	//Precondition: Car is initialized
	//Postcondition: Car rotates on collision with player
	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			// Rotate while driving in the same direction. Add to BAC
			rigid.AddTorque(20);
            PlayerController.BAC += 5;
		}
	}

	//If car exits map, trigger events
	//Precondition: Car is driving on the road
	//Postcondition: Car despawns on collision with boundaries
	public void OnTriggerExit2D(Collider2D other) {
		Debug.Log(other.name);
		//switch so that the next orientation 
		if ((facingDown && other.name == "Bottom") || (!facingDown && other.name == "Top")) {
			// Stop moving and set facingDown, change direction
			render.enabled = false;
			//set velocity to 0 after it leaves screen
			rigid.velocity = Vector2.zero;
			rigid.angularVelocity = 0;
			moving = false;
			//cnage car orientation
			facingDown = !facingDown;

			// Change sprite face
			Vector3 rotation = transform.eulerAngles;

			//rotate car
			if (facingDown)
				rotation.z = 90;
			else
				rotation.z = 270;

			transform.eulerAngles = rotation;
		}
	}
}
