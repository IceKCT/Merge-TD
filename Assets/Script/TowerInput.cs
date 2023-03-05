using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInput : Dropzone
{
    public static TowerInput instance;

    public GameObject self;
    PlayerStat PL;

    [HideInInspector]
    Node node;

    private GameObject TowerSelected;

    public GameObject UITower;
    
    public float price;

    private Node target;


    public GameObject mainHand, elementHand,mainHandButton;
   
    public GameObject FireTower, AcidTower, ToxicTower, ElecTower;
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
    }
    public void ExitButton()
    {
        UITower.transform.position = new Vector3(-800, 200, 0);
    }

    public void Update()
    {
       if(self.transform.childCount > 0)
        {
            CheckElement();
        }
        else
        {

        }
    }

    public void CheckElement()
    {
        if (self.transform.Find("Fire Element") || self.transform.Find("Fire Element(Clone)"))
        {
            target.BuildElement(FireTower);
            
        }
        else if (self.transform.Find("Acid Element") || self.transform.Find("Acid Element(Clone)"))
        {
            target.BuildElement(AcidTower);
        }
        else if (self.transform.Find("Poison"))
        {

        }
        else if (self.transform.Find("Electric"))
        {

        }
        else if (self.transform.Find("Gem"))
        {

        }
        self.transform.DetachChildren();
        Debug.Log("Work!!");
        UITower.transform.position = new Vector3(-800, 200, 0);
        mainHand.SetActive(true);
        elementHand.SetActive(false);
        mainHandButton.SetActive(true);
    }

 
    public void SelectTowerTarget(GameObject tower)
    {
        TowerSelected = tower;
    }
    public void SellTowerButton()
    {
        PL.getMoney(price);
        
    }


    public void AcceptAdd()
    {
        CheckElement();
    }

    public void CancleAdd()
    {

    }
}
