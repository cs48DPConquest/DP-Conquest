﻿using UnityEngine;
using System.Collections;

/*
 * Sets player’s movement speed, direction, and view based on user arrow press. 
 * Limits the player’s bounds and keeps track of player’s location
 * 
 */

public class PlayerController : MonoBehaviour {

    private const int MOVEMENT_SPEED = 3; //player velocity
    private const float PLAYER_X_BOUND = (float) 6.00; //width of the map image divided by 2
    private const float PLAYER_Y_BOUND = (float) 4.32; //height of the map image divided by 2

	// Default false until player presses arrow key; determines direction of the character 
    private bool facingUp = false; 
    private bool facingDown = false;
    private bool facingRight = true;
    private bool facingLeft = false;
	// if player is in bounds, true
    private bool in_bounds = false;


    private Animator animator; // keeps track of movement frames    Rigidbody2D rigidBody;
	private Rigidbody2D rigidBody; //allows player to be solid, used to retrieve player's position
    private Vector2 mapBoundary; // sets x and y mapboundaries

    private Vector2 X_Velocity = new Vector2(MOVEMENT_SPEED, 0); //x direction velocity
    private Vector2 Y_Velocity = new Vector2(0, MOVEMENT_SPEED); //y direction velocity

    // Use this for initialization
    private void Start ()
    {
		//set with retrieved component of type Animator and RigidBody2D
    	animator = GetComponent<Animator>();
	    rigidBody = GetComponent<Rigidbody2D>();
        //mapBoundary = new Vector2(Screen.width/2, Screen.height/2);
        mapBoundary = new Vector2(PLAYER_X_BOUND, PLAYER_Y_BOUND);
    }

	// Update is called once per frame
    private void Update() {}

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
        facingDown = facingUp = false;
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

	/*
	 * Gets the character’s position and checks if the character has exceeded bounds on the map. 
	 * Updates the new position of the character to the map bounds and sets in_bounds to false if so. 
	 * */
	//Precondition: Player is in motion
	//Postcondition: returns whether or not the player is moving in bounds and stops the player if they are out of bounds.
    private bool checkPlayerBounds()
    {
		// This should be good to remove now that the colliders are up
        in_bounds = true;
    
       
        if (rigidBody.position.x > mapBoundary.x)
        {
            rigidBody.position = new Vector2(mapBoundary.x, rigidBody.position.y);
            in_bounds = false;
        }
        else if (rigidBody.position.x < mapBoundary.x * -1)
        {
            rigidBody.position = new Vector2(mapBoundary.x * -1, rigidBody.position.y);
            in_bounds = false;
        }
        else if (rigidBody.position.y > mapBoundary.y)
        {
            rigidBody.position = new Vector2(rigidBody.position.x, mapBoundary.y);
            in_bounds = false;
        }
        else if (rigidBody.position.y < mapBoundary.y * -1)
        {
            rigidBody.position = new Vector2(rigidBody.position.x, mapBoundary.y * -1);
            in_bounds = false;
        }

        return in_bounds;

    }


}
