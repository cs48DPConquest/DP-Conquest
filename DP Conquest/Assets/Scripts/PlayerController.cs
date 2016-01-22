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
	void Start () {
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
        float move = Input.GetAxis("Horizontal");

        bool leftWalk;
        bool rightWalk;

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0)
        {
            rightWalk = true;
            leftWalk = false;
        }
        else if (move < 0)
        {
            leftWalk = true;
            rightWalk = false;
        }
        else
            leftWalk = rightWalk = false;

        if (rightWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MOVEMENT_SPEED, GetComponent<Rigidbody2D>().velocity.y);
        else if (leftWalk)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MOVEMENT_SPEED * -1, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);


        if (rightWalk && !facingRight)
            Flip();
        else if (!rightWalk && facingRight)
            Flip();
    }
}
