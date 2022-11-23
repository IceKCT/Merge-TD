using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : MonoBehaviour
{
    Buildmanager buildmanager;
    public GameObject researchUI;
    void Start()
    {
        buildmanager = Buildmanager.instance;
        researchUI = buildmanager.ResearchUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //researchUI.SetActive(true);
        researchUI.transform.position = new Vector3(960, 540, 0);
    }
}
