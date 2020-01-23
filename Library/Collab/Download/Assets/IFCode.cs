using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IFCode : MonoBehaviour
{
    public static string Total;
    public static int Per = 0;
    public InputField IF;

    public void setTotal()
    {

        Total = IF.text;
        Debug.Log(Total);

    }
    public static string getTotal()
    {

        return Total;

    }
    public static void setPer(int y)
    {

        Per = y;

    }
    public static int getPer()
    {

        return Per;

    }
    /*public static int calcPer()
    {

        int per = Total * (Per / 100);
        return per;

    }*/

}
