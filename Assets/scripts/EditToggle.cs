using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditToggle : MonoBehaviour
{

    public GameObject Content;
    bool active = false;
    public void ToggleEdit()
    {
        // this script is used fo rthe trash bin toggle - allows tasks to be clickable
        // when tasks are clicked, they are deleted.
        for (int i = 0; i < Content.transform.childCount; i++)
        {

            Content.transform.GetChild(i).GetComponent<Button>().interactable = !active;

        }

        active = !active;

    }

}
