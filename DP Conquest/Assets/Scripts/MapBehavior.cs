using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapBehavior : MonoBehaviour
{

    private void Start()
    {
        foreach (string tag in HouseScript.triggerTags)
        {
            Destroy(GameObject.FindGameObjectWithTag(tag));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("PauseScene");
    }
}
