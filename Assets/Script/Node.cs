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


    private List<string> elem = new List<string>();

    public GameObject effectPoint;
    private Renderer rend;
    private Color startColor;
    Buildmanager buildManager;
    Shop shop;

    public string tagTurret;

    public bool hasTower = false;



    [HideInInspector]
    public bool isFire, isAcid, isBurst, isElec, isPoison;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = Buildmanager.instance;
        shop = Shop.instance;
        elem = new List<string>();
        InvokeRepeating("CheckTower", 1, 1);

    }
    public void CheckTower()
    {
        if (turret != null)
        {

        }
        else
        {
            turret = null;
        }
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + Positionoffset;
    }

    public List<string> GetItemList()
    {
        return elem;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        /*if (turret != null)
        {
            buildManager.SelectNode(this);
        } */
        if (buildManager.CanBuild)
        {
            BuildTurret(buildManager.GetTurretToBuild());
            buildManager.hand.SetActive(true);

        }
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Already have tower");
        }
        else
        {
            BuildTurret(buildManager.GetTurretToBuild());
        }
        hasTower = true;
    }



    public void BuildTurret(GameObject blueprint)
    {
        GameObject _turret = (GameObject)Instantiate(blueprint, GetBuildPosition(), Quaternion.identity);
        getPos = GetBuildPosition();
        turret = _turret;

        buildManager.PlacedTowerPopUp();
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

    public void BuildElement(GameObject blueprint)
    {
        Destroy(turret);
        GameObject _turret = (GameObject)Instantiate(blueprint, GetBuildPosition(), Quaternion.identity);
        getPos = GetBuildPosition();
        turret = _turret;
        buildManager.DeNodeTower();


        FindObjectOfType<AudioManager>().Play("Building");
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }



}
