using UnityEngine;
using System.Collections;

public class SlidingBarController : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private const float X_BOUND = 6.00f;
    private float dx = 0.15f;
    private bool isClicked = false;
    private bool moving = true;
    private bool movingRight = true;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
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
        isClicked = Input.GetMouseButtonDown(0);
        if (isClicked && moving)
        {
            moving = false;
            dx = 0.0f;
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
}