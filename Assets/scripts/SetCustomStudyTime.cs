using TMPro;
using UnityEngine;


public class SetCustomStudyTime : MonoBehaviour
{
    public TMP_InputField Time;
    public TMP_InputField BreakTime;
    private RealTimeCounter lol;



    public void SetTime()
    {

        // sets the time which the user spends studying before the timer runs out
        if (int.Parse(Time.text) != 0)
        {
            PlayerPrefs.SetInt("time", (int.Parse(Time.text)) * 60);
            AndroidNative.showMessage("Alert", "Time has been changed", "Ok");
            PlayerPrefs.SetInt("resetClock", 1);


        }
        else
        {
            AndroidNative.showMessage("Alert", "Please enter a valid number", "Ok");
        }

    }

    public void SetBreakTime()
    {
        // sets the time for how long the break should be
        if (int.Parse(Time.text) != 0)
        {
            PlayerPrefs.SetInt("breakTime", (int.Parse(BreakTime.text)) * 60);
            AndroidNative.showMessage("Alert", "Time has been changed", "Ok");
        }
        else
        {
            AndroidNative.showMessage("Alert", "Please enter a valid number", "Ok");
        }
    }


}









