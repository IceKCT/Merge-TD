using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Live : MonoBehaviour
{
    public Text live;
    

    // Update is called once per frame
    void Update()
    {
        live.text = PlayerStat.live.ToString();
    }
}
