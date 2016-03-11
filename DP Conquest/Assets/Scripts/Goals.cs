using UnityEngine;
using System.Collections;

public abstract class Goals : MonoBehaviour
{
    //Abstract class to represent the general idea of goals
    //Extended by both minigame goals

	public static int numWins=0; //Static int representing the number of wins
    
    // Update is called once per frame
    // Each frame, it is checked to see if the player wins
    // Precondition: Player is in a minigame
    // Postcondition: The CheckWin() method is called
	void Update ()
    {
		CheckWin ();
	}

    protected abstract void CheckWin();
}

