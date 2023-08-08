using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchElem : MonoBehaviour
{
    Buildmanager buildmanager;
    public GameObject researchUIElem;
    void Start()
    {
        buildmanager = Buildmanager.instance;
        researchUIElem = buildmanager.ReseachElemUI;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //researchUI.SetActive(true);
        researchUIElem.transform.position = new Vector3(960, 540, 0);
    }
}
