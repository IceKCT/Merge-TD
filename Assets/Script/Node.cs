using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    
    public Color hoverColor;
    public Color notEnoughMoney;
    public Color colorCanMerge;
    public Vector3 Positionoffset;

    [HideInInspector]
    public static Vector3 getPos;

    [Header("Optional")]
    public GameObject turret;
    [HideInInspector]
    public static TurretBlueprint mergeTower;
   

    public GameObject effectPoint;
    private Renderer rend;
    private Color startColor;
    Buildmanager buildManager;
    NodeUI nodeUI;
    Merge merge;
    Shop shop;
    private static bool mouseReleased = true;
    public string tagTurret;
    private int RandomNum;
    public bool hasTower = false;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = Buildmanager.instance;
        Merge.Instance.nodeList.Add(this);
    }

    public Vector3 GetBuildPosition()
    {
        RandomNum = Random.Range(0, 10);
        Shop.ranNum = RandomNum;
        return transform.position + Positionoffset;
    }

    

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        mouseReleased = false;

        if (turret != null && Merge.Instance.nodeSelect.Count == 0)
        {
            buildManager.SelectNode(this);
            return;
            //Merge.Instance.nodeSelect.Add(this);
        }
        else if(turret != null && Merge.Instance.nodeSelect.Count != 0)
        {
            Merge.Instance.nodeSelect.Add(this);
            if(Merge.Instance.nodeSelect.Count >= 3)
            {
                Merge.Instance.DeleteAll();
            }
            buildManager.SelectNodeTwo(this);
            
        }
        else if (turret == null)
        {
            Merge.Instance.DeleteAll();
            Debug.Log("Don't any Tower can Merge");
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
        
        hasTower = true;
    }

    

    void BuildTurret(GameObject blueprint)
    {
        if (PlayerStat.Money < 100)
        {
            Debug.Log("Not enough money to build that");
            //Debug.Log(HasMoney);
            return;
        }
        PlayerStat.Money -= 100;
        GameObject _turret = (GameObject)Instantiate(blueprint, GetBuildPosition(), Quaternion.identity);
        getPos = GetBuildPosition();
        turret = _turret;
    }

    
    public void Merged()
    {
        if(Merge.Instance.nodeSelect[0].turret.tag == Merge.Instance.nodeSelect[1].turret.tag)
        {
            Debug.Log("Merge EiEi");
            Destroy(turret);
            if (Merge.Instance.nodeSelect[0].turret.tag == "FireTower")
            {
                GameObject _turret = (GameObject)Instantiate(buildManager.fireTurretPrefabLV2, GetBuildPosition(), Quaternion.identity);
                Instantiate(buildManager.fireEffect, transform.position, transform.rotation);
                turret = _turret;
                Destroy(Merge.Instance.nodeSelect[1].turret);
                Merge.Instance.nodeSelect[1].turret = null;
                
            }
            else if (Merge.Instance.nodeSelect[0].turret.tag == "FireTower2")
            {
                GameObject _turret = (GameObject)Instantiate(buildManager.fireTurretPrefabLV3, GetBuildPosition(), Quaternion.identity);
                Instantiate(buildManager.fireEffect, GetBuildPosition(), Quaternion.identity);
                turret = _turret;
                Destroy(Merge.Instance.nodeSelect[1].turret);
                Merge.Instance.nodeSelect[1].turret = null;

            }
            else if (Merge.Instance.nodeSelect[0].turret.tag == "WaterTower")
            {
                GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV2, GetBuildPosition(), Quaternion.identity);
                Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                turret = _turret;
                Destroy(Merge.Instance.nodeSelect[1].turret);
                Merge.Instance.nodeSelect[1].turret = null;
                
            }
            else if (Merge.Instance.nodeSelect[0].turret.tag == "WaterTower2")
            {
                GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV3, GetBuildPosition(), Quaternion.identity);
                Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                turret = _turret;
                Destroy(Merge.Instance.nodeSelect[1].turret);
                Merge.Instance.nodeSelect[1].turret = null;

            }
            Merge.Instance.DeleteAll();
        }
        else
        {
            Debug.Log("Can't Merge EiEi");
            Merge.Instance.DeleteAll();
        }
        
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.CanBuild)
            rend.material.color = hoverColor;



         if (buildManager.HasMoney)
         {
             rend.material.color = hoverColor;
         }
         else
         {
             rend.material.color = notEnoughMoney;
         }

        
       
       


    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    
    
}
