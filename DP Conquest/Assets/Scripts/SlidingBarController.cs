using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlidingBarController : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private const float X_BOUND = 6.00f;
    private float dx = 0.15f;
    private bool isClicked = false;
    private bool moving = true;
    private bool movingRight = true;
    private int numWins = 0;
    private int numLosses = 0;

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
        CheckVictory();
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
        isClicked = Input.GetMouseButtonDown(0);
        if (isClicked && moving)
        {
            moving = false;
            dx = 0.0f;
            numLosses++;
        }
        else if (isClicked && !moving)
        {
            moving = true;
            if (movingRight)
                dx = 0.15f;
            else
                dx = -0.15f;
        }
    }

    private void CheckVictory()
    {
        if (numLosses >= 3)
        {
            PlayerController.BAC += 10;
            SceneManager.LoadScene("MiniGameLossScene");
        }
        else if (numWins >= 3)
        {
            PlayerController.BAC += 5;
            SceneManager.LoadScene("MainGameScene");
        }
    }
}