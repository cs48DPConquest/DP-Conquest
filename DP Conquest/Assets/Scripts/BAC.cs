using UnityEngine;
using System.Collections;

public class BAC : MonoBehaviour {

	public float sober = 30;
	public float newBAC = 0;
	public GameObject Life;

	// Update is called once per frame
	void Update () {
		MiniBAC ();
	}

	public void MiniBAC()
	{
		if (PlayerController.BAC >= 30) {
			newBAC = 0;
			setBAC (0f);
		} 
		else {
			newBAC = ((30f - PlayerController.BAC) / 30f);
			setBAC (newBAC);
		}
	}
		
	public void setBAC(float myBAC)
	{
		Life.transform.localScale = new Vector3 (Mathf.Clamp (myBAC, 0f, 1f), Life.transform.localScale.y, Life.transform.localScale.z);
	}

}
