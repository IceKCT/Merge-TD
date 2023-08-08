using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Dropzone
{
    
    void Update()
    {
        if(transform.childCount > 0)
        {
            transform.DetachChildren();
        }
    }
}
