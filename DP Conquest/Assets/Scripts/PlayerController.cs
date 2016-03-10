using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Sets player’s movement speed, direction, and view based on user arrow press. 
 * Limits the player’s bounds and keeps track of player’s location
 * 
 */

public class PlayerController : MonoBehaviour {

    private const int MOVEMENT_SPEED = 3; //player velocity
    public static int BAC = 0;
    public static int TotalGames = 0;

	// Default false until player presses arrow key; determines direction of the character horizontally
    private bool facingRight = true;
    private bool facingLeft = false;

    private Animator animator; // keeps track of movement frames    Rigidbody2D rigidBody;
	private Rigidbody2D rigidBody; //allows player to be solid, used to retrieve player's position

    private Vector2 X_Velocity = new Vector2(MOVEMENT_SPEED, 0); //x direction velocity
    private Vector2 Y_Velocity = new Vector2(0, MOVEMENT_SPEED); //y direction velocity

    // Use this for initialization
    private void Start ()
    {
		//set with retrieved component of type Animator and RigidBody2D
    	animator = GetComponent<Animator>();
	    rigidBody = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
    private void Update()
    {
        if (gameLoss())
        {
            SceneManager.LoadScene("LosingScene");
            BAC = 0;
            TotalGames = 0;
        }
    }

	// This is mostly for physics updates
    private void FixedUpdate ()
    {
        manageMovement();
    }

	/*
	 * Flips the horizontal movement of the character to the opposite of facingDown. 
	 * Reverses scale relative to parent
	 * */
	//Precondition: Player is changing from one horizontal direction to the other
	//Postcondition: Player sprite is flipped to account for new direction
    private void horizFlip()
    {
        facingRight = !facingRight;
        facingLeft = !facingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

	/* 
	 * Sets animator’s moving method to true if the character is currently moving in any direction; false if it is not
	 * */
	//Precondition: None
	//Postcondition: returns whether or not the player is in motion
    private void checkMoving()
    {
        bool isMoving = (animator.GetBool("movingDown") || animator.GetBool("movingUp") || animator.GetBool("movingHoriz"));
        animator.SetBool("moving", isMoving);
    }

	/*
	 * Depending on the arrow key press, sets animators methods to the direction the character is moving in. 
	 * Moves the character in the direction of the key press with the appropriate velocity. 
	 * */
	//Precondition: Player has been initialized
	//Postcondition: Player's X and Y coordinates are updated according to user input
    private void manageMovement()
    {
        bool rightWalk = Input.GetKey(KeyCode.RightArrow);
        bool leftWalk = Input.GetKey(KeyCode.LeftArrow);
        bool upWalk = Input.GetKey(KeyCode.UpArrow);
        bool downWalk = Input.GetKey(KeyCode.DownArrow);

        if (rightWalk)
        {
            //rigidBody.velocity = new Vector2(MOVEMENT_SPEED, 0);
            animator.SetBool("movingHoriz", true);
            animator.SetBool("movingDown", false);
            animator.SetBool("movingUp", false);
            rigidBody.MovePosition(rigidBody.position + X_Velocity*Time.deltaTime);
        }
        else if (leftWalk)
        {
            //rigidBody.velocity = new Vector2(MOVEMENT_SPEED * -1, 0);
            animator.SetBool("movingHoriz", true);
            animator.SetBool("movingDown", false);
            animator.SetBool("movingUp", false);
            rigidBody.MovePosition(rigidBody.position - X_Velocity * Time.deltaTime);
        }
        else if (upWalk)
        {
            //rigidBody.velocity = new Vector2(0, MOVEMENT_SPEED);
            animator.SetBool("movingUp", true);
            animator.SetBool("movingDown", false);
            animator.SetBool("movingHoriz", false);
            rigidBody.MovePosition(rigidBody.position + Y_Velocity * Time.deltaTime);
        }
        else if (downWalk)
        {
            //rigidBody.velocity = new Vector2(0, MOVEMENT_SPEED * -1);
            animator.SetBool("movingDown", true);
            animator.SetBool("movingHoriz", false);
            animator.SetBool("movingUp", false);
            rigidBody.MovePosition(rigidBody.position - Y_Velocity * Time.deltaTime);
        }
        else
        {
            animator.SetBool("movingUp", false);
            animator.SetBool("movingDown", false);
            animator.SetBool("movingHoriz", false);
        }

		/* If no key press, animator is updated to with information that the character is not moving. 
		 * If walking horizontally and the player changes horizontal direction, calls horizFlip() to update
		 * */
        checkMoving();
        if ((rightWalk && !facingRight) || (leftWalk && !facingLeft))
            horizFlip();
        
    }

    private bool gameLoss()
    {
        return (BAC >= 30);
    }
}
