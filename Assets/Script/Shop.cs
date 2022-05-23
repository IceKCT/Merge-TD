using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool isClick = true;
    public GameObject fireTower;
    public GameObject waterTower;
    Buildmanager buildManager;
    public static int ranNum;
    void Start()
    {
        buildManager = Buildmanager.instance;   
    }
    public void SelectRandomTurret()
    {
        Debug.Log("Purchased");
        
        if(isClick == true)
        {
            RandomTurret();
        }
        else
        {
            isClick = true;
        }
        
        Debug.Log(ranNum);
    }

    public void RandomTurret()
    {
        ranNum = Random.Range(0, 10);
        if (ranNum <= 5)
        {
            buildManager.SelectTurretToBuild(fireTower);
            return;
        }
        else
        {
            buildManager.SelectTurretToBuild(waterTower);
            return;

        }
        isClick = false;
    }

    public void MergedTower()
    {
        buildManager.SelectTurretToBuild(waterTower);
        return;
    }

   
}
