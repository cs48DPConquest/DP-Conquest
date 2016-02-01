using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class YellowHouseScript : MonoBehaviour {
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    */

    // note game levels not yet implemented

    public string gameType;

    void OnTriggerEnter2D(Collider2D player)
    { 
        SceneManager.LoadScene(gameType);
    } 


}
