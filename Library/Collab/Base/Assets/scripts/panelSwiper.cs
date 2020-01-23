using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class panelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float  easing = 0.2f;
    public int sizeOfContent;
    public float posOfContent;
    public float sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {

        panelLocation = transform.localPosition;
        sizeOfContent = (PlayerPrefs.GetInt("NumTasks") * 147);
        posOfContent = transform.localPosition.y;

    }
    void Update()
    {

        sizeOfContent = (PlayerPrefs.GetInt("NumTasks") * 147);
        posOfContent = transform.localPosition.y;

    }
    public void OnDrag(PointerEventData data)
    {

        float difference = data.pressPosition.y - data.position.y;
        transform.localPosition = panelLocation - new Vector3(0, difference, 0);

    }
    public void OnEndDrag(PointerEventData data)
    {
        float direction = (data.pressPosition.y - data.position.y) / Screen.height;

        //if (Mathf.Abs(percentage) >= percentThreshold)
        //{

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

            newLocation.y += Vector2.Distance(data.pressPosition, data.position);
            if (newLocation.y <= sizeOfContent - 1470)
            {

                Debug.Log("swiped bottom-up, success");

            }
            else
            {

                newLocation.y = sizeOfContent - 1470;
                Debug.Log("swiped bottom-up, fail");

            }
            

        }
        /*if (direction > 0 && newLocation.y + new Vector3(0, -Vector2.Distance(data.pressPosition, data.position), 0).y >= 0)
        {

            newLocation.y += new Vector3(0, -Vector2.Distance(data.pressPosition, data.position), 0).y;
            Debug.Log("swiped top-down, success");

        }
        // if swiping down will cause wrong behaviour
        else if (direction > 0 && newLocation.y + new Vector3(0, -Vector2.Distance(data.pressPosition, data.position), 0).y < 0)
        {

            newLocation.y = 0;
            Debug.Log("swiped top-down, fail");

        }
        // if swiping up will cause correct behaviour
        else if (direction < 0 && newLocation.y + new Vector3(0, Vector2.Distance(data.pressPosition, data.position), 0).y <= sizeOfContent)
        {

            newLocation.y += new Vector3(0, Vector2.Distance(data.pressPosition, data.position), 0).y;
            Debug.Log("swiped bottom-up, success");

        }
        // if swiping up will cause wrong behaviour
        else if (direction < 0 && newLocation.y + new Vector3(0, Vector2.Distance(data.pressPosition, data.position), 0).y > sizeOfContent)
        {

            newLocation.y = sizeOfContent;
            Debug.Log("swiped bottom-up, fail");

        }*/

        StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
        panelLocation = newLocation;
        //}
        //else
        //{

        // StartCoroutine(SmoothMove(transform.position, panelLocation, easing));

        // }


    }
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

}