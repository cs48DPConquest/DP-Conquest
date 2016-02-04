using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private const int MOVEMENT_SPEED = 3;
    private const float PLAYER_X_BOUND = (float) 6.00; //width of the map image divided by 2
    private const float PLAYER_Y_BOUND = (float) 4.32; //height of the map image divided by 2

    bool facingUp = false;
    bool facingDown = false;
    bool facingRight = true;
    bool facingLeft = false;

    bool in_bounds = false;

    Animator animator;
    Rigidbody2D rigidBody;

    Vector2 mapBoundary;

    private Vector2 X_Velocity = new Vector2(MOVEMENT_SPEED, 0);
    private Vector2 Y_Velocity = new Vector2(0, MOVEMENT_SPEED);

    // Use this for initialization
    void Start ()
    {
    	animator = GetComponent<Animator>();
	    rigidBody = GetComponent<Rigidbody2D>();
        //mapBoundary = new Vector2(Screen.width/2, Screen.height/2);
        mapBoundary = new Vector2(PLAYER_X_BOUND, PLAYER_Y_BOUND);
    }

	// Update is called once per frame
    void Update() {}

    void FixedUpdate ()
    {
    	// This is mostly for physics updates
        manageMovement();
    }

    void horizFlip()
    {
        facingDown = facingUp = false;
        facingRight = !facingRight;
        facingLeft = !facingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void checkMoving()
    {
        bool isMoving = (animator.GetBool("movingDown") || animator.GetBool("movingUp") || animator.GetBool("movingHoriz"));
        animator.SetBool("moving", isMoving);
    }

    void manageMovement()
    {
        bool rightWalk = Input.GetKey(KeyCode.RightArrow);
        bool leftWalk = Input.GetKey(KeyCode.LeftArrow);
        bool upWalk = Input.GetKey(KeyCode.UpArrow);
        bool downWalk = Input.GetKey(KeyCode.DownArrow);

        if (checkPlayerBounds()==true)
        {
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
                Debug.Log("not a valid movement");
                animator.SetBool("movingUp", false);
                animator.SetBool("movingDown", false);
                animator.SetBool("movingHoriz", false);
            }
        }
        else
        {
            Debug.Log("player bound false");
        }

        checkMoving();
        if ((rightWalk && !facingRight) || (leftWalk && !facingLeft))
            horizFlip();
        
    }

    bool checkPlayerBounds()
    {
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
