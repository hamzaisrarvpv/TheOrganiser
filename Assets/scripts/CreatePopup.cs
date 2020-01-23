using UnityEngine;

public class CreatePopup : MonoBehaviour
{
    public static void Popup(string title, string message, string yes, string no, string blah)
    {
        // Method that simplify creating a Popup
        AndroidDialog.Create(title, message, yes, no);
        PlayerPrefs.SetString("choice", blah);

    }

    public static void PressedYes()
    {

        // whatever happens when the user answers "yes" to the popup

    }
}
