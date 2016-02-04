using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMapScript : MonoBehaviour {


    public void onMapButtonPress()
    {

        SceneManager.LoadScene("MainGameScene");

    }

    // Use this for initialization
    void Start () {
        //onMapButtonPress();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
