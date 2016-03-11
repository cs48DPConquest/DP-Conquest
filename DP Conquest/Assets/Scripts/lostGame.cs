using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LostGame : MonoBehaviour
{

	GameObject ball;
	GameObject cup;

    //Called when the game starts
    //Precondition: Game is being loaded into the scene
    //Postcondition: ball and cup have been initialized to the proper scene objects
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        cup = GameObject.FindGameObjectWithTag("RedCup_paddle");
    }

    //Called once per frame
    //Precondition: Game is currently ongoing
    //Postcondition: Destroys the cup when the game is over
	void Update ()
	{
		if(BeerPongGoals.isOver == true)
		{
			Destroy(cup);
		}
	}

    //Called when something collides with the 'death' zone
    //Precondition: Something has hit the death zone
    //Postcondition: Ends the game if it is the ball that hit
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
            BeerPongGoals.isOver = true;
			Destroy (ball);
		}
	}
}

