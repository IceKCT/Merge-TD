using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{
    public static Buildmanager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;
        
    }
    public GameObject fireTurretPrefab, waterTurret, fireTurretPrefabLV2, waterTurretLV2, fireTurretPrefabLV3, waterTurretLV3;
    public GameObject waterEffect, fireEffect;


    public NodeUI nodeUI;
    private GameObject turretToBuild;
    private Node selectedNode;
    public float closePOPUP = 4;
    

    public GameObject popUPcantmerge, popUPNotEnough;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.Money >= 100; } }

    public bool CloseSprite { get { return turretToBuild == null; } }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node); 
    }
    
    public void SelectNodeTwo(Node node)
    {
        nodeUI.SetTargetTwo(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public void DeNodeTower()
    {
        turretToBuild = null;
    }

    public GameObject GetTurretToBuild()
    {
        
        return turretToBuild;
    }

    public void NotEnoghMoneyPOPUP()
    {
        popUPNotEnough.SetActive(true);
        StartCoroutine(ClosePOPUP());
    }

    public void CantMergePOPUP()
    {
        popUPcantmerge.SetActive(true);
        StartCoroutine(ClosePOPUP());
    }

    public IEnumerator ClosePOPUP()
    {
        yield return new WaitForSeconds(closePOPUP);
        popUPNotEnough.SetActive(false);
        popUPcantmerge.SetActive(false);
    } 



}
