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

            
        if (buildManager.CanBuild)
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
        
        
        FindObjectOfType<AudioManager>().Play("Building");
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
