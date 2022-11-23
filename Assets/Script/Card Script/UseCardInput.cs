using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardInput : Dropzone
{
    public static UseCardInput instance;
    Buildmanager buildManager;
    
    [HideInInspector]public bool research;
    
    public GameObject self;
    [Header("Building")]
    public GameObject frameTowerLv1,reseach;
  

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;

    }
    private void Start()
    {
        buildManager = Buildmanager.instance;
    }
    private void Update()
    {
          if(transform.childCount > 0)
        {
           
            CheckWhatcarditis();

        }
        else
        {
            
        }
    }

    public void CheckWhatcarditis()
    {
        Debug.Log("Have Child");
        transform.position = new Vector3(-200, 0, 0);
        if (self.transform.Find("Dummycard"))
        {
            buildManager.SelectTurretToBuild(frameTowerLv1);
            Debug.Log("Get Tower");
            
            
        }else if(self.transform.Find("Research card"))
        {
            buildManager.SelectTurretToBuild(reseach);
        }
        self.transform.DetachChildren();
       
    }
}
