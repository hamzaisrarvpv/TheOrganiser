using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeViewPortColorClass : MonoBehaviour
{

    public Image Class;
    
    void Update()
    {

        // constantly check if user entered dark mode or light mode
        if (PlayerPrefs.GetInt("colourInt") == 1)
        {
            EnableDarkMode();

        }
        else if (PlayerPrefs.GetInt("colourInt") == 0)
        {
            EnableLightMode();
        }

    }

    public void EnableDarkMode()
    {
        // changes the viewport's color to dark mode
        PlayerPrefs.SetInt("colourInt", 1);
        Color d = Color.grey;
        Class.color = d;
    }


    public void EnableLightMode()
    {

        // changes the viewport's color to light mode
        PlayerPrefs.SetInt("colourInt", 0);
        Color d = Color.white;
        Class.color = d;

    }
}
