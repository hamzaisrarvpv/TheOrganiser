using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class taskManager : MonoBehaviour
{
    // object references
    public GameObject taskP;
    public TMP_InputField NameSoon;
    public TMP_InputField ddSoon;
    public TMP_InputField mmSoon;
    public TMP_InputField yyyySoon;
    public TMP_Dropdown classSoon;
    public GameObject parentSoon;
    public TMP_InputField NameLater;
    public TMP_InputField ddLater;
    public TMP_InputField mmLater;
    public TMP_InputField yyyyLater;
    public TMP_Dropdown classLater;
    public GameObject parentLater;
    public GameObject parentDone;


    // local variables
    public int index;
    public string optionSelected = "Auto";
    readonly public int width = 840;
    public int heightSoon = 0;
    public int heightLater = 0;
    public int heightDone = 0;
    string urgency;

    private List<string> classes = new List<string>();



    // called once when scene is loaded
    void Start()
    {
        // check if there are any tasks. if not, set index to 0 so app doesnt crash
        if (PlayerPrefs.GetInt("index") <= 0) { PlayerPrefs.SetInt("index", 1); }

        // give value to local variables
        index = PlayerPrefs.GetInt("index");
        heightSoon = 0;

        // instantiate saved tasks
        for (int i = 0; i < (PlayerPrefs.GetInt("index") + 1); i++)
        {

            if (PlayerPrefs.GetString("" + (i + 1)) != "")
            {

                // recall tasks

                // recall name
                string __name = PlayerPrefs.GetString("" + (i + 1));

                // break name into smaller more useful parts
                string _name = __name.Remove(__name.IndexOf(","));
                string __noName = __name.Substring(__name.IndexOf(",") + 1);
                string _date = __noName.Remove(__noName.IndexOf(","));
                string _noNameNoDate = __noName.Substring(__noName.IndexOf(",") + 1);
                string _title = _noNameNoDate.Remove(_noNameNoDate.IndexOf(","));
                string _noTitle = _noNameNoDate.Substring(_noNameNoDate.IndexOf(",") + 1);
                string _position = _noTitle.Remove(_noTitle.IndexOf(","));
                string _noPosition = _noTitle.Substring(_noTitle.IndexOf(",") + 1);
                string _class = _noPosition.Remove(_noPosition.IndexOf(","));
                string _index = _noPosition.Substring(_noPosition.IndexOf(",") + 1);

                // break date into even smaller parts
                int day = System.Convert.ToInt32(_date.Remove(_date.IndexOf("/")));
                string _noDay = _date.Substring(_date.IndexOf("/") + 1);
                int month = System.Convert.ToInt32(_noDay.Remove(_noDay.IndexOf("/")));
                int year = System.Convert.ToInt32(_noDay.Substring(_noDay.IndexOf("/") + 1));

                // set the position where the task is instantiated
                string trueUrgency = _position;
                if (trueUrgency == "Soon")
                {

                    // expand content area
                    heightSoon = heightSoon + 147;
                    parentSoon.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightSoon);

                    // create task
                    GameObject taskClone = Instantiate(taskP, parentSoon.transform);


                    // change name of instantiated GameObject
                    taskClone.gameObject.name = _title;
                    taskClone.GetComponentInChildren<TMP_Text>().text = _name + ", " + day + "/" + month;


                }
                else if (trueUrgency == "Later")
                {

                    // expand content area
                    heightLater = heightLater + 147;
                    parentLater.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightLater);

                    // create task
                    GameObject taskClone = Instantiate(taskP, parentLater.transform);

                    // change name of instantiated GameObject
                    taskClone.gameObject.name = _title;
                    taskClone.GetComponentInChildren<TMP_Text>().text = _name + ", " + day + "/" + month;


                }
                else if (trueUrgency == "Done")
                {

                    // expand content area
                    heightDone = heightDone + 147;
                    parentDone.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightDone);

                    // create task
                    GameObject taskClone = Instantiate(taskP, parentDone.transform);

                    // change name of instantiated GameObject
                    taskClone.gameObject.name = _title;
                    taskClone.GetComponentInChildren<TMP_Text>().text = _name + ", " + day + "/" + month;


                }



            }


        }
        // check if there are any classes and add them to the selection dropdown
        for (int j = 0; j < PlayerPrefs.GetInt("cIndex"); j++)
        {

            if (PlayerPrefs.GetString("c" + (j + 1)) != "")
            {
                string __name = PlayerPrefs.GetString("c" + (j + 1));
                string _name = __name.Remove(__name.IndexOf(","));


                classes.Add(_name);
                Debug.Log("added Class");

            }

        }
        classSoon.AddOptions(classes);
        classLater.AddOptions(classes);

    }

    // method for adding tasks from the "soon" page
    public void AddTaskFromSoon()
    {
        if (NameSoon.text != "" && ddSoon.text != "" && mmSoon.text != "")
        {
            if (System.Convert.ToInt32(ddSoon.text) >= 1 && System.Convert.ToInt32(mmSoon.text) >= 1 && System.Convert.ToInt32(mmSoon.text) <= 12)
            {
                // check if year and month and days match. ex: february can't have 30 days, and April can't have 31 days
                if ((System.Convert.ToInt32(mmSoon.text) == 1 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 2 && System.Convert.ToInt32(ddSoon.text) <= 29 && System.Convert.ToInt32(yyyySoon.text) % 4 == 0) ||
                    (System.Convert.ToInt32(mmSoon.text) == 2 && System.Convert.ToInt32(ddSoon.text) <= 28 && System.Convert.ToInt32(yyyyLater.text) % 4 != 0) ||
                    (System.Convert.ToInt32(mmSoon.text) == 3 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 4 && System.Convert.ToInt32(ddSoon.text) <= 30) ||
                    (System.Convert.ToInt32(mmSoon.text) == 5 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 6 && System.Convert.ToInt32(ddSoon.text) <= 30) ||
                    (System.Convert.ToInt32(mmSoon.text) == 7 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 8 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 9 && System.Convert.ToInt32(ddSoon.text) <= 30) ||
                    (System.Convert.ToInt32(mmSoon.text) == 10 && System.Convert.ToInt32(ddSoon.text) <= 31) ||
                    (System.Convert.ToInt32(mmSoon.text) == 11 && System.Convert.ToInt32(ddSoon.text) <= 30) ||
                    (System.Convert.ToInt32(mmSoon.text) == 12 && System.Convert.ToInt32(ddSoon.text) <= 31))
                {



                    // find urgency of task
                    urgency = setUrgency("" + ddSoon.text + "/" + mmSoon.text + "/" + yyyySoon.text);

                    if (urgency == "Soon")
                    {

                        // expand content area
                        heightSoon = heightSoon + 147;
                        parentSoon.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightSoon);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentSoon.transform);
                        index = PlayerPrefs.GetInt("index");


                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameSoon.text + " , " + ddSoon.text + "/" + mmSoon.text;

                        // save new task
                        SaveData("soon");

                        

                    }
                    else if (urgency == "Later")
                    {


                        // expand content area
                        heightLater = heightLater + 147;
                        parentLater.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightLater);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentLater.transform);
                        index = PlayerPrefs.GetInt("index");

                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameSoon.text + " , " + ddSoon.text + "/" + mmSoon.text;

                        // save new task
                        SaveData("soon");

                        

                    }
                    else if (urgency == "Done")
                    {

                        // expand content area
                        heightDone = heightDone + 147;
                        parentDone.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightDone);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentDone.transform);
                        index = PlayerPrefs.GetInt("index");


                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameSoon.text + " , " + ddSoon.text + "/" + mmSoon.text;

                        // save new task
                        SaveData("soon");

                       

                    }

                }
                else
                {

                    Warning(1);

                }


            }
            else
            {

                Warning(2);

            }




        }
        else
        {

            Warning(3);

        }



    }
    // method to add tasks from the "later" page
    public void AddTaskFromLater()
    {
        if (NameLater.text != "" && ddLater.text != "" && mmLater.text != "")
        {
            if (System.Convert.ToInt32(ddLater.text) >= 1 && System.Convert.ToInt32(mmLater.text) >= 1 && System.Convert.ToInt32(mmLater.text) <= 12)
            {
                // check if year and month and days match. ex: february can't have 30 days, and April can't have 31 days
                if ((System.Convert.ToInt32(mmLater.text) == 1 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 2 && System.Convert.ToInt32(ddLater.text) <= 29 && System.Convert.ToInt32(yyyyLater.text) % 4 == 0) ||
                    (System.Convert.ToInt32(mmLater.text) == 2 && System.Convert.ToInt32(ddLater.text) <= 28 && System.Convert.ToInt32(yyyyLater.text) % 4 != 0) ||
                    (System.Convert.ToInt32(mmLater.text) == 3 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 4 && System.Convert.ToInt32(ddLater.text) <= 30) ||
                    (System.Convert.ToInt32(mmLater.text) == 5 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 6 && System.Convert.ToInt32(ddLater.text) <= 30) ||
                    (System.Convert.ToInt32(mmLater.text) == 7 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 8 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 9 && System.Convert.ToInt32(ddLater.text) <= 30) ||
                    (System.Convert.ToInt32(mmLater.text) == 10 && System.Convert.ToInt32(ddLater.text) <= 31) ||
                    (System.Convert.ToInt32(mmLater.text) == 11 && System.Convert.ToInt32(ddLater.text) <= 30) ||
                    (System.Convert.ToInt32(mmLater.text) == 12 && System.Convert.ToInt32(ddLater.text) <= 31))
                {



                    // finda actual urgency
                    urgency = setUrgency(ddLater.text + "/" + mmLater.text + "/" + yyyyLater.text);




                    if (urgency == "Soon")
                    {


                        // expand content area
                        heightSoon = heightSoon + 147;
                        parentSoon.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightSoon);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentSoon.transform);
                        index = PlayerPrefs.GetInt("index");


                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameLater.text + " , " + ddLater.text + "/" + mmLater.text;

                        // save new task
                        SaveData("later");

                        //index++;

                    }
                    else if (urgency == "Later")
                    {


                        // expand content area
                        heightLater = heightLater + 147;
                        parentLater.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightLater);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentLater.transform);
                        index = PlayerPrefs.GetInt("index");


                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameLater.text + " , " + ddLater.text + "/" + mmLater.text;

                        // save new task
                        SaveData("later");

                        //index++;

                    }
                    else if (urgency == "Done")
                    {


                        // expand content area
                        heightDone = heightDone + 147;
                        parentDone.GetComponent<RectTransform>().sizeDelta = new Vector2(width, heightDone);

                        // create task
                        GameObject taskClone = Instantiate(taskP, parentDone.transform);
                        index = PlayerPrefs.GetInt("index");


                        // change name of instantiated GameObject
                        taskClone.gameObject.name = "" + (index + 1);
                        taskClone.GetComponentInChildren<TMP_Text>().text = NameLater.text + " , " + ddLater.text + "/" + mmLater.text;

                        // save new task
                        SaveData("later");

                        //index++;

                    }

                }
                else
                {

                    Warning(4);

                }

            }
            else
            {

                Warning(5);

            }

        }
        else
        {

            Warning(6);

        }



    }
    // save the variables on the device as a "cookie" (the cookie is know as a playerpref)
    public void SaveData(string page)
    {
        string _soonIndex = "";
        string _laterIndex = "";

        // check which class is selected on start page
        for (int i = 0; i < PlayerPrefs.GetInt("cIndex"); i++)
        {
            string __className = PlayerPrefs.GetString("c" + (i + 1));
            string _className = __className.Remove(__className.IndexOf(","));
            string _classIndex = __className.Substring(__className.IndexOf(",") + 1);
            if (_className == classSoon.options[classSoon.value].text)
            {

                _soonIndex = _classIndex;
                Debug.Log("the index is" + _soonIndex);

            }

        }

        // check which class is selected on later page
        for (int i = 0; i < PlayerPrefs.GetInt("cIndex"); i++)
        {
            string __className = PlayerPrefs.GetString("c" + (i + 1));
            string _className = __className.Remove(__className.IndexOf(","));
            string _classIndex = __className.Substring(__className.IndexOf(",") + 1);
            if (_className == classLater.options[classLater.value].text)
            {

                _laterIndex = _classIndex;

            }

        }
        // turn all dates to 2 digits. ex. 1 becomes 01, 5 becomes 05 etc.
        string _ddSoon;
        string _mmSoon;
        string _ddLater;
        string _mmLater;
        if (ddSoon.text.Length != 2) { _ddSoon = "0" + ddSoon.text; } else { _ddSoon = ddSoon.text; }
        if (mmSoon.text.Length != 2) { _mmSoon = "0" + mmSoon.text; } else { _mmSoon = mmSoon.text; }
        if (ddLater.text.Length != 2) { _ddLater = "0" + ddLater.text; } else { _ddLater = ddLater.text; }
        if (mmLater.text.Length != 2) { _mmLater = "0" + mmLater.text; } else { _mmLater = mmLater.text; }

        // save the info according to the selections that are on the soon page
        if (page == "soon")
        {

            string position = setUrgency(_ddSoon + "/" + _mmSoon + "/" + yyyySoon.text);
            PlayerPrefs.SetString("" + (index + 1), NameSoon.text + "," + _ddSoon + "/" + _mmSoon + "/" + yyyySoon.text + "," + (index + 1) + "," + position + "," + classSoon.options[classSoon.value].text + "," + _soonIndex);

            index++;

            PlayerPrefs.SetInt("index", index);
            int temp = PlayerPrefs.GetInt("NumTasks");
            PlayerPrefs.SetInt("NumTasks", temp + 1);


        }
        // save info according to the selections on the later page
        else if (page == "later")
        {

            string position = setUrgency(_ddLater + "/" + _mmLater + "/" + yyyyLater.text);
            PlayerPrefs.SetString("" + (index + 1), NameLater.text + "," + _ddLater + "/" + _mmLater + "/" + yyyyLater.text + "," + (index + 1) + "," + position + "," + classLater.options[classLater.value].text + "," + _laterIndex);

            index++;

            PlayerPrefs.SetInt("index", index);
            int temp = PlayerPrefs.GetInt("NumTasks");
            PlayerPrefs.SetInt("NumTasks", temp + 1);


        }


    }

    // check how soon the task is due through the date
    string setUrgency(string date)
    {

        string returnThis = "";
        int day = System.Convert.ToInt32(date.Remove(date.IndexOf("/")));
        string _noDay = date.Substring(date.IndexOf("/") + 1);
        int month = System.Convert.ToInt32(_noDay.Remove(_noDay.IndexOf("/")));
        int year = System.Convert.ToInt32(_noDay.Substring(_noDay.IndexOf("/") + 1));


        string __year = DateTime.Now.ToString("yyyy");
        string __month = DateTime.Now.ToString("MM");
        string __day = DateTime.Now.ToString("dd");

        int _year = System.Convert.ToInt32(__year);
        int _month = System.Convert.ToInt32(__month);
        int _day = System.Convert.ToInt32(__day);


        if (_year > year) { returnThis = "Done"; }
        else if (_year == year)
        {

            if (_month > month) { returnThis = "Done"; }
            else if (_month == month)
            {

                if (_day > day) { returnThis = "Done"; }
                else if (_day == day)
                {

                    returnThis = "Soon";


                }
                else if (day - _day <= 14)
                {

                    returnThis = "Soon";


                }
                else { returnThis = "Later"; }

            }
            if (_month < month)
            {

                returnThis = "Later";


            }

        }
        else if (_year < year)
        {

            if ((_day == 31 && day <= 14) ||
                (_day == 30 && day <= 13) ||
                (_day == 29 && day <= 12) ||
                (_day == 28 && day <= 11) ||
                (_day == 27 && day <= 10) ||
                (_day == 26 && day <= 9) ||
                (_day == 25 && day <= 8) ||
                (_day == 24 && day <= 7) ||
                (_day == 23 && day <= 6) ||
                (_day == 22 && day <= 5) ||
                (_day == 21 && day <= 4) ||
                (_day == 20 && day <= 3) ||
                (_day == 19 && day <= 2) ||
                (_day == 18 && day <= 1))
            {

                returnThis = "Soon";


            }
            else { returnThis = "Later"; }

        }

        return returnThis;

    }

    // giva a warning if the field is empty or incomplete
    void Warning(int option)
    {
        if (option == 1) { Debug.Log("add something plz thank you 1"); }
        else if (option == 2) { Debug.Log("add something plz thank you 2"); }
        else if (option == 3) { Debug.Log("add something plz thank you 3"); }
        else if (option == 4) { Debug.Log("add something plz thank you 4"); }
        else if (option == 5) { Debug.Log("add something plz thank you 5"); }
        else if (option == 6) { Debug.Log("add something plz thank you 1"); }


    }

}