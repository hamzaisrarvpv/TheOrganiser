using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster: MonoBehaviour
{

    DateTime currentDate;
    DateTime oldDate;
    public string saveLocation;
    public static TimeMaster instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        saveLocation = "lastSavedDate1";
    }


    //The method checks the current time and checks whether or not any time has passed since last check.
    //If so then the time is subtracted from the RealTimeCounter script.
    public float CheckDate()
    {

        currentDate = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(saveLocation, "1");
        long tempLong = Convert.ToInt64(tempString);
        DateTime oldDate = DateTime.FromBinary(tempLong);

        TimeSpan difference = currentDate.Subtract(oldDate);

        return (float)difference.TotalSeconds;


    }
    //Saves the current time
    public void saveData()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());

    }
}
