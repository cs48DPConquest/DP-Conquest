using UnityEngine;
using System.Collections;

public class Cups : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
			FlipCupGoals.numWins += 1;
			Destroy (gameObject);
		}
	}
}
