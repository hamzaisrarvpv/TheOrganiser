using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject This;

    public void destroyThis()
    {

        // when run, this method destroys the object it is attached to
        PlayerPrefs.DeleteKey(This.name);
        Destroy(This);
        Debug.Log("done");
        int temp = PlayerPrefs.GetInt("NumTasks");
        PlayerPrefs.SetInt("NumTasks", temp - 1);
        

    }
   

}
