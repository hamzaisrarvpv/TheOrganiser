using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToSeeIfStillBreakTime : MonoBehaviour
{

    public void SetTimer()
    {
        // bring the user to a break pae when the timer is over, if he chooses to do so
        CreateNotification.Notification("Break time is over!", "Let's go back to studying", PlayerPrefs.GetInt("breakTime"));
    }
}
