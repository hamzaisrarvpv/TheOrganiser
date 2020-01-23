using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControls : MonoBehaviour
{

    //Sets whether the time is paused, resumed. or reset
    public void Pause()
    {
        PlayerPrefs.SetInt("paused", 1);
        PlayerPrefs.SetInt("resume", 0);
        PlayerPrefs.SetInt("reset", 0);
    }

    public void Resume()
    {
        PlayerPrefs.SetInt("paused", 0);
        PlayerPrefs.SetInt("resume", 1);
        PlayerPrefs.SetInt("reset", 0);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("paused", 0);
        PlayerPrefs.SetInt("resume", 0);
        PlayerPrefs.SetInt("reset", 1);
    }

    
}
