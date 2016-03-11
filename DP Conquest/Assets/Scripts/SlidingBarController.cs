using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlidingBarController : MonoBehaviour
{

    private Rigidbody2D rigidBody; //The object to represent the body of the sliding bar
    private const float X_BOUND = 5.75f; //The maximum horizontal value the bar can travel
    private float dx = 0.15f; //The speed of the sliding bar
    private bool isPressed = false; //Tells whether or not the space bar has been pressed
    private bool moving = true; //Tells whether or not the bar is currently moving
    private bool movingRight = true; //Determines direction of movement
    private int successRate = 0; //How likely the player is to get a success

    // Use this for initialization
    // Just initializes the body of the moving bar
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    // Precondition: None
    // Postcondition: Checks whether or not a button has been pressed and moves the bar accordingly
	void Update ()
    {
        UpdateClicked();
        MoveBar();
	}
    
    /* Moves the bar about on the screen
     * Moves at a set speed and changes direction based on position
     * */
    //Precondition: Bar is initialized in the scene
    //Postcondition: Bar's position is updated accordingly
    private void MoveBar()
    {
        if (rigidBody.position.x >= X_BOUND)
        {
            movingRight = false;
            dx = -0.15f;
        }
        else if (rigidBody.position.x <= -(X_BOUND))
        {
            movingRight = true;
            dx = 0.15f;
        }
        
        Vector2 xMovement = new Vector2(dx, 0);
        rigidBody.MovePosition(rigidBody.position + xMovement);
    }

    //Checks whether or not a button has been pressed and updates accordingly
    //Precondition: bar is initailized and moving about on the screen
    //Postcondition: Bar is either stopped or started when the Space key is pressed
    private void UpdateClicked()
    {
        isPressed = Input.GetKeyDown(KeyCode.Space);
        if (isPressed && moving)
        {
            moving = false;
            dx = 0.0f;
            AssignWinOrLoss();
        }
        else if (isPressed && !moving)
        {
            moving = true;
            if (movingRight)
                dx = 0.15f;
            else
                dx = -0.15f;
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false; //Removes the success and fail text from screen
        }
    }

    //Checks the success rate and assigns a win or loss randomly
    //Precondition: Moving bar has been stopped by the player
    //Postcondition: A win or a loss is assigned based on the success rate
    private void AssignWinOrLoss()
    {
        System.Random random = new System.Random();
        bool winning = (random.Next(1, successRate) == 1);
        if (winning)
        {
            Goals.numWins++;
            MinigameTextController.showSuccessText = true;
            MinigameTextController.showFailText = false;
        }
        else
        {
            FlipCupGoals.numLosses++;
            MinigameTextController.showSuccessText = false;
            MinigameTextController.showFailText = true;
        }
    }

    //Changes the success rate as the bar slides around
    //Closer to the middle = higher chance of success
    //Precondition: Bar is initialized and moving around on the screen
    //Postcondition: Success rate is updated based on bar's current position
    public void OnTriggerEnter2D(Collider2D zone)
    {
        if (zone.tag == "GoalZone")
            successRate = 2; //guaranteed success
        else if (zone.tag == "GoodZone")
            successRate = 3; //50% chance of success
        else if (zone.tag == "OkayZone")
            successRate = 5; //25% chance of success
        else if (zone.tag == "BadZone")
            successRate = 11; //10% chance of success
        else
            successRate = 10000; //basically 0% chance of success
    }
}