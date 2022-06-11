using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance; 
    public GameObject fireTower;
    public GameObject waterTower;
    public GameObject fireSprite, waterSprite;
    
    Buildmanager buildManager;
    public static int ranNum;
    public bool towerInhand = false;

    public int UpgradePrice;
    private int upgradeLevel = 0;
    private int upgradeLevelMoney = 0;

    public Text UpgradePriceText, UpgradePriceTextTwo;
    public Text LevelTextATK, LevelTextMoney;
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

    public void UpgradeATK()
    {
        if(PlayerStat.Money >= UpgradePrice)
        {
            if (upgradeLevel < 3)
            {
                if (upgradeLevel == 0)
                {
                    PlayerStat.Money -= UpgradePrice;
                    Turret.HeroFirerate(0f, 10f,5);
                    UpgradePrice += 500;
                }
                if (upgradeLevel == 1)
                {
                    PlayerStat.Money -= UpgradePrice;
                    Turret.HeroFirerate(0f, 30f, 10);
                    
                    UpgradePrice += 500;
                }
                if (upgradeLevel == 2)
                {
                    PlayerStat.Money -= UpgradePrice;
                    Turret.HeroFirerate(0f, 60f, 15);
                   
                    UpgradePrice += 500;
                }
                upgradeLevel++;
                UpgradePriceText.text = UpgradePrice.ToString() + " $";
                if(upgradeLevelMoney < 3)
                {
                    UpgradePriceTextTwo.text = UpgradePrice.ToString() + " $";
                }
               
                LevelTextATK.text = "Level : " + upgradeLevel.ToString();
                if (upgradeLevel == 3)
                {
                    UpgradePriceText.text = " ";
                    LevelTextATK.text = "Level : MAX";
                }
                
            }
            else
            {

            }
        }
        else
        {
            buildManager.NotEnoghMoneyPOPUP();
        }
    }
    public void UpgradeMoney()
    {
        if (PlayerStat.Money >= UpgradePrice)
        {
            if (upgradeLevelMoney < 3)
            {
                if (upgradeLevelMoney == 0)
                {
                    PlayerStat.Money -= UpgradePrice;
                    PlayerStat.GetBonusMoney(1);

                    UpgradePrice += 500;
                }
                if (upgradeLevelMoney == 1)
                {
                    PlayerStat.Money -= UpgradePrice;

                    PlayerStat.GetBonusMoney(2);
                    UpgradePrice += 500;
                }
                if (upgradeLevelMoney == 2)
                {
                    PlayerStat.Money -= UpgradePrice;
                    PlayerStat.GetBonusMoney(3);
                    UpgradePrice += 500;
                }
                upgradeLevelMoney++;
                
                UpgradePriceTextTwo.text = UpgradePrice.ToString() + " $";
                if (upgradeLevel < 3)
                {
                    UpgradePriceText.text = UpgradePrice.ToString() + " $";
                }
                LevelTextMoney.text = "Level : " + upgradeLevelMoney.ToString();
                if (upgradeLevelMoney == 3)
                {
                    UpgradePriceTextTwo.text = " ";
                    LevelTextMoney.text = "Level : MAX";
                }
            }
            else
            {

            }
        }
        else
        {
            buildManager.NotEnoghMoneyPOPUP();
        }
    }

}
