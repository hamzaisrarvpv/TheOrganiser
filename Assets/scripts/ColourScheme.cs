using UnityEngine;
using UnityEngine.UI;

public class ColourScheme : MonoBehaviour
{

    public Material mtrl;
    

    void Update()
    {
        // constantly check if in dark or light mode
        if (PlayerPrefs.GetInt("colourInt") == 1)
        {
            EnableDarkMode();

        }
        else if (PlayerPrefs.GetInt("colourInt") == 0)
        {
            EnableLightMode();
        }

    }

    public void EnableDarkMode()
    {
        // changes the viewport's color to dark mode
        PlayerPrefs.SetInt("colourInt", 1);

        Color c = new Color32(0, 0, 0, 1);
        Color d = new Color32(189, 195, 199, 1);
        mtrl.SetColor("_EmissionColor", c);
    }


    public void EnableLightMode()
    {

        // changes the viewport's color to light mode
        PlayerPrefs.SetInt("colourInt", 0);

        Color c = new Color32(189, 195, 199, 1);
        Color d = new Color32(242, 241, 239, 1);
        mtrl.SetColor("_EmissionColor", c);
    }
}




       





