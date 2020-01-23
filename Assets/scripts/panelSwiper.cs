using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class panelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float easing = 0.2f;
    public int sizeOfContent;
    public float posOfContent;
    public float sensitivity = 2f;
    private bool isScrolling;
    private float percentage = 0.2f;

    public taskManager taskManager;


    

    // Start is called before the first frame update
    void Start()
    {

        panelLocation = transform.localPosition;
        sizeOfContent = transform.childCount * 147;
        posOfContent = transform.localPosition.y;

    }
    void Update()
    {

        sizeOfContent = transform.childCount * 147;
        posOfContent = transform.localPosition.y;
        

    }
    public void OnDrag(PointerEventData data)
    {
        
        if (Mathf.Abs(data.pressPosition.x - data.position.x) < Mathf.Abs(data.pressPosition.y - data.position.y))
        {
            
            // up-down
            isScrolling = true;
            float difference = data.pressPosition.y - data.position.y;
            transform.localPosition = panelLocation - new Vector3(0, difference, 0);

        }
        else if (Mathf.Abs(data.pressPosition.x - data.position.x) > Mathf.Abs(data.pressPosition.y - data.position.y) && SceneManager.GetActiveScene().name != "ManageClasses")
        {
            
            // right-left
            isScrolling = false;

        }

    }
    public void OnEndDrag(PointerEventData data)
    {
        float direction;
        if (isScrolling)
        {

            direction = (data.pressPosition.y - data.position.y) / Screen.height;

            Vector3 newLocation = panelLocation;

            if (direction > 0)
            {

                newLocation.y += -Vector2.Distance(data.pressPosition, data.position);
                if (newLocation.y >= 0)
                {

                    Debug.Log("swiped top-down, success");

                }
                else
                {

                    newLocation.y = 0;
                    Debug.Log("swiped top-down, fail");

                }


            }
            else if (direction < 0)
            {
                Debug.Log("we got here");
                newLocation.y += Vector2.Distance(data.pressPosition, data.position);
                if (newLocation.y <= sizeOfContent - 1470)
                {

                    Debug.Log("swiped bottom-up, success");

                }
                else
                {
                    if (sizeOfContent / 147 > 10)
                    {

                        newLocation.y = sizeOfContent - 1470;
                        Debug.Log("swiped bottom-up, fail");

                    }
                    else
                    {

                        newLocation.y = 0;

                    }

                }


            }

            StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
            panelLocation = newLocation;


        }
        else if (!isScrolling)
        {

            Vector3 pressLocation = Camera.main.ScreenToWorldPoint(data.pressPosition);

            for (int i = 0; i < transform.childCount; i++)
            {

                if (transform.GetChild(i).position.y + 73.5 > pressLocation.y && transform.GetChild(i).position.y - 73.5 < pressLocation.y)
                {
                    float difference = data.pressPosition.x - data.position.x;
                    if (difference > 0)
                    {

                        // were moving right to left
                        Debug.Log("positive");
                        if (returnPosition(PlayerPrefs.GetString(transform.GetChild(i).name)) == "Soon")
                        {
                            Debug.Log("positive");
                            string originalName = transform.GetChild(i).name;
                            string originalText = returnName(PlayerPrefs.GetString(transform.GetChild(i).name)) + ", " + returnDate(PlayerPrefs.GetString(transform.GetChild(i).name));

                            // delete from soon
                            Destroy(transform.GetChild(i).gameObject);

                            // recreate in later

                            // expand content area
                            taskManager.heightLater = taskManager.heightLater + 147;
                            taskManager.parentLater.GetComponent<RectTransform>().sizeDelta = new Vector2(taskManager.width, taskManager.heightLater);

                            // create task
                            GameObject taskClone = Instantiate(taskManager.taskP, taskManager.parentLater.transform);

                            // change name of instantiated GameObject
                            taskClone.gameObject.name = originalName;
                            taskClone.GetComponentInChildren<TMP_Text>().text = originalText;

                            // set position to later
                            PlayerPrefs.SetString(transform.GetChild(i).name, changePosition(PlayerPrefs.GetString(transform.GetChild(i ).name), "Later"));



                        }
                        else if (returnPosition(PlayerPrefs.GetString(transform.GetChild(i).name)) == "Done")
                        {

                            string originalName = transform.GetChild(i).name;
                            string originalText = returnName(PlayerPrefs.GetString(transform.GetChild(i).name)) + ", " + returnDate(PlayerPrefs.GetString(transform.GetChild(i).name));

                            // delete from done
                            Destroy(transform.GetChild(i).gameObject);

                            // recreate in soon

                            // expand content area
                            taskManager.heightSoon = taskManager.heightSoon + 147;
                            taskManager.parentSoon.GetComponent<RectTransform>().sizeDelta = new Vector2(taskManager.width, taskManager.heightSoon);

                            // create task
                            GameObject taskClone = Instantiate(taskManager.taskP, taskManager.parentSoon.transform);

                            // change name of instantiated GameObject
                            taskClone.gameObject.name = originalName;
                            taskClone.GetComponentInChildren<TMP_Text>().text = originalText;

                            // set position to soon
                            PlayerPrefs.SetString(transform.GetChild(i).name, changePosition(PlayerPrefs.GetString(transform.GetChild(i ).name), "Soon"));

                        }

                    }
                    else if (difference < 0)
                    {

                        // were moving left to right
                        Debug.Log("negative");
                        if (returnPosition(PlayerPrefs.GetString(transform.GetChild(i).name)) == "Later")
                        {

                            string originalName = transform.GetChild(i).name;
                            string originalText = returnName(PlayerPrefs.GetString(transform.GetChild(i).name)) + ", " + returnDate(PlayerPrefs.GetString(transform.GetChild(i ).name));

                            // delete from later
                            Destroy(transform.GetChild(i).gameObject);

                            // recreate in soon

                            // expand content area
                            taskManager.heightSoon = taskManager.heightSoon + 147;
                            taskManager.parentSoon.GetComponent<RectTransform>().sizeDelta = new Vector2(taskManager.width, taskManager.heightSoon);

                            // create task
                            GameObject taskClone = Instantiate(taskManager.taskP, taskManager.parentSoon.transform);

                            // change name of instantiated GameObject
                            taskClone.gameObject.name = originalName;
                            taskClone.GetComponentInChildren<TMP_Text>().text = originalText;

                            // set position to soon
                            PlayerPrefs.SetString(transform.GetChild(i).name, changePosition(PlayerPrefs.GetString(transform.GetChild(i).name), "Soon"));
                            
                            

                        }
                        else if (returnPosition(PlayerPrefs.GetString(transform.GetChild(i ).name)) == "Soon")
                        {

                            string originalName = transform.GetChild(i).name;
                            string originalText = returnName(PlayerPrefs.GetString(transform.GetChild(i ).name)) + ", " + returnDate(PlayerPrefs.GetString(transform.GetChild(i).name));

                            // delete from soon
                            Destroy(transform.GetChild(i).gameObject);

                            // recreate in done

                            // expand content area
                            taskManager.heightDone = taskManager.heightDone + 147;
                            taskManager.parentDone.GetComponent<RectTransform>().sizeDelta = new Vector2(taskManager.width, taskManager.heightDone);

                            // create task
                            GameObject taskClone = Instantiate(taskManager.taskP, taskManager.parentDone.transform);

                            // change name of instantiated GameObject
                            taskClone.gameObject.name = originalName;
                            taskClone.GetComponentInChildren<TMP_Text>().text = originalText;

                            // set position to done
                            PlayerPrefs.SetString(transform.GetChild(i).name, changePosition(PlayerPrefs.GetString(transform.GetChild(i ).name), "Done"));

                        }

                    }
                    

                }


            }

        }




    }
    
    // method to smooth movement when scrolling
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {

            t += Time.deltaTime / seconds;
            transform.localPosition = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;

        }
    }

    // 
    public static string returnPosition(string __name)
    {


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

        return _position;

    }
    public string changePosition(string __name, string actualPosition)
    {

        
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

        return _name + "," + _date + "," + _title + "," + actualPosition + "," + _class + "," + _index;

    }
    public string returnName(string __name)
    {


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

        return _name;

    }
    public string returnDate(string __name)
    {


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

        return day + "/" + month;

    }


}