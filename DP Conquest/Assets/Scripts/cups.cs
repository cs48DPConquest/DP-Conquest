using UnityEngine;
using System.Collections;

public class cups : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
			FlipCupGoals.numWins += 1;
			Destroy (gameObject);
		}
	}
}
