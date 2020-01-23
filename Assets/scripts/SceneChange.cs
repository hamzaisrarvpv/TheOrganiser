using UnityEngine;
using UnityEngine.SceneManagement;

public class  SceneChange: MonoBehaviour
{
    
    public void NextScene(string scene)
    {
        // loads the specified scene by name
        SceneManager.LoadScene(scene);

    }

    
}