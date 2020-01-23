using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorTasks : MonoBehaviour
{

    public Image task;
 
    void Update()
    {
        // constantly check if user enters dark/light mode

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
        // changes the task's color to dark mode
        PlayerPrefs.SetInt("colourInt", 1);


        Color d = new Color32(0, 0, 0, 1);
        

        task.color = d;
    }


    public void EnableLightMode()
    {
        // changes the task's color to light mode

        PlayerPrefs.SetInt("colourInt", 0);


        Color c = new Color32(189, 195, 199, 1);


        task.color = c;

    }
}
