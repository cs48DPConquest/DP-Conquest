using UnityEngine;
using System.Collections;

public abstract class Goals : MonoBehaviour {

	public static int numWins=0;
    // Update is called once per frame

	void Update ()
    {
		CheckWin ();
	}

    protected abstract void CheckWin();
}

