using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resercher : MonoBehaviour
{
    public static Resercher instance;
    [Header("Normal Tower")]
    public int currentNormalLevel = 1;
    public float priceNormalUpgrade;
    public Text normalLevel, normalPrice,levelNormalBuy;


    [Header("Burst Tower")]
    public int currentBurstLevel = 1;
    public float priceBurstUpgrade;
    public Text burstLevel, burstPrice, levelBurstBuy;

    [Header("AOE Tower")]
    public int currentAOELevel = 1;
    public float priceAOEUpgrade;
    public Text aoeLevel, aoePrice, levelAoeBuy;

    [Header("Aura Tower")]
    public int currentAuraLevel = 1;
    public float priceAuraUpgrade;
    public Text auraLevel, auraPrice, levelAuraBuy;

    [Header("Shop")]
    public GameObject burstbuy, burstUpgrade, aoeBuy, aoeUpgrade, auraBuy, auraUpgrade;
    public int shopUpgrade;
    private int levelShop = 1;
    public Text levelTextShop, priceTextShop;
    public GameObject upgradeButton;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeNormalTower()
    {
        if(PlayerStat.Money >= priceNormalUpgrade)
        {
            if(currentNormalLevel == 1)
            {
                PlayerStat.Money -= priceNormalUpgrade;
                currentNormalLevel++;
                priceNormalUpgrade += 200;
                normalLevel.text = "Level: " +currentNormalLevel.ToString();
                normalPrice.text = priceNormalUpgrade.ToString() + " Gold";
                levelNormalBuy.text = "Level: " + currentNormalLevel.ToString(); 
            }
            else if (currentNormalLevel == 2)
            {
                PlayerStat.Money -= priceNormalUpgrade;
                currentNormalLevel++;
                priceNormalUpgrade += 200;
                normalLevel.text = "Level: " + currentNormalLevel.ToString();
                normalPrice.text = priceNormalUpgrade.ToString() + " Gold";
                levelNormalBuy.text = "Level: " + currentNormalLevel.ToString();
            }
            else if (currentNormalLevel == 3)
            {
                PlayerStat.Money -= priceNormalUpgrade;
                currentNormalLevel++;
                normalLevel.text = "Level: Max";
                normalPrice.text = "";
                levelNormalBuy.text = "Level: Max";
            }
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }
    public void UpgradeBurstTower()
    {
        if (PlayerStat.Money >= priceBurstUpgrade)
        {
            if (currentBurstLevel == 1)
            {
                PlayerStat.Money -= priceBurstUpgrade;
                currentBurstLevel++;
                priceBurstUpgrade += 200;
                burstLevel.text = "Level: " + currentBurstLevel.ToString();
                burstPrice.text = priceBurstUpgrade.ToString() +" Gold";
                levelBurstBuy.text = "Level: " + currentBurstLevel.ToString();
            }
            else if (currentBurstLevel == 2)
            {
                PlayerStat.Money -= priceBurstUpgrade;
                currentBurstLevel++;
                priceBurstUpgrade += 200;
                burstLevel.text = "Level: " + currentBurstLevel.ToString();
                burstPrice.text = priceBurstUpgrade.ToString() + " Gold";
                levelBurstBuy.text = "Level: " + currentBurstLevel.ToString();
            }
            else if (currentBurstLevel == 3)
            {
                PlayerStat.Money -= priceBurstUpgrade;
                currentBurstLevel++;
                burstLevel.text = "Level: Max";
                burstPrice.text = "";
                levelBurstBuy.text = "Level: Max";
            }
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }
    public void UpgradeAOETower()
    {
        if (PlayerStat.Money >= priceAOEUpgrade)
        {
            if (currentAOELevel == 1)
            {
                PlayerStat.Money -= priceAOEUpgrade;
                currentAOELevel++;
                priceAOEUpgrade += 200;
                aoeLevel.text = "Level: " + currentAOELevel.ToString();
                aoePrice.text = priceAOEUpgrade.ToString() + " Gold";
                levelAoeBuy.text = "Level: " + currentAOELevel.ToString();
            }
            else if (currentAOELevel == 2)
            {
                PlayerStat.Money -= priceAOEUpgrade;
                currentAOELevel++;
                priceAOEUpgrade += 200;
                aoeLevel.text = "Level: " + currentAOELevel.ToString();
                aoePrice.text = priceAOEUpgrade.ToString() + " Gold";
                levelAoeBuy.text = "Level: " + currentAOELevel.ToString();
            }
            else if (currentAOELevel == 3)
            {
                PlayerStat.Money -= priceAOEUpgrade;
                currentAOELevel++;
                aoeLevel.text = "Level: Max";
                aoePrice.text = "";
                levelAoeBuy.text = "Level: Max";
            }
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }

    public void UpgradeAuraTower()
    {
        if(PlayerStat.Money >= priceAuraUpgrade)
        {
            if (currentAuraLevel == 1)
            {
                PlayerStat.Money -= priceAuraUpgrade;
                currentAuraLevel++;
                priceAuraUpgrade += 200;
                auraLevel.text = "Level: " + currentAuraLevel.ToString();
                auraPrice.text = priceAuraUpgrade.ToString() + " Gold";
                levelAuraBuy.text = "Level: " + currentAuraLevel.ToString();
            }else if (currentAuraLevel == 2)
            {
                PlayerStat.Money -= priceAuraUpgrade;
                currentAuraLevel++;
                priceAuraUpgrade += 200;
                auraLevel.text = "Level: " + currentAuraLevel.ToString();
                auraPrice.text = priceAuraUpgrade.ToString() + " Gold";
                levelAuraBuy.text = "Level: " + currentAuraLevel.ToString();
            }else if (currentAuraLevel == 3)
            {
                PlayerStat.Money -= priceAuraUpgrade;
                currentAuraLevel++;
                priceAuraUpgrade += 200;
                auraLevel.text = "Level: Max";
                auraPrice.text = "";
                levelAuraBuy.text = "Level: Max";
            }
            

            
        }
        else
        {
            Debug.Log("can't Buy");
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }

    public void UpgradeShop()
    {
        if(PlayerStat.Money >= shopUpgrade)
        {
            if (levelShop == 1)
            {
                PlayerStat.Money -= shopUpgrade;
                levelShop++;
                shopUpgrade += 200;
                burstbuy.SetActive(true);
                burstUpgrade.SetActive(true);

                levelTextShop.text = levelShop.ToString();
                priceTextShop.text = shopUpgrade.ToString() + " Gold";
            }else if (levelShop == 2)
            {
                PlayerStat.Money -= shopUpgrade;
                levelShop++;
                shopUpgrade += 200;
                aoeBuy.SetActive(true);
                aoeUpgrade.SetActive(true);

                levelTextShop.text = levelShop.ToString();
                priceTextShop.text = shopUpgrade.ToString() + " Gold";
            }else if(levelShop == 3)
            {
                PlayerStat.Money -= shopUpgrade;
                levelShop++;
                shopUpgrade += 200;
                auraBuy.SetActive(true);
                auraUpgrade.SetActive(true);

                levelTextShop.text = "Max";
                priceTextShop.text = "";
                upgradeButton.SetActive(false);
            }
            else
            {
               
            }
        }
        else
        {
            Debug.Log("can't Buy");
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }
    public void ExitButt()
    {
        transform.position = new Vector3(-800, 200, 0);
    }
}
