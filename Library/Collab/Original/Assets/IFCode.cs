using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class IFCode : MonoBehaviour
{

    public static string number;
    public static int percentage;
    public InputField input;

    public void setNumber()
    {

        number = input.text;

        int.TryParse(number, out number)
        
    }

    public string getNumber()
    {
        return number;
    }

    public void Setpercentage(int input)
    {
        percentage = input;


        Debug.Log(percentage);

    }

    public int Getpercentage()
    {
        return percentage;
    }

   


       
    }



    

    



