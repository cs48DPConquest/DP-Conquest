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
			PlayerController.BAC += 10;
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

