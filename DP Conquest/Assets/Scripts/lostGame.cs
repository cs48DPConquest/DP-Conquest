using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class lostGame : MonoBehaviour {

	GameObject ball;
	GameObject cup;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        cup = GameObject.FindGameObjectWithTag("RedCup_paddle");
    }

	void Update ()
	{
		if(BeerPongGoals.isOver == true)
		{
			Destroy(cup);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
            BeerPongGoals.isOver = true;
			Destroy (ball);
		}
	}
}

