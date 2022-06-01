using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   
    public GameObject fireTower;
    public GameObject waterTower;
    public GameObject fireSprite, waterSprite;
    
    Buildmanager buildManager;
    public static int ranNum;
    void Start()
    {
        buildManager = Buildmanager.instance;   
    }
    public void SelectRandomTurret()
    {
        Debug.Log("Purchased");
        if (PlayerStat.Money < 100)
        {
            Debug.Log("Not enough money to build that");
            buildManager.NotEnoghMoneyPOPUP();
            //Debug.Log(HasMoney);
            return;
        }
        PlayerStat.Money -= 100;
        RandomTurret();
        
    }

    public void RandomTurret()
    {
        ranNum = Random.Range(0, 10);
        if (ranNum <= 5)
        {
            buildManager.SelectTurretToBuild(fireTower);
            fireSprite.SetActive(true);
            waterSprite.SetActive(false);
            return;
        }
        else
        {
            buildManager.SelectTurretToBuild(waterTower);
            waterSprite.SetActive(true);
            fireSprite.SetActive(false);
            return;
        }
        
    }
    public void CloseSprite()
    {
        fireSprite.SetActive(false);
        waterSprite.SetActive(false);
    }

    public void MergedTower()
    {
        buildManager.SelectTurretToBuild(waterTower);
        return;
    }

    private void Update()
    {
        if (buildManager.CloseSprite)
        {
            CloseSprite();
        }
        else
        {

        }
    }

}
