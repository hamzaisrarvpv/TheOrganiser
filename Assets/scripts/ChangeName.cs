using TMPro;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    public TMP_InputField Name;
    public void ChangeTheName()
    {
        // change the user's name, which shows on the splash screen
        if (Name.text != null)
        {
            // if a name already exists
            PlayerPrefs.SetString("name", Name.text);
            AndroidNative.showMessage("Alert", "Your name has been changed", "Ok");
        }
        else
        {
            // if no name has been set up
            PlayerPrefs.SetString("name", "Welcome User");

        }
    }
}
