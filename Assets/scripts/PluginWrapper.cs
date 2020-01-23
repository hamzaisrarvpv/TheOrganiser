using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PluginWrapper : MonoBehaviour
{
    private AndroidJavaObject javaClass;
    void Start()
    {
        // call notification services
        javaClass = new AndroidJavaObject("com.example.notificationservice.MainActivity");
        javaClass.Call("sendOnChannel1", null);
    }
}
