using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject This;
    public void destroyThis()
    {

        PlayerPrefs.DeleteKey(This.name);
        Destroy(This);
        Debug.Log("done");

    }

}
