using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropdownSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
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
        sizeOfContent = transform.childCount * 150;
        posOfContent = transform.localPosition.y;

    }
    void Update()
    {

        sizeOfContent = transform.childCount * 150;
        posOfContent = transform.localPosition.y;
        //Debug.Log(Input.mousePosition);

        //Debug.Log(pressLocation);

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
                if (newLocation.y <= sizeOfContent - 750)
                {

                    Debug.Log("swiped bottom-up, success");

                }
                else
                {
                    if (sizeOfContent / 150 > 4)
                    {

                        newLocation.y = sizeOfContent - 750;
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