using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlidingBarController : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private const float X_BOUND = 5.75f;
    private float dx = 0.15f;
    private bool isPressed = false;
    private bool moving = true;
    private bool movingRight = true;
    private int numWins = 0;
    private int numLosses = 0;
    private int successRate = 0;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateClicked();
        MoveBar();
	}
    
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
            MinigameTextController.showFailText = MinigameTextController.showSuccessText = false;
        }
    }

    private void AssignWinOrLoss()
    {
        System.Random random = new System.Random();
        bool winning = (random.Next(1, successRate) == 1);
        if (winning)
        {
            FlipCupGoals.numWins++;
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

    public void OnTriggerEnter2D(Collider2D zone)
    {
        if (zone.tag == "GoalZone")
            successRate = 2; //guaranteed success
        else if (zone.tag == "GoodZone")
            successRate = 3; //50-50 shot at success
        else if (zone.tag == "OkayZone")
            successRate = 5; //25% chance of success
        else if (zone.tag == "BadZone")
            successRate = 11; //10% chance of success
        else
            successRate = 10000; //basically 0% chance of success but idk how to do that lol
    }
}