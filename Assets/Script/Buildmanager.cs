using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildmanager : MonoBehaviour
{
    public static Buildmanager instance;
    public GameObject ResearchUI, ReseachElemUI;

    private void Awake()
    {
        if (instance != null)
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

    public GameObject popUPPlaceTower, popUPNotEnough;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.Money >= 100; } }

    public bool CloseSprite { get { return turretToBuild == null; } }

    public GameObject hand;

    public void SelectNode(Node node)
    {
        selectedNode = node;
        TowerInput.instance.SetTarget(node);
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
        hand.SetActive(false);
        selectedNode = null;
        PlaceTowerPopUp();
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

    public void PlaceTowerPopUp()
    {
        popUPPlaceTower.SetActive(true);
        
    }
    public void PlacedTowerPopUp()
    {
        popUPPlaceTower.SetActive(false);
    }
  

    public IEnumerator ClosePOPUP()
    {
        yield return new WaitForSeconds(closePOPUP);
        popUPNotEnough.SetActive(false);
       
       
    }

    public void IsitWork()
    {
        Debug.Log(turretToBuild);
        Debug.Log("Its work!!");
    }

}
