using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchUI : MonoBehaviour
{
    public Vector3 center;
    public GameObject researchUI;
    void Start()
    {
        center = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitUI()
    {
        researchUI.transform.position = new Vector3(-960, 540, 0);
    }

    public void movePos()
    {
        researchUI.transform.position = new Vector3(-960, 540, 0);
    }
}
