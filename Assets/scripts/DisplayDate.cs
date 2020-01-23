using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class DisplayDate : MonoBehaviour
{

    //Takes the current date of the device that the applciation is running on.
    public Text date;
    public static string TodayNum = DateTime.Now.ToString("dd");        // e.g 07
    public static string ThisMonthLong = DateTime.Now.ToString("MMMM");  // e.g March
    public static string ThisYearNum = DateTime.Now.ToString("yyyy");   // e.g 2014


    void Awake()
    {
        //Sets the date page on the start page
        string DisplayDate = "The date is " + ThisMonthLong + ", " + TodayNum + ", " + ThisYearNum;
        date.text = DisplayDate;

    }



}
     
 
