using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private const int MOVEMENT_SPEED = 3;

    //bool facingUp = false;
    //bool facingDown = false;
    bool facingRight = true;
    bool facingLeft = false;

    Animator animator;

	// Use this for initialization
	void Start ()
    {
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
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

        bool keyIsDown = (rightWalk || leftWalk);

        if (rightWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MOVEMENT_SPEED, 0);
        else if (leftWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MOVEMENT_SPEED * -1, 0);
        else if (upWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, MOVEMENT_SPEED);
        else if (downWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, MOVEMENT_SPEED * -1);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (rightWalk && !facingRight)
            Flip();
        else if (!rightWalk && facingRight)
            Flip();
    }
}
