using UnityEngine;
using System.Collections;

public class MinigameTextController : MonoBehaviour {

    public static bool showSuccessText;
    public static bool showFailText;
    private GameObject successImg;
    private GameObject failImg;

    private void Start()
    {
        successImg = GameObject.FindGameObjectWithTag("SuccessText");
        failImg = GameObject.FindGameObjectWithTag("FailText");

        showFailText = false;
        showSuccessText = false;
    }

    private void Update()
    {
        if (showSuccessText)
        {
            successImg.SetActive(true);
            failImg.SetActive(false);
        }
        else if (showFailText)
        {
            successImg.SetActive(false);
            failImg.SetActive(true);
        }
        else
        {
            successImg.SetActive(false);
            failImg.SetActive(false);
        }
    }
}
