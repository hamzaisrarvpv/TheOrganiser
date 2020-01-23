using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class openClass : MonoBehaviour
{

    public GameObject parent;
    public GameObject prefab;
    public GameObject This;

    private int height = 0;
    private readonly int width = 840;

    int index;

    private void Start()
    {

        parent = GameObject.FindWithTag("Content");

    }
    public void openClasses()
    {

        SceneChangeMod.classOpen = true;

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject temp = parent.transform.GetChild(i).gameObject;
            Destroy(temp);

        }
        for (int i = 0; i < PlayerPrefs.GetInt("index") + 1; i++)
        {

            if (PlayerPrefs.GetString("" + (i + 1)) != "")
            {

                // recall tasks
                string __name = PlayerPrefs.GetString("" + (i + 1));

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


                int day = System.Convert.ToInt32(_date.Remove(_date.IndexOf("/")));
                string _noDay = _date.Substring(_date.IndexOf("/") + 1);
                int month = System.Convert.ToInt32(_noDay.Remove(_noDay.IndexOf("/")));
                int year = System.Convert.ToInt32(_noDay.Substring(_noDay.IndexOf("/") + 1));


                if (This.name == _index)
                {
                    Debug.Log("enter if");
                    // expand content area
                    height = height + 147;
                    parent.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

                    // create task
                    GameObject taskClone = Instantiate(prefab, parent.transform);


                    // change name of instantiated GameObject
                    taskClone.gameObject.name = _title;
                    taskClone.GetComponentInChildren<TMP_Text>().text = _name + ", " + day + "/" + month;


                }




            }

        }

    }


}
