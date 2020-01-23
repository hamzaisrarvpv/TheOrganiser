using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeViewPortColor : MonoBehaviour
{

    public Image Later;
    public Image Tasks;
    public Image Done;
    void Update()
    {

        // constantly check if user enters light or dark mode
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
        Done.color = d;
        Tasks.color = d;
        Later.color = d;
    }


    public void EnableLightMode()
    {
        // changes the viewport's color to light mode

        PlayerPrefs.SetInt("colourInt", 0);


        Color d = Color.white;

        Done.color = d;
        Tasks.color = d;
        Later.color = d;

    }
}
