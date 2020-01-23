using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class taskManager : MonoBehaviour
{
    // references
    public TMP_InputField Name;
    public TMP_InputField Date;
    public GameObject taskP;
    public GameObject parent;

    public static int index;
    int width = 840;
    int height = 0;



    void Start()
    {
        index = PlayerPrefs.GetInt("index");
        height = 0;
        Debug.Log(index);
        Debug.Log(PlayerPrefs.GetString("269"));
        //PlayerPrefs.SetInt("NumTasks", 2);
        
        for (int i = 0; i < PlayerPrefs.GetInt("index"); i++)
        {

            if (PlayerPrefs.GetString("" + (i + 1)) != "")
            {

                // recall tasks
                string __name = PlayerPrefs.GetString("" + (i + 1));

                string _name = __name.Remove(__name.IndexOf(","));
                string __date = __name.Substring(__name.IndexOf(",") + 1);
                string _date = __date.Remove(__date.IndexOf(","));
                string _title = __date.Substring(__date.IndexOf(",") + 1);

                // expand content area
                height = height + 147;
                parent.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

                // create task
                GameObject taskClone = Instantiate(taskP, parent.transform);

                // change name of instantiated GameObject
                taskClone.gameObject.name = _title;
                taskClone.GetComponentInChildren<TMP_Text>().text = _name + ", " + _date;

            }

        }

    }
    public void AddTask()
    {

        // expand content area
        height = height + 147;
        parent.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // create task
        GameObject taskClone = Instantiate(taskP, parent.transform);
        index = PlayerPrefs.GetInt("index");
        index++;

        // change name of instantiated GameObject
        taskClone.gameObject.name = "" + index;
        taskClone.GetComponentInChildren<TMP_Text>().text = Name.text + "," + Date.text;

        // save new task
        SaveData();


    }

    public void SaveData()
    {

        PlayerPrefs.SetString("" + index, Name.text + "," + Date.text + "," + index);
        PlayerPrefs.SetInt("index", index);
        int temp = PlayerPrefs.GetInt("NumTasks");
        PlayerPrefs.SetInt("NumTasks", temp + 1);

    }

}