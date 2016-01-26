using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private const int MOVEMENT_SPEED = 3;

    //bool facingUp = false;
    //bool facingDown = false;
    bool facingRight = true;
    bool facingLeft = false;

    Animator animator;
    Rigidbody2D rigidBody;

	// Use this for initialization
    void Start ()
    {
    	animator = GetComponent<Animator>();
	rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
    void Update() {

    }

    void FixedUpdate ()
    {
    	// This is mostly for physics updates
        manageMovement();
    }

    void Flip()
    {
        facingRight = !facingRight;
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void manageMovement()
    {
        bool rightWalk = Input.GetKey(KeyCode.RightArrow);
        bool leftWalk = Input.GetKey(KeyCode.LeftArrow);
        bool upWalk = Input.GetKey(KeyCode.UpArrow);
        bool downWalk = Input.GetKey(KeyCode.DownArrow);

        if (rightWalk)
            rigidBody.velocity = new Vector2(MOVEMENT_SPEED, 0);
        else if (leftWalk)
            rigidBody.velocity = new Vector2(MOVEMENT_SPEED * -1, 0);
        else if (upWalk)
	    rigidBody.velocity = new Vector2(0, MOVEMENT_SPEED);
        else if (downWalk)
	    rigidBody.velocity = new Vector2(0, MOVEMENT_SPEED * -1);
        else
	    rigidBody.velocity = new Vector2(0, 0);

        if (rightWalk && !facingRight)
            Flip();
	else if (leftWalk && facingRight)
            Flip();
    }
}
