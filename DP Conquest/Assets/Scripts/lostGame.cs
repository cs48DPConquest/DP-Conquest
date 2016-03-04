using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class lostGame : MonoBehaviour {

	GameObject ball;
	GameObject cup;
	bool isOver;


	void Update ()
	{

		ball = GameObject.FindGameObjectWithTag ("Ball");
		cup = GameObject.FindGameObjectWithTag ("RedCup_paddle");

		if(isOver == true)
		{
			Destroy (cup);
            Goals.g = 0;
			PlayerController.BAC += 10;
            PlayerController.TotalGames += 1;
			SceneManager.LoadScene("MiniGameLossScene");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
			isOver = true;
			Destroy (ball);
		}
	}
}

