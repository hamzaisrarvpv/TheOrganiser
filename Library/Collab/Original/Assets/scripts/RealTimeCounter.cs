using Assets.SimpleAndroidNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public  class RealTimeCounter : MonoBehaviour
{
    
    private float duration;
    private float timer = 2700;
    public Image fillImage;
    public Text text;
    public Button studyButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button resetButton;
    private DateTime lastMinimize;
    private double minimizedSeconds;
    private int notificationCounter;



    void OnApplicationPause(bool isGamePause)
    {
        if (isGamePause)
        {

            GoToMinimize();
#if UNITY_ANDROID
            
        }
        else
        {
            GoToMaximize();
        }
        
    }

    void OnApplicationFocus(bool isGameFocus)
    {
        if (isGameFocus)
        {
            //GoToMaximize();
        }
    }
    void Start()
    {
        Screen.fullScreen = false;
        Application.runInBackground = true;
        Time.timeScale = 1.0f;
        timer = PlayerPrefs.GetInt("time");
        duration = timer;
        timer -= TimeMaster.instance.CheckDate();

        if (PlayerPrefs.GetInt("hours") != 0 && PlayerPrefs.GetInt("minutes") != 0 && PlayerPrefs.GetInt("seconds") != 0)
        {

            StartCoroutine(TIMER());
        }else
        {
            StartCoroutine(TIMER());
        }

    }

    


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




     void ResetClock()
        {
        NotificationManager.CancelAll();
        TimeMaster.instance.saveData();
        
         timer = PlayerPrefs.GetInt("time");
        PlayerPrefs.SetInt("hasPlayedBefore", 2);
        
        timer -= TimeMaster.instance.CheckDate();
        text.text = "Study";
        PlayerPrefs.SetInt("notificationCounter", 0);
    }

    public IEnumerator TIMER()
    {
        
        PlayerPrefs.SetInt("notificationCounter", 0);
        timer -= Time.deltaTime * 1;
        while (PlayerPrefs.GetInt("paused") == 0)
        {
            
                

            
            studyButton.interactable = false;
            resetButton.interactable = true;
            pauseButton.interactable = true;
            resumeButton.interactable = false;

            timer -= Time.deltaTime;
            float value = timer / duration;
            fillImage.fillAmount = value;
            TimeSpan t = TimeSpan.FromSeconds(timer);
            PlayerPrefs.SetInt("hours",t.Hours);
            PlayerPrefs.SetInt("minutes", t.Minutes);
            PlayerPrefs.SetInt("seconds", t.Seconds);
            PlayerPrefs.SetString("timerString", string.Format("{0:0}:{1:00}:{2:00}", PlayerPrefs.GetInt("hours"), PlayerPrefs.GetInt("minutes"), PlayerPrefs.GetInt("seconds")));
            text.text = PlayerPrefs.GetString("timerString");
            yield return null;
            if (PlayerPrefs.GetInt("hours") <= 0 && PlayerPrefs.GetInt("minutes") <= 0 && PlayerPrefs.GetInt("seconds") <= 0 && PlayerPrefs.GetInt("notificationCounter") == 0 && PlayerPrefs.GetInt("hasPlayedBefore") == 2)
            {
                ResetClock();
                Pause();
                fillImage.fillAmount = 1f;
                AndroidDialog.Create("Time's Up", "Try taking a break", "Sure", "No Thanks");
                
                
                studyButton.interactable = true;
                resetButton.interactable = false;
                pauseButton.interactable = false;
                resumeButton.interactable = false;
                text.text = "Study";

                PlayerPrefs.SetInt("notificationCounter", 1);
                PlayerPrefs.Save();
            }

            
            if (PlayerPrefs.GetInt("paused") == 1 || PlayerPrefs.GetInt("paused") == 2 )
            {
                PlayerPrefs.Save();
                break;
                
            }
        }
        

    }

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

    public void GoToMinimize()
    {
        PlayerPrefs.SetInt("notificationTimer", 0);
        lastMinimize = DateTime.Now;
        if (PlayerPrefs.GetInt("hours") <= 0 && PlayerPrefs.GetInt("minutes") <= 0 && PlayerPrefs.GetInt("seconds") <= 0 && PlayerPrefs.GetInt("notificationCounter") == 0)
        {

            
            PlayerPrefs.SetInt("notificationCounter", 1);

#endif
        }
    }

    public void GoToMaximize()
    {

        minimizedSeconds = (DateTime.Now - lastMinimize).TotalSeconds;
        timer -= (Int32)minimizedSeconds;


    }


}

