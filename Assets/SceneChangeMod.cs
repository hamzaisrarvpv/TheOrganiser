using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMod : MonoBehaviour
{
    public static bool classOpen = false;

    public void NextScene(string scene)
    {
        // checks if a class is open in the class management scene. 
        // if one is open, then all we want is to close it
        // if not, then we want to return to settings menu
        // this is used to give multiple functionality to the same button
        if (classOpen)
        {
            // reload scene - aka close class
            SceneManager.LoadScene("ManageClasses");
            classOpen = false;

        }
        else
        {
            // load setings scene
            SceneManager.LoadScene(scene);


        }
        

    }

}
