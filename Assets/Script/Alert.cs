using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    public Text alert;
    public void setWord(string text)
    {
        alert.text = text;
    }
    

}
