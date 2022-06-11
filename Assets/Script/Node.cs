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
    Shop shop;
    
    public string tagTurret;
   
    public bool hasTower = false;


    public GameObject MergeArea;
    public float areaRadius;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = Buildmanager.instance;
        shop = Shop.instance;
        Merge.Instance.nodeList.Add(this);
   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + Positionoffset;
    }

    

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!shop.towerInhand && turret != null)
        {
            if (Merge.Instance.nodeSelect.Count == 0)
            {
                buildManager.SelectNode(this);
                return;
                //Merge.Instance.nodeSelect.Add(this);
            }
            else if (Merge.Instance.nodeSelect.Count != 0)
            {
                Merge.Instance.nodeSelect.Add(this);
                MergeArea.SetActive(false);
                if (Merge.Instance.nodeSelect.Count >= 3)
                {
                    MergeArea.SetActive(false);
                    Merge.Instance.DeleteAll();
                }
                buildManager.SelectNodeTwo(this);
              
            }
           
        }
        else if (!shop.towerInhand && turret == null)
        {
            if (NodeUI.checkMerge)
            {
                Merge.Instance.nodeSelect[0].MergeArea.SetActive(false);
                
            }
            Merge.Instance.DeleteAll();
            Debug.Log("Don't any Tower can Merge");
            NodeUI.checkMerge = false;
            buildManager.DeselectNode();
        }
        else if (shop.towerInhand && turret != null)
        {
            Debug.Log("Have Tower here Can't build");
        }
        else if (shop.towerInhand && turret == null)
        {
            
            BuildTurret(buildManager.GetTurretToBuild());
        }




        if (!buildManager.CanBuild)
            return;

        
        
        hasTower = true;
    }

    

    void BuildTurret(GameObject blueprint)
    {
        GameObject _turret = (GameObject)Instantiate(blueprint, GetBuildPosition(), Quaternion.identity);
        getPos = GetBuildPosition();
        turret = _turret;
        buildManager.DeNodeTower();
        shop.towerInhand = false;
    }

    
    public void Merged()
    {
        float distanceTower = Vector3.Distance(Merge.Instance.nodeSelect[0].transform.position, Merge.Instance.nodeSelect[1].transform.position);
        if(distanceTower <= Merge.Instance.nodeSelect[0].areaRadius)
        {
            if (Merge.Instance.nodeSelect[0].turret.tag == Merge.Instance.nodeSelect[1].turret.tag)
            {
                if(PlayerStat.Money >= Merge.Instance.nodeSelect[1].turret.GetComponent<Turret>().GetMergePrice())
                {
                    Debug.Log("Merge EiEi");
                    MergeArea.SetActive(false);
                    PlayerStat.Money -= Merge.Instance.nodeSelect[1].turret.GetComponent<Turret>().GetMergePrice();
                    if (Merge.Instance.nodeSelect[0].turret.tag == "FireTower")
                    {
                        Destroy(turret);
                        GameObject _turret = (GameObject)Instantiate(buildManager.fireTurretPrefabLV2, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.fireEffect, transform.position, transform.rotation);
                        turret = _turret;

                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;

                    }
                    else if (Merge.Instance.nodeSelect[0].turret.tag == "FireTower2")
                    {
                        Destroy(turret);
                        GameObject _turret = (GameObject)Instantiate(buildManager.fireTurretPrefabLV3, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.fireEffect, GetBuildPosition(), Quaternion.identity);
                        turret = _turret;
                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;

                    }
                    else if (Merge.Instance.nodeSelect[0].turret.tag == "FireTower3")
                    {
                        /*GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV3, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                        turret = _turret;
                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;*/

                        //Test
                        buildManager.CantMergePOPUP();
                        Debug.Log("Can't Merge EiEi");
                        Merge.Instance.DeleteAll();

                    }
                    else if (Merge.Instance.nodeSelect[0].turret.tag == "WaterTower")
                    {
                        Destroy(turret);
                        GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV2, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                        turret = _turret;
                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;

                    }
                    else if (Merge.Instance.nodeSelect[0].turret.tag == "WaterTower2")
                    {
                        Destroy(turret);
                        GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV3, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                        turret = _turret;
                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;

                    }
                    else if (Merge.Instance.nodeSelect[0].turret.tag == "WaterTower3")
                    {
                        /*GameObject _turret = (GameObject)Instantiate(buildManager.waterTurretLV3, GetBuildPosition(), Quaternion.identity);
                        Instantiate(buildManager.waterEffect, GetBuildPosition(), Quaternion.identity);
                        turret = _turret;
                        Destroy(Merge.Instance.nodeSelect[1].turret);
                        Merge.Instance.nodeSelect[1].turret = null;*/

                        //Test
                        buildManager.CantMergePOPUP();
                        Debug.Log("Can't Merge EiEi");
                        Merge.Instance.DeleteAll();

                    }
                    Merge.Instance.DeleteAll();
                }
                else
                {
                    buildManager.NotEnoghMoneyPOPUP();
                    MergeArea.SetActive(false);
                    Merge.Instance.DeleteAll();
                }
                
            }
            else
            {
                buildManager.CantMergePOPUP();
                Debug.Log("Can't Merge EiEi");
                MergeArea.SetActive(false);
                Merge.Instance.DeleteAll();
            }
        }
        else
        {
            Debug.Log("out of range");
            buildManager.OutOfRange();
            Merge.Instance.nodeSelect[0].MergeArea.SetActive(false);
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
