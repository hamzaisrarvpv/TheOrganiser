using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

     void Update()
    {
        
    }


    public static float duration;
    
    //Initilzing timer variables.
    private static float startTime;
    private static float time;
    private static float value;
    

    //Initilizing the fill image and the text.
    public Image fillImage;
    public Text CountText;

    //Initilizing all buttons.
    public Button studyButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button resetButton;

    static float hours;
    static float minutes;
    static float seconds;

    static string timerString;

   
    //This method is called when the study button is clicked.
    public void buttonClick()
    {

        fillImage.fillAmount = 1f;

        setVariables();

        StartCoroutine(Timer(duration));

        
    }

    //This method is set the default numbers of the variables
    public void setVariables()
    {
        
        PlayerPrefs.SetInt("paused", 1);
        

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

    //Timer Script
    public IEnumerator Timer(float duration)
    {
            
            Debug.Log("" + Time.time);

            while (PlayerPrefs.GetInt("paused") == 1 && Time.time - startTime < duration)
            {
            Time.timeScale = 1;

            resumeButton.interactable = false;
            pauseButton.interactable = true;
            studyButton.interactable = false;
            resetButton.interactable = true;
            time -= Time.deltaTime;
            value = time / duration;
            fillImage.fillAmount = value;
            TimeSpan t = TimeSpan.FromSeconds(time);
            hours = t.Hours;
            minutes = t.Minutes;
            seconds = t.Seconds;
            timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
            CountText.text = timerString;

            //Loads the relax popup scene if time hits zero.
            if (seconds == 0 && hours == 0 && minutes == 0)
            {

                SceneManager.LoadScene("RelaxPopup");
            }

            //breaks the loop if the reset button is clicked.
            if (PlayerPrefs.GetInt("paused") == 2)
            {
                break;
            }
            yield return null;
           
            

        }

    }
    
    //this method is called when the pause button is clicked.
    public void Pause()
    {
        //Pauses the timer
        PlayerPrefs.SetInt("paused", 0);
        CountText.text = "Paused";

        //Changes the interactability of the buttons
        resumeButton.interactable = true;
        pauseButton.interactable = false;
        studyButton.interactable = false;
        resetButton.interactable = true;

        //Start the timer again
        StartCoroutine(Timer(duration));

        //Sets the time scale to zero so time stops incrementing.
        Time.timeScale = 0;

    }

    //This method is called when the resume button is clicked.
    public void Resume()
    {
        //Resumes the timer
        PlayerPrefs.SetInt("paused", 1);

        //Changes interacability of the buttons.
        resumeButton.interactable = false;
        pauseButton.interactable = true;
        studyButton.interactable = false;
        resetButton.interactable = true;
        StartCoroutine(Timer(duration));
        

    }

    //This method is called when the reset button is clicked
    public void ResetThatOne()
    {

        //Resets the timer
        PlayerPrefs.SetInt("paused", 2);
        CountText.text = "Study";
        fillImage.fillAmount = 1f;

        //Changes interactability of the buttons.
        studyButton.interactable = true;
        pauseButton.interactable = false;
        resumeButton.interactable = false;
        resetButton.interactable = false;

    }

    


}



