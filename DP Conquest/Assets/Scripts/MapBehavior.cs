using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapBehavior : MonoBehaviour
{
    //Called whenever the map is loaded
    //Precondition: Map is loaded as the main scene
    //Postcondition: All minigame triggers that have been activated previously are destroyed
    private void Start()
    {
        foreach (string tag in HouseScript.triggerTags)
        {
            Destroy(GameObject.FindGameObjectWithTag(tag));
        }
    }

    //Called once per frame
    //Precondition: Map is loaded as the main scene
    //Postcondition: Brings up the pause menu when Escape key is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("PauseScene");
    }
}
