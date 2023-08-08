using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public GameObject frameTowerLv1;
    public GameObject fireTower;
    public GameObject waterTower;
    public GameObject fireSprite, waterSprite;
    
    Buildmanager buildManager;
    public static int ranNum;
    public bool towerInhand = false;

  

    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;

    }
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
        towerInhand = true;
        RandomTurret();
        
    }

    public void RandomTurret()
    {
        /*ranNum = Random.Range(0, 10);
        if (ranNum <= 5)
        {
            buildManager.SelectTurretToBuild(frameTowerLv1);
            fireSprite.SetActive(true);
            waterSprite.SetActive(false);
            return;
        }
        else
        {
            buildManager.SelectTurretToBuild(frameTowerLv1);
            waterSprite.SetActive(true);
            fireSprite.SetActive(false);
            return;
        }
        */
    }
    public void CloseSprite()
    {
        fireSprite.SetActive(false);
        waterSprite.SetActive(false);
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
