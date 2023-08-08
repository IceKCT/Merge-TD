using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenu : MonoBehaviour
{
    public GameObject Card, elementMenu;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void TabNormal()
    {
        Card.SetActive(true);
        elementMenu.SetActive(false);
    }

    public void TabElement()
    {
        elementMenu.SetActive(true);
        Card.SetActive(false);
    }
}
