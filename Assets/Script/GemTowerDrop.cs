using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemTowerDrop : Dropzone
{
    public static GemTowerDrop instance;
    public GameObject gemUI;
    public TowerForGem towerGemSelected;

    public GameObject rubyCard, SapphireCard, emeraldCard, diamondCard;
    public GameObject hand;

    public GameObject rubyBox, sapphireBox, emeraldBox, diamondBox;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 0)
        {
            CheckGem();
        }
        else
        {

        }
    }

    public void CheckGem()
    {
        if (towerGemSelected.gemInTower <= 4)
        {
            if (transform.Find("Ruby Gem") || transform.Find("Ruby Gem(Clone)"))
            {
                if (towerGemSelected.isRuby == false)
                {
                    towerGemSelected.isRuby = true;
                    towerGemSelected.gemInTower += 1;
                }
                else
                {
                    Instantiate(rubyCard, hand.transform);
                }
            }
            else if(transform.Find("Sapphire Gem") || transform.Find("Sapphire Gem(Clone)"))
            {
                if(towerGemSelected.isSapphire == false)
                {
                    towerGemSelected.isSapphire = true;
                    towerGemSelected.gemInTower += 1;
                }
                else
                {
                    Instantiate(SapphireCard, hand.transform);
                }
            }
            else if (transform.Find("Emerald Gem") || transform.Find("Emerald Gem(Clone)"))
            {
                if (towerGemSelected.isEmerald == false)
                {
                    towerGemSelected.isEmerald = true;
                    towerGemSelected.gemInTower += 1;
                }
                else
                {
                    Instantiate(emeraldCard, hand.transform);
                }
            }
            else if (transform.Find("Diamond Gem") || transform.Find("Diamond Gem(Clone)"))
            {
                if (towerGemSelected.isDiamond == false)
                {
                    towerGemSelected.isDiamond = true;
                    towerGemSelected.gemInTower += 1;
                }
                else
                {
                    Instantiate(diamondCard, hand.transform);
                }
            }
        }
        else
        {
            ReturnGem();

        }
        transform.DetachChildren();
        gemUI.transform.position = new Vector3(-800, 200, 0);


    }

    public void SelectedTowerGem(TowerForGem towerGem)
    {
        towerGemSelected = towerGem;

       if(towerGemSelected.isRuby == true)
        {
            rubyBox.SetActive(true);
        }
        else
        {
            rubyBox.SetActive(false);
        }if(towerGemSelected.isSapphire == true)
        {
            sapphireBox.SetActive(true);
        }
        else
        {
            sapphireBox.SetActive(false);
        }if(towerGemSelected.isEmerald == true)
        {
            emeraldBox.SetActive(true);
        }
        else
        {
            emeraldBox.SetActive(false);
        }if(towerGemSelected.isDiamond == true)
        {
            diamondBox.SetActive(true);
        }
        else
        {
            diamondBox.SetActive(false);
        }

    }

    public void ReturnGem()
    {
        if (transform.Find("Ruby Gem") || transform.Find("Ruby Gem(Clone)"))
        {
           
            
                Instantiate(rubyCard, hand.transform);
            
        }
        else if (transform.Find("Sapphire Gem") || transform.Find("Sapphire Gem(Clone)"))
        {
            
                Instantiate(SapphireCard, hand.transform);
            
        }
        else if (transform.Find("Emerald Gem") || transform.Find("Emerald Gem(Clone)"))
        {
            
            
                Instantiate(emeraldCard, hand.transform);
            
        }
        else if (transform.Find("Diamond Gem") || transform.Find("Diamond Gem(Clone)"))
        {
           
                Instantiate(diamondCard, hand.transform);
            
        }
    }

    public void ExitUI()
    {
        gemUI.transform.position = new Vector3(-800, 200, 0);
    }
}
