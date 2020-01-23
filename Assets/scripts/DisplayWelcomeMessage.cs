using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayWelcomeMessage : MonoBehaviour
{

    //When the application is opened and the user enters the start page, a welcome message is shown with their name if they have set it.
    public TMP_Text welcomeMessage;
    void Awake()
    {
       string Display = "Welcome " + PlayerPrefs.GetString("name") + "!";
        welcomeMessage.text = Display;
    }
}
