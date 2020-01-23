using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNotification : MonoBehaviour
{
   public static void Notification(string title, string message, float seconds)
    {
        // methode that can be called to create a notification
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(seconds),title, message, new Color(0, 0.6f, 1), NotificationIcon.Message);
    }
}
