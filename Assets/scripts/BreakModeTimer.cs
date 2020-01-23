using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakModeTimer : MonoBehaviour
{
    //This method is called as soon as the user clicks to enter break mode. It takes the time that they have set for break time and counts down that time.
    public void CreateBreakModeNotification()
    {
        CreateNotification.Notification("Break Time's Up!", "Let's get back to studying!", PlayerPrefs.GetInt("breakTime"));

        
    }

    
    
    


}
