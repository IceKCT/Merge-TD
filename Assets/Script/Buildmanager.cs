using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{
    public static Buildmanager instance;
    public GameObject ResearchUI;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;
        
    }
   
    public GameObject waterEffect, fireEffect;

    public GameObject uiTower;


    public NodeUI nodeUI;
    private GameObject turretToBuild;
    private Node selectedNode;
    public float closePOPUP = 4;

    public GameObject frameTowerPrefab;

    public GameObject popUPcantmerge, popUPNotEnough, popUpOFR, popUpSelectAnother;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.Money >= 100; } }

    public bool CloseSprite { get { return turretToBuild == null; } }



    public void SelectNode(Node node)
    {
        selectedNode = node;
        TowerInput.instance.SetTarget(node);
        TowerInput.instance.mainHand.SetActive(false);
        TowerInput.instance.elementHand.SetActive(true);
        TowerInput.instance.mainHandButton.SetActive(false);
        turretToBuild = null;
        uiTower.transform.position = new Vector3(960, 540, 0);
    }
    

    public void DeselectNode()
    {
        selectedNode = null;
     
    }

    public void SelectTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
        selectedNode = null;
 
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
    public void OutOfRange()
    {
        popUpOFR.SetActive(true);
        StartCoroutine(ClosePOPUP());
    }
    public void SelectAnother()
    {
        popUpSelectAnother.SetActive(true);
        StartCoroutine(ClosePOPUP());
    }

    public IEnumerator ClosePOPUP()
    {
        yield return new WaitForSeconds(closePOPUP);
        popUPNotEnough.SetActive(false);
        popUPcantmerge.SetActive(false);
        popUpSelectAnother.SetActive(false);
        popUpOFR.SetActive(false);
    } 

    public void IsitWork()
    {
        Debug.Log(turretToBuild);
        Debug.Log("Its work!!");
    }

}
