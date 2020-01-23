using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class swipeUp : MonoBehaviour
{

    private bool isScrolling;
    private float percentage = 0.2f;


    // Start is called before the first frame update
    private void Update()
    {
        Debug.Log("we are ");
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("we are dragging");
        if (Mathf.Abs(data.pressPosition.x - data.position.x) < Mathf.Abs(data.pressPosition.y - data.position.y))
        {
            Debug.Log("we are scrolling");
            // up-down
            isScrolling = true;

        }

    }
    public void OnEndDrag(PointerEventData data)
    {
        float direction;
        if (isScrolling)
        {

            direction = (data.pressPosition.y - data.position.y) / Screen.height;


            if (direction < 0)
            {

                SceneManager.LoadScene("Main");

            }

        }

    }
  
}
