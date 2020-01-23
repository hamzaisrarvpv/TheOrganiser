using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakModeTimer : MonoBehaviour
{
    
    public void CreateBreakModeNotification()
    {
        CreateNotification.Notification("Break Time's Up!", "Let's get back to studying!", PlayerPrefs.GetInt("breakTime"));

        
    }

    
    
    


}
