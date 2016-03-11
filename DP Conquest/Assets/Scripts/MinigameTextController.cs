using UnityEngine;
using System.Collections;

public class MinigameTextController : MonoBehaviour
{
    public static bool showSuccessText;
    public static bool showFailText;
    private GameObject successImg;
    private GameObject failImg;

    //Initializes all member variables
    //Precondition: None
    //Postcondition: Initializes all variables, sets default to not display images
    private void Start()
    {
        successImg = GameObject.FindGameObjectWithTag("SuccessText");
        failImg = GameObject.FindGameObjectWithTag("FailText");

        showFailText = false;
        showSuccessText = false;
    }

    /* A function called once perframe
     * Controls the display of the success and fail images
     * Precondition: Player is in FlipCupMinigame
     * Postcondition: Success or failure is displayed depending on player status
     */

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
