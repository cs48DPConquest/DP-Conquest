using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goals : MonoBehaviour {

	public static int g=0;
	// Update is called once per frame
	void Update () {
		CheckWin ();
	}

	private void CheckWin()
	{
		if (g >= 6) {
			g = 0;
			PlayerController.BAC += 5;
            PlayerController.TotalGames += 1;
			SceneManager.LoadScene("MainGameScene");
		}
	}
}

