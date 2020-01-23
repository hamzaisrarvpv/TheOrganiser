using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeCounter : MonoBehaviour
{

    private float duration;
    private float timer;
    public Image fillImage;
    public Text text;
    public Button studyButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button resetButton;
    private DateTime lastMinimize;
    private double minimizedSeconds;
    private int notificationCounter;


    //This method checks to see whether or not the application is paused (in background)
    void OnApplicationPause(bool isGamePause)
    {
        if (isGamePause && PlayerPrefs.GetInt("paused") != 1)
        {
            
            GoToMinimize();
            //#if UNITY_ANDROID

        }
        else if (!isGamePause && PlayerPrefs.GetInt("paused") != 1)
        {
            GoToMaximize();
        }

    }



    void Start()
    {

        //Checks to see if the time has been changed recently. Resets the clock if yes.
        if(PlayerPrefs.GetInt("resetClock") == 1)
        {
            PlayerPrefs.SetInt("resetClock", 0);
            Reset();
        }

        if (PlayerPrefs.GetInt("blah") != 1)
        {
            PlayerPrefs.SetInt("hasRunBefore", 1);
            PlayerPrefs.SetInt("blah", 1);
            PlayerPrefs.Save();
        }

        //If the application has opened and the timer was not running in the background. Then reset the timer.
        if (PlayerPrefs.GetInt("hasRunBefore") == 1)
        {
            ResetClock();
            Reset();
            text.text = "Study";
            fillImage.fillAmount = 1f;
            PlayerPrefs.SetInt("hasRunBefore", 0);

            //Show a quick note for brand new users.
            AndroidNative.showMessage("Quick Note", "In order to allow notifications to work, the application needs to be running in the background at all times", "Ok");
            PlayerPrefs.Save();
        }
        Screen.fullScreen = false;
        Application.runInBackground = true;
        Time.timeScale = 1.0f;

        //If the timer was already running. then catch that time and continue the timer from before.
        timer = PlayerPrefs.GetInt("time");
        duration = timer;
        timer -= TimeMaster.instance.CheckDate();


        //start the timer.
        StartCoroutine(TIMER());



    }




    //This method is run when the study button is clicked. 
    public void STARTDATIMER()
    {
        PlayerPrefs.SetInt("paused", 0);
        ResetClock();
        StartCoroutine(TIMER());
        CreateNotification.Notification("Time's up!", "Try taking a break!", timer);
        resetButton.interactable = true;
        studyButton.interactable = false;
        pauseButton.interactable = true;
        resumeButton.interactable = false;
        PlayerPrefs.SetInt("notificationCounter", 0);

    }



    //This method resets the time and deletes all saved time for when the timer would resume after starting the application again.
    public void ResetClock()
    {
        NotificationManager.CancelAll();
        TimeMaster.instance.saveData();
        if (PlayerPrefs.GetInt("time") > 0)
        {
            timer = PlayerPrefs.GetInt("time");
        }
        else
        {
            PlayerPrefs.SetInt("time", 2700);
            timer = PlayerPrefs.GetInt("time");
        }
        PlayerPrefs.SetInt("hasPlayedBefore", 2);

        timer -= TimeMaster.instance.CheckDate();
        text.text = "Study";
        PlayerPrefs.SetInt("notificationCounter", 0);
    }

    //The timer script.
    public IEnumerator TIMER()
    {

        PlayerPrefs.SetInt("notificationCounter", 0);
        timer -= Time.deltaTime * 1;


        while (PlayerPrefs.GetInt("paused") == 0)
        {



            //Changes interactability of the buttons on study page.
            studyButton.interactable = false;
            resetButton.interactable = true;
            pauseButton.interactable = true;
            resumeButton.interactable = false;

            //Changes the color of the ring around the timer.
            timer -= Time.deltaTime;
            float value = timer / duration;
            fillImage.fillAmount = value;

            //Gets the time and displays it right under the timer.
            TimeSpan t = TimeSpan.FromSeconds(timer);
            PlayerPrefs.SetInt("hours", t.Hours);
            PlayerPrefs.SetInt("minutes", t.Minutes);
            PlayerPrefs.SetInt("seconds", t.Seconds);
            PlayerPrefs.SetString("timerString", string.Format("{0:0}:{1:00}:{2:00}", PlayerPrefs.GetInt("hours"), PlayerPrefs.GetInt("minutes"), PlayerPrefs.GetInt("seconds")));
            text.text = PlayerPrefs.GetString("timerString");
            yield return null;

            //When time runs out. Create a popup and reset the timer.
            if (PlayerPrefs.GetInt("hours") <= 0 && PlayerPrefs.GetInt("minutes") <= 0 && PlayerPrefs.GetInt("seconds") <= 0 && PlayerPrefs.GetInt("notificationCounter") == 0 && PlayerPrefs.GetInt("hasPlayedBefore") == 2)
            {
                ResetClock();
                Pause();
                fillImage.fillAmount = 1f;
                PlayerPrefs.SetString("choice", "timer");
                AndroidDialog.Create("Time's Up", "Try taking a break", "Sure", "No Thanks");



                studyButton.interactable = true;
                resetButton.interactable = false;
                pauseButton.interactable = false;
                resumeButton.interactable = false;
                text.text = "Study";

                PlayerPrefs.SetInt("notificationCounter", 1);
                PlayerPrefs.Save();
            }


            if (PlayerPrefs.GetInt("paused") == 1 || PlayerPrefs.GetInt("paused") == 2)
            {
                PlayerPrefs.Save();
                break;

            }
        }


    }


    //The method that is run when the pause button is clicked. Pauses the timer.
    public void Pause()
    {
        NotificationManager.CancelAll();
        PlayerPrefs.SetInt("paused", 1);
        text.text = "Paused";
        resetButton.interactable = true;
        studyButton.interactable = false;
        pauseButton.interactable = false;
        resumeButton.interactable = true;
        StopCoroutine(TIMER());

    }

    //Resumes the timer after it has been paused.
    public void Resume()
    {
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(timer), "Time's up!", "try taking a break", new Color(0, 0.6f, 1), NotificationIcon.Message);

        PlayerPrefs.SetInt("paused", 0);
        resetButton.interactable = true;
        studyButton.interactable = false;
        pauseButton.interactable = true;
        resumeButton.interactable = false;
        StartCoroutine(TIMER());
    }

    //Resets the timer back to the start when the button is pressed.
    public void Reset()
    {
        NotificationManager.CancelAll();
        fillImage.fillAmount = 1f;
        PlayerPrefs.SetInt("paused", 2);
        resetButton.interactable = false;
        studyButton.interactable = true;
        pauseButton.interactable = false;
        resumeButton.interactable = false;
        ResetClock();
    }

    //Saves the current time before exiting the application.
    public void GoToMinimize()
    {
        PlayerPrefs.SetInt("notificationTimer", 0);
        lastMinimize = DateTime.Now;
        if (PlayerPrefs.GetInt("hours") <= 0 && PlayerPrefs.GetInt("minutes") <= 0 && PlayerPrefs.GetInt("seconds") <= 0 && PlayerPrefs.GetInt("notificationCounter") == 0)
        {


            PlayerPrefs.SetInt("notificationCounter", 1);

            //#endif
        }
    }

    //Brings back the saved time after entering the application again.
    public void GoToMaximize()
    {

        minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
        timer -= (Int32)minimizedSeconds;


    }


}

