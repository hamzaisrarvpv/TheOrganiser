using UnityEngine;
using UnityEngine.UI;

public class ChangeTrahIcon : MonoBehaviour
{
    bool switchOn = false;
    public Sprite offImage;
    public Sprite onImage;

    void Update()
    {
        //If the toggle is off (default), the image of the trashcan should be closed.
        if (!switchOn)
        {
            gameObject.GetComponent<Image>().sprite = offImage;
           



        }
        //The the toggle is on, then the image of the trashcan opens up to indicate that the user is in delete mode
        if (switchOn)
        {
            gameObject.GetComponent<Image>().sprite = onImage;

        }
    }
    public void changeBool()
    {

        switchOn = !switchOn;

    }
}
