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
    public GameObject fireTurretPrefab;
    public GameObject waterTurret;
    public NodeUI nodeUI;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    
    public bool CanBuild { get { return turretToBuild != null; } }
    //public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }
    


    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node); 
    }
    

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public void DeNodeTower()
    {
        turretToBuild = null;
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

  


}
