using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerInput : Dropzone
{
    public static TowerInput instance;

    [Header("Something else")]
    public GameObject self;
    PlayerStat PL;
    public GameObject UITower;
    public float price;
    private Node target;
    Resercher rs;
    public GameObject mainHand,mainHandButton;
    [HideInInspector]
    Node node;

    private BaseTower TowerSelected;
    private GameObject TowerSelectedGameobject;

    [Header("Box Check Card")]
    public GameObject fireBox, fireBox2, fireBox3, AcidBox, acidBox2, acidBox3, poisonBox, poisonBox2, poisonBox3, burstBox, burstBox2, burstBox3, elecBox, elecBox2, elecBox3;

    private int copyCurrentCardinSlot;

    [HideInInspector]
    public BaseTower tower;


    [Header("Card")]
    public GameObject fireCard, fireCard2, fireCard3, acidCard, acidCard2, acidCard3, poisonCard, poisonCard2, poisonCard3, burstCard, burstCard2, burstCard3, elecCard, elecCard2, elecCard3;

    [Header("Something")]
    public GameObject handElem, handMain, buttElem, Buttmain;


    public GameObject rubyCard, SapphireCard, emeraldCard, diamondCard;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;

    }


    public void SetTarget(Node _target)
    {
        target = _target;

    }
    public void Start()
    {
        PL = PlayerStat.instance;
        node = GetComponent<Node>();
        rs = Resercher.instance;
    }
    public void ExitButton()
    {
        UITower.transform.position = new Vector3(-800, 200, 0);
        Buttmain.SetActive(true);
        handMain.SetActive(true);
    }

    public void Update()
    {
        if (self.transform.childCount > 0)
        {
            LevelCheck();
        }
        else
        {

        }
    }

    public void CheckElement()
    {

        if (self.transform.Find("Fire Element") || self.transform.Find("Fire Element(Clone)"))
        {
            if (TowerSelected.isFire == false)
            {
                TowerSelected.isFire = true;
                TowerSelected.currentCardinTower += 1;

            }
            else
            {
                Instantiate(fireCard, mainHand.transform);
                Debug.Log("Already have this card");
            }
        }
        else if (self.transform.Find("Fire Element Level 2") || self.transform.Find("Fire Element Level 2(Clone)"))
        {
            if (TowerSelected.isFire2 == false)
            {
                TowerSelected.isFire2 = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(fireCard2, mainHand.transform);
                Debug.Log("Already have this card");
            }

        }
        else if (self.transform.Find("Fire Element Level 3") || self.transform.Find("Fire Element Level 3(Clone)"))
        {
            if (TowerSelected.isFire3 == false)
            {
                TowerSelected.isFire3 = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(fireCard3, mainHand.transform);
            }
        }
        else if (self.transform.Find("Acid Element") || self.transform.Find("Acid Element(Clone)"))
        {
            if (TowerSelected.isAcid == false)
            {
                TowerSelected.isAcid = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(acidCard, mainHand.transform);
                Debug.Log("Already have this card");
            }

        }
        else if (self.transform.Find("Acid Element Level 2") || self.transform.Find("Acid Element Level 2(Clone)"))
        {
            if (TowerSelected.isAcid2 == false)
            {
                TowerSelected.isAcid2 = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(acidCard2, mainHand.transform);
            }
        }
        else if (self.transform.Find("Acid Element Level 3") || self.transform.Find("Acid Element Level 3(Clone)"))
        {
            if (TowerSelected.isAcid3 == false)
            {
                TowerSelected.isAcid3 = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(acidCard3, mainHand.transform);
            }
        }
        else if (self.transform.Find("Poison Element") || self.transform.Find("Posion Element(Clone)"))
        {
            if (TowerSelected.isPoison == false)
            {
                TowerSelected.isPoison = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(poisonCard, mainHand.transform);
                Debug.Log("Already have this card");
            }
        }
        else if (self.transform.Find("Poison Element Level 2") || self.transform.Find("Poison Element Level 2(Clone)"))
        {
            if (TowerSelected.isPoison2 == false)
            {
                TowerSelected.isPoison2 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(poisonCard2, mainHand.transform);
            }
        }
        else if (self.transform.Find("Poison Element Level 3") || self.transform.Find("Poison Element Level 3(Clone)"))
        {
            if (TowerSelected.isPoison3 == false)
            {
                TowerSelected.isPoison3 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(poisonCard3, mainHand.transform);
            }
        }
        else if (self.transform.Find("Electric Element") || self.transform.Find("Electric Element(Clone)"))
        {
            if (TowerSelected.isElec == false)
            {
                TowerSelected.isElec = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(elecCard, mainHand.transform);
                Debug.Log("Already have this card");
            }
        }
        else if (self.transform.Find("Electric Element Level 2") || self.transform.Find("Electric Element Level 2(Clone)"))
        {
            if (TowerSelected.isElec2 == false)
            {
                TowerSelected.isElec2 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(elecCard2, mainHand.transform);
            }
        }
        else if (self.transform.Find("Electric Element Level 3") || self.transform.Find("Electric Element Level 3(Clone)"))
        {
            if (TowerSelected.isElec3 == false)
            {
                TowerSelected.isElec3 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(elecCard3, mainHand.transform);
            }
        }
        else if (self.transform.Find("Burst Element") || self.transform.Find("Burst Element(Clone)"))
        {
            if (TowerSelected.isBurst == false)
            {
                TowerSelected.isBurst = true;
                TowerSelected.currentCardinTower += 1;
            }
            else
            {
                Instantiate(burstCard, mainHand.transform);
                Debug.Log("Already have this card");
            }
        }
        else if (self.transform.Find("Burst Element Level 2") || self.transform.Find("Burst Element Level 2(Clone)"))
        {
            if (TowerSelected.isBurst2 == false)
            {
                TowerSelected.isBurst2 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(burstCard2, mainHand.transform);
            }
        }
        else if (self.transform.Find("Burst Element Level 3") || self.transform.Find("Burst Element Level 3(Clone)"))
        {
            if (TowerSelected.isBurst3 == false)
            {
                TowerSelected.isBurst3 = true;
                TowerSelected.currentCardinTower++;
            }
            else
            {
                Instantiate(burstCard3, mainHand.transform);
            }
        }
        else if (self.transform.Find("Gem"))
        {
            if (TowerSelected.isFire == false)
            {
                TowerSelected.isFire = true;
            }
            else
            {

            }
        }
        if (transform.Find("Ruby Gem") || transform.Find("Ruby Gem(Clone)"))
        {


            Instantiate(rubyCard, mainHand.transform);

        }
        else if (transform.Find("Sapphire Gem") || transform.Find("Sapphire Gem(Clone)"))
        {

            Instantiate(SapphireCard, mainHand.transform);

        }
        else if (transform.Find("Emerald Gem") || transform.Find("Emerald Gem(Clone)"))
        {


            Instantiate(emeraldCard, mainHand.transform);

        }
        else if (transform.Find("Diamond Gem") || transform.Find("Diamond Gem(Clone)"))
        {

            Instantiate(diamondCard, mainHand.transform);

        }
        self.transform.DetachChildren();
        Debug.Log("Work!!");
        UITower.transform.position = new Vector3(-800, 200, 0);
    
        mainHandButton.SetActive(true);
    }
    public void LevelCheck()
    {
        if (TowerSelected.currentCardinTower == 0)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 1;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }

        //Base Tower
        if (TowerSelected.currentCardinTower == 1 && rs.currentNormalLevel >= 2)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 2;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 2 && rs.currentNormalLevel >= 3)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 3;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 3 && rs.currentNormalLevel >= 4)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 4;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }   //Burst Tower
        if (TowerSelected.currentCardinTower == 1 && rs.currentBurstLevel >= 2)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 2;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 2 && rs.currentBurstLevel >= 3)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 3;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 3 && rs.currentBurstLevel >= 4)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 4;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        //Aoe Tower
        if (TowerSelected.currentCardinTower == 1 && rs.currentAOELevel >= 2)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 2;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 2 && rs.currentAOELevel >= 3)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 3;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 3 && rs.currentAOELevel >= 4)
        {
            CheckElement();
            TowerSelected.currentCardinTower = 4;
            copyCurrentCardinSlot = TowerSelected.currentCardinTower;
            return;
        }
        else if (TowerSelected.currentCardinTower == 4)
        {
            Debug.Log("Full Card");
            return;
        }
        else
        {
            ReturnCard();
            if (TowerSelected.currentCardinTower != copyCurrentCardinSlot)
            {
                TowerSelected.currentCardinTower = copyCurrentCardinSlot;
            }
            else
            {
                TowerSelected.currentCardinTower = copyCurrentCardinSlot;
            }

            Debug.Log("Need More Level!!");
        }





    }

    public void ReturnCard()
    {
        if (self.transform.Find("Fire Element") || self.transform.Find("Fire Element(Clone)"))
        {

            Instantiate(fireCard, mainHand.transform);


        }
        else if (self.transform.Find("Fire Element Level 2") || self.transform.Find("Fire Element Level 2(Clone)"))
        {
            Instantiate(fireCard2, mainHand.transform);
        }
        else if (self.transform.Find("Fire Element Level 3") || self.transform.Find("Fire Element Level 3(Clone)"))
        {
            Instantiate(fireCard3, mainHand.transform);
        }
        else if (self.transform.Find("Acid Element") || self.transform.Find("Acid Element(Clone)"))
        {
            Instantiate(acidCard, mainHand.transform);
        }
        else if (self.transform.Find("Acid Element Level 2") || self.transform.Find("Acid Element Level 2(Clone)"))
        {
            Instantiate(acidCard2, mainHand.transform);
        }
        else if (self.transform.Find("Acid Element Level 3") || self.transform.Find("Acid Element Level 3(Clone)"))
        {
            Instantiate(acidCard3, mainHand.transform);
        }
        else if (self.transform.Find("Poison Element") || self.transform.Find("Poison Element(Clone)"))
        {

            Instantiate(poisonCard, mainHand.transform);


        }
        else if (self.transform.Find("Poison Element Level 2") || self.transform.Find("Poison Element Level 2(Clone)"))
        {
            Instantiate(poisonCard2, mainHand.transform);
        }
        else if (self.transform.Find("Poison Element Level 3") || self.transform.Find("Poison Element Level 3(Clone)"))
        {
            Instantiate(poisonCard3, mainHand.transform);
        }
        else if (self.transform.Find("Electric Element") || self.transform.Find("Electric Element(Clone)"))
        {

            Instantiate(elecCard, mainHand.transform);


        }
        else if (self.transform.Find("Electric Element Level 2") || self.transform.Find("Electric Element Level 2(Clone)"))
        {
            Instantiate(elecCard2, mainHand.transform);
        }
        else if (self.transform.Find("Electric Element Level 3") || self.transform.Find("Electric Elment Level 3(Clone)"))
        {
            Instantiate(elecCard3, mainHand.transform);
        }
        else if(self.transform.Find("Burst Element") || self.transform.Find("Burst Element(Clone)"))
        {
            Instantiate(burstCard, mainHand.transform);
        }else if (self.transform.Find("Burst Element Level 2") || self.transform.Find("Burst Element Level 2(Clone)"))
        {
            Instantiate(burstCard2, mainHand.transform);

        }else if (self.transform.Find("Burst Element Level 3") || self.transform.Find("Burst Element Level 3(Clone)"))
        {
            Instantiate(burstCard3, mainHand.transform);
        }
        self.transform.DetachChildren();
    }

    public void SelectTowerTarget(BaseTower tower)
    {
        TowerSelected = tower;
        price = tower.priceTower;
        Debug.Log(TowerSelected);

        if (TowerSelected.isFire == true)
        {
            fireBox.SetActive(true);
        }
        else
        {
            fireBox.SetActive(false);
        }
        if (TowerSelected.isFire2 == true)
        {
            fireBox2.SetActive(true);
        }
        else
        {
            fireBox2.SetActive(false);
        }
        if (TowerSelected.isFire3 == true)
        {
            fireBox3.SetActive(true);
        }
        else
        {
            fireBox3.SetActive(false);
        }
        if (TowerSelected.isAcid == true)
        {
            AcidBox.SetActive(true);
        }
        else
        {
            AcidBox.SetActive(false);
        }
        if (TowerSelected.isAcid2 == true)
        {
            acidBox2.SetActive(true);
        }
        else
        {
            acidBox2.SetActive(false);
        }
        if (TowerSelected.isAcid3 == true)
        {
            acidBox3.SetActive(true);
        }
        else
        {
            acidBox3.SetActive(false);
        }
        if (TowerSelected.isPoison == true)
        {
            poisonBox.SetActive(true);
        }
        else
        {
            poisonBox.SetActive(false);
        }
        if (TowerSelected.isPoison2 == true)
        {
            poisonBox2.SetActive(true);
        }
        else
        {
            poisonBox2.SetActive(false);
        }
        if (TowerSelected.isPoison3 == true)
        {
            poisonBox3.SetActive(true);
        }
        else
        {
            poisonBox3.SetActive(false);
        }
        if (TowerSelected.isBurst == true)
        {
            burstBox.SetActive(true);
        }
        else
        {
            burstBox.SetActive(false);
        }
        if (TowerSelected.isBurst2 == true)
        {
            burstBox2.SetActive(true);
        }
        else
        {
            burstBox2.SetActive(false);
        }
        if (TowerSelected.isBurst3 == true)
        {
            burstBox3.SetActive(true);
        }
        else
        {
            burstBox3.SetActive(false);
        }
        if (TowerSelected.isElec == true)
        {
            elecBox.SetActive(true);
        }
        else
        {
            elecBox.SetActive(false);
        }
        if (TowerSelected.isElec2 == true)
        {
            elecBox2.SetActive(true);
        }
        else
        {
            elecBox2.SetActive(false);
        }
        if (TowerSelected.isElec3 == true)
        {
            elecBox3.SetActive(true);
        }
        else
        {
            elecBox3.SetActive(false);
        }

    }
    public void SellTowerButton()
    {

        PL.getMoney(price);
        Destroy(TowerSelectedGameobject);
        UITower.transform.position = new Vector3(-800, 200, 0);
    }


    public void SetObjectTower(GameObject _tower)
    {
        TowerSelectedGameobject = _tower;
    }
}
