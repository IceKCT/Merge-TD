using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOption : MonoBehaviour
{
    public GameObject closeUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitUI()
    {
        closeUI.SetActive(false);
    }
}
