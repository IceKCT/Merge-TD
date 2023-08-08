using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCard : MonoBehaviour
{
    public List<GameObject> deck = new List<GameObject>();

    public List<GameObject> gemDeck = new List<GameObject>();
   
    public Transform[] cardSlots;

    private GameObject randC;

    public GameObject handElem;

    public float price;

    [Header("Fire")]
    public int currentFireLevel = 1;
    public float firePriceUpgrade;
    public Text levelFireCurrent, firePriceString;


    [Header("Acid")]
    public int currentAcidLevel = 1;
    public float acidPriceUpgrade;
    public Text levelAcidCurrent, acidPriceString;

    [Header("Poison")]
    public int currentPoisonLevel = 1;
    public float poisonPriceUpgrade;
    public Text levelPoisonCurrent, poisonPriceString;

    [Header("Elec")]
    public int currentElecLevel = 1;
    public float elecPriceUpgrade;
    public Text levelElecCurrent, elecPriceString;

    [Header("Burst")]
    public int currentBurstLevel = 1;
    public float burstPriceUpgrade;
    public Text levelBurstCurrent, burstPriceString;

    public GameObject fireCardLvl2,fireCardLvl3,acidCardLvl2,acidCardLvl3,elecCardLvl2,elecCardLvl3,poisonCardLvl2,poisonCardLvl3,burstCardLvl2,burstCardLvl3;


    public GameObject elementUI, gemUi;
    public GameObject tabPanel;

    public GameObject rubyCard, sapphireCard, emeraldCard, diamondCard;

    public float randomGemPrice;

    private bool maxFire, maxAcid, maxBurst, maxPoison, maxElec = false;
    public void RandomElementCard()
    {
        if (PlayerStat.Money >= price)
        {
            PlayerStat.Money -= price;
            int randNum = Random.Range(0, deck.Count);

            randC = deck[randNum];

            Instantiate(randC, handElem.transform);
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
       
    }

    public void UpgradeFire()
    {
        if(PlayerStat.Money >= firePriceUpgrade)
        {
            if (currentFireLevel == 1)
            {
                PlayerStat.Money -= firePriceUpgrade;
                currentFireLevel++;
                firePriceUpgrade += 100;
                firePriceString.text = firePriceUpgrade.ToString()+ " Gold";
                levelFireCurrent.text = "Level: " + currentFireLevel.ToString();
                deck.Add(fireCardLvl2);

            }
            else if (currentFireLevel == 2)
            {
                PlayerStat.Money -= firePriceUpgrade;
                currentFireLevel++;
                firePriceUpgrade += 100;
                firePriceString.text = firePriceUpgrade.ToString() + " Gold";
                levelFireCurrent.text = "Level: " + currentFireLevel.ToString();
                deck.Add(fireCardLvl3);
            }
            else if (currentFireLevel == 3)
            {
                PlayerStat.Money -= firePriceUpgrade;
                currentFireLevel++;
                firePriceString.text = "";
                levelFireCurrent.text = "Level: Max";
                maxFire = true;
                if(maxFire == true && maxElec == true && maxBurst == true && maxAcid == true && maxPoison == true)
                {
                    TabShow();
                }
                else
                {

                }
            }
            else
            {
               
            }
           
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
      
    }

    public void UpgradeAcid()
    {
        if (PlayerStat.Money >= acidPriceUpgrade)
        {
            if (currentAcidLevel == 1)
            {
                PlayerStat.Money -= acidPriceUpgrade;
                currentAcidLevel++;
                acidPriceUpgrade += 100;
                acidPriceString.text = acidPriceUpgrade.ToString() + " Gold";
                levelAcidCurrent.text = "Level: " + currentAcidLevel.ToString();
                deck.Add(acidCardLvl2);

            }
            else if (currentAcidLevel == 2)
            {
                PlayerStat.Money -= acidPriceUpgrade;
                currentAcidLevel++;
                acidPriceUpgrade += 100;
                acidPriceString.text = acidPriceUpgrade.ToString() + " Gold";
                levelAcidCurrent.text = "Level: " + currentAcidLevel.ToString();
                deck.Add(acidCardLvl3);
            }
            else if (currentAcidLevel == 3)
            {
                PlayerStat.Money -= acidPriceUpgrade;
                currentAcidLevel++;
                acidPriceString.text = "";
                levelAcidCurrent.text = "Level: Max";
                maxAcid = true;
                if (maxFire == true && maxElec == true && maxBurst == true && maxAcid == true && maxPoison == true)
                {
                    TabShow();
                }
                else
                {

                }
            }
            else
            {

            }

        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }

    public void UpgradePoison()
    {
        if (PlayerStat.Money >= poisonPriceUpgrade)
        {
            if (currentPoisonLevel == 1)
            {
                PlayerStat.Money -= poisonPriceUpgrade;
                currentPoisonLevel++;
                poisonPriceUpgrade += 100;
                poisonPriceString.text = poisonPriceUpgrade.ToString() + " Gold";
                levelPoisonCurrent.text = "Level: " + currentPoisonLevel.ToString();
                deck.Add(poisonCardLvl2);

            }
            else if (currentPoisonLevel == 2)
            {
                PlayerStat.Money -= poisonPriceUpgrade;
                currentPoisonLevel++;
                poisonPriceUpgrade += 100;
                poisonPriceString.text = poisonPriceUpgrade.ToString() + " Gold";
                levelPoisonCurrent.text = "Level: " + currentPoisonLevel.ToString();
                deck.Add(poisonCardLvl3);

            }
            else if (currentPoisonLevel == 3)
            {
                PlayerStat.Money -= poisonPriceUpgrade;
                currentPoisonLevel++;
                poisonPriceString.text = "";
                levelPoisonCurrent.text = "Level: Max";
                maxPoison = true;
                if (maxFire == true && maxElec == true && maxBurst == true && maxAcid == true && maxPoison == true)
                {
                    TabShow();
                }
                else
                {

                }
            }
            else
            {

            }

        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }
    public void UpgradeElec()
    {
        if (PlayerStat.Money >= elecPriceUpgrade)
        {
            if (currentElecLevel == 1)
            {
                PlayerStat.Money -= elecPriceUpgrade;
                currentElecLevel++;
                elecPriceUpgrade += 100;
                elecPriceString.text = elecPriceUpgrade.ToString() + " Gold";
                levelElecCurrent.text = "Level: " + currentElecLevel.ToString();
                deck.Add(elecCardLvl2); 

            }
            else if (currentElecLevel == 2)
            {
                PlayerStat.Money -= elecPriceUpgrade;
                currentElecLevel++;
                firePriceUpgrade += 100;
                elecPriceString.text = elecPriceUpgrade.ToString() + " Gold";
                levelElecCurrent.text = "Level: " + currentElecLevel.ToString();
                deck.Add(elecCardLvl3);
            }
            else if (currentElecLevel == 3)
            {
                PlayerStat.Money -= elecPriceUpgrade;
                currentElecLevel++;
                elecPriceString.text = "";
                levelElecCurrent.text = "Level: Max";
                maxElec = true;
                if (maxFire == true && maxElec == true && maxBurst == true && maxAcid == true && maxPoison == true)
                {
                    TabShow();
                }
                else
                {

                }
            }
            else
            {

            }

        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }

    public void UpgradeBurst()
    {
        if(PlayerStat.Money >= burstPriceUpgrade)
        {
            if (currentBurstLevel == 1)
            {
                PlayerStat.Money -= burstPriceUpgrade;
                currentBurstLevel++;
                burstPriceUpgrade += 100;
                burstPriceString.text = burstPriceUpgrade.ToString()+ " Gold";
                levelBurstCurrent.text = "Level: " + currentBurstLevel.ToString();
                deck.Add(burstCardLvl2);
            }else if (currentBurstLevel == 2)
            {
                PlayerStat.Money -= burstPriceUpgrade;
                currentBurstLevel++;
                burstPriceUpgrade += 100;
                burstPriceString.text = burstPriceUpgrade.ToString() + " Gold";
                levelBurstCurrent.text = "Level: " + currentBurstLevel.ToString();
                deck.Add(burstCardLvl3);
            }else if (currentBurstLevel == 3)
            {
                PlayerStat.Money -= burstPriceUpgrade;
                currentBurstLevel++;
                burstPriceString.text = "";
                levelBurstCurrent.text = "Level: Max";
                maxBurst = true;
                if (maxFire == true && maxElec == true && maxBurst == true && maxAcid == true && maxPoison == true)
                {
                    TabShow();
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }


    public void ElementTab()
    {
        elementUI.SetActive(true);
        gemUi.SetActive(false);
    }
    public void GemTab()
    {
        elementUI.SetActive(false);
        gemUi.SetActive(true);
    }

    public void TabShow()
    {
        tabPanel.SetActive(true);
    }

    public void RandomGem()
    {
        if(PlayerStat.Money >= randomGemPrice)
        {
            PlayerStat.Money -= randomGemPrice;
            int randNum = Random.Range(0, gemDeck.Count);

            randC = gemDeck[randNum];

            Instantiate(randC, handElem.transform);
        }
        else
        {
            Buildmanager.instance.NotEnoghMoneyPOPUP();
        }
    }
}
