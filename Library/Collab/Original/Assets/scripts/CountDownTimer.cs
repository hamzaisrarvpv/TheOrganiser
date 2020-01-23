using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    public static float duration;
    public Image fillImage;
    public Text CountText;
    private float startTime;
    private float time;
    private float value;
    public Button studyButton;
    public Button pauseButton;
    public Button resumeButton;
    



     
    public void buttonClick()
    {

        fillImage.fillAmount = 1f;

        setVariables();

        StartCoroutine(Timer(duration));

    }

    public void setVariables()
    {

        PlayerPrefs.SetInt("paused", 1);

        duration = PlayerPrefs.GetInt("time");

        if (duration == 0)
        {

            duration = 10;
            PlayerPrefs.SetInt("time", 10);

        }
        duration = duration * 60;
        startTime = Time.time;
        time = duration;
        value = 0;

    }

    public IEnumerator Timer(float duration)
    {

     

        
            while (PlayerPrefs.GetInt("paused") == 1 && Time.time - startTime < duration)
            {


            resumeButton.interactable = false;
            pauseButton.interactable = true;
            studyButton.interactable = false;
            time -= Time.deltaTime;
                value = time / duration;
                fillImage.fillAmount = value;
                TimeSpan t = TimeSpan.FromSeconds(time);
                float hours = t.Hours;
                float minutes = t.Minutes;
                float seconds = t.Seconds;
                string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
                CountText.text = timerString;
                yield return null;
            if (seconds == 0 && hours == 0 && minutes == 0){

                SceneManager.LoadScene("RelaxModePopup");
            }
            

        }





        
    }



    public void Pause()
    {

        PlayerPrefs.SetInt("paused", 0);
        CountText.text = "Paused";
        resumeButton.interactable = true;
        pauseButton.interactable = false;
        studyButton.interactable = false;
        StartCoroutine(Timer(duration));

    }

    public void Resume()
    {
        PlayerPrefs.SetInt("paused", 1);
        resumeButton.interactable = false;
        pauseButton.interactable = true;
        studyButton.interactable = false;
        StartCoroutine(Timer(duration));
        

    }


}



