using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cam;
    private Transform lookAt;

    // Update is called once per frame

    private void Start()
    {
       
    }
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
