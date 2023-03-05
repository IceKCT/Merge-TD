using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buildprogress : MonoBehaviour
{
    Buildmanager buildmanager;
    public Slider slider;
    public GameObject slideOBJ, dciPanel,alert;
    public GameObject tower;
    public float buildProgress;
    public float maxTime;
    public bool onProgress;
    bool progressing = false;
    ResearchUI research;
    PlayerStat stat;

    public float price;
    void Start()
    {
        stat = PlayerStat.instance;
        research = GetComponent<ResearchUI>();
        buildmanager = Buildmanager.instance;
        buildProgress = maxTime;
        
    }

    public void OnBuildTower()
    {
        if (onProgress == false && progressing == false)
        {
            dciPanel.SetActive(true);
            
        }
        else
        {
            alert.SetActive(false);
            onProgress = false;
            progressing = false;
            buildmanager.SelectTurretToBuild(tower);
        }
       
    }

    public void OnYesButt()
    {
        if(buildProgress > 0)
        {
            InvokeRepeating("CountdownStart", 0f, 1f);
        }
        stat.getMoney(-price);
        dciPanel.SetActive(false);
    }
    public void OnNoButt()
    {
        dciPanel.SetActive(false);
    }

    public void CountdownStart()
    {
            progressing = true;
            slideOBJ.SetActive(true);
            buildProgress -= 1;
            Debug.Log("Buildprogress = " + buildProgress);
            slider.value = buildProgress / maxTime;
   
       
        if (buildProgress <= 0)
        {
            onProgress = true;
            slideOBJ.SetActive(false);
            CancelInvoke();
            alert.SetActive(true);
            buildProgress = maxTime;
        }

    }

 
}
