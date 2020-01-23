using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassManager : MonoBehaviour
{
    

    public TMP_InputField Name;
    public GameObject prefab;
    public GameObject parent;


    private int height = 0;
    private readonly int width = 840;
    public int cIndex;


    void Start()
    {

        cIndex = PlayerPrefs.GetInt("cIndex");

        for (int i = 0; i < cIndex; i++)
        {

            if (PlayerPrefs.GetString("c" + (i + 1)) != "")
            {
                
                string __name = PlayerPrefs.GetString("c" + (i + 1));

                string _name = __name.Remove(__name.IndexOf(","));
                string _title = __name.Substring(__name.IndexOf(",") + 1);
                Debug.Log(_title);

                // expand content area
                height = height + 147;
                parent.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

                // create task
                GameObject taskClone = Instantiate(prefab, parent.transform);

                // change name of instantiated GameObject
                taskClone.gameObject.name = _title;
                taskClone.GetComponentInChildren<TMP_Text>().text = _name;

            }

        }
        



    }
    public void addClass()
    {

        // expand content area
        height = height + 147;
        parent.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // create task
        GameObject taskClone = Instantiate(prefab, parent.transform);
        cIndex = PlayerPrefs.GetInt("cIndex");


        // change name of instantiated GameObject
        taskClone.gameObject.name = "" + (cIndex + 1);
        taskClone.GetComponentInChildren<TMP_Text>().text = Name.text + " Class";

        // save new task
        SaveData();

        //index++;

    }
    void SaveData()
    {
        
        PlayerPrefs.SetString("c" + (cIndex + 1), Name.text + " Class" + "," + (cIndex + 1));
        cIndex++;
        PlayerPrefs.SetInt("cIndex", cIndex);

    }
}
