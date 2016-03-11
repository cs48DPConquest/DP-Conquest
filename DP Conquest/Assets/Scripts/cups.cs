using UnityEngine;
using System.Collections;

public class Cups : MonoBehaviour
{

    /* Function to remove the cups when hit
     * 
     * Precondition: Minigame is currently in play
     * Postconditions: Cup is removed crom screen when hit
     * The player points is also incremented
     */
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ball") {
			FlipCupGoals.numWins += 1;
			Destroy (gameObject);
		}
	}
}
