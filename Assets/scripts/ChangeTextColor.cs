using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextColor : MonoBehaviour
{
    // constantly check if the user enters dark/light mode
    void Update()
    {
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
        // change text color to dark mode
        PlayerPrefs.SetInt("colourInt", 1);

        
        Color d = Color.white;
        GetComponent<TMP_Text>().color = Color.grey;

    }


    public void EnableLightMode()
    {

        // change text color to light mode
        PlayerPrefs.SetInt("colourInt", 0);

        
        Color d = Color.black;

        GetComponent<TMP_Text>().color = d;

    }
}
