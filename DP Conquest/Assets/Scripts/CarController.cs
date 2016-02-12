using UnityEngine;
using System.Collections;

public class CarController : EnemyController {

	private bool facingDown = true;
	private bool moving = false;
	private bool rotating = false;

	private SpriteRenderer render;
	private Rigidbody2D rigid;
	private int speed;

	// Use this for initialization
	void Start () {
		render = transform.GetComponent<SpriteRenderer>();
		rigid = transform.GetComponent<Rigidbody2D>();
		InvokeRepeating("RandomDrive", 2, 3);
		speed = 3;
	}

	void RandomDrive () {
		if (!moving) {
			float random = Random.value;

			if (random <= .25) {
				// Make car visible and start moving
				Vector2 vSpeed = new Vector2(0, 0);
				if (facingDown)
					vSpeed.y = -Mathf.Abs(speed);
				else 
					vSpeed.y = Mathf.Abs(speed);

				rigid.velocity = vSpeed;
				render.enabled = true;
				moving = true;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			// Rotate while driving in the same direction. Add to BAC (doesn't yet)
			rigid.AddTorque(20);
		}
	}

	public void OnTriggerExit2D(Collider2D other) {
		Debug.Log(other.name);
		if ((facingDown && other.name == "Bottom") || (!facingDown && other.name == "Top")) {
			// Stop moving and set facingDown, change direction
			render.enabled = false;
			rigid.velocity = Vector2.zero;
			rigid.angularVelocity = 0;
			moving = false;
			facingDown = !facingDown;

			// Change sprite face
			Vector3 rotation = transform.eulerAngles;

			if (facingDown)
				rotation.z = 90;
			else
				rotation.z = 270;

			transform.eulerAngles = rotation;
		}
	}
}
