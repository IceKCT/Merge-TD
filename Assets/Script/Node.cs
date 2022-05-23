using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    
    public Color hoverColor;
    public Color notEnoughMoney;
    public Vector3 Positionoffset;

    [HideInInspector]
    public static Vector3 getPos;

    [Header("Optional")]
    public GameObject turret;
    [HideInInspector]
    public static TurretBlueprint mergeTower;
   

    private GameObject selectedTower;
    private Renderer rend;
    private Color startColor;
    Buildmanager buildManager;
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

        //offset = transform.position - MouseWorldPosition();
        mouseReleased = false;

        /*if (turret != null && Merge.Instance.nodeSelect.Count == 2)
        {
            buildManager.SelectNode(Merge.Instance.nodeSelect[1]);
            return;
        }*/
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if(Merge.Instance.nodeSelect.Count != 0)
        {
            Merge.Instance.nodeSelect.Add(this);
            if(Merge.Instance.nodeSelect.Count == 3)
            {
                Merge.Instance.DeleteAll();
            }
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
        hasTower = true;
    }

    

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStat.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            //Debug.Log(HasMoney);
            return;
        }

        PlayerStat.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        mergeTower = blueprint;
        getPos = GetBuildPosition();
        turret = _turret;
    }

    
    public void Merged()
    {
        if(Merge.Instance.nodeSelect[0].turret.tag == Merge.Instance.nodeSelect[1].turret.tag)
        {
            Destroy(Merge.Instance.nodeSelect[0].turret);
            Merge.Instance.nodeSelect[0].turret = null;
            Destroy(turret);
            GameObject _turret = (GameObject)Instantiate(mergeTower.prefabLevel2, GetBuildPosition(), Quaternion.identity);
            getPos = GetBuildPosition();
            turret = _turret;
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
            return;

        

        /* if (buildManager.HasMoney)
         {
             rend.material.color = hoverColor;
         }
         else
         {
             rend.material.color = notEnoughMoney;
         }*/


    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    
    /*private void OnMouseDrag()
    {
        if (turret == null)
            return;

        turret.transform.position = MouseWorldPosition() + offset;
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (mouseReleased && transform.tag == other.tag)
        {
            Destroy(turret.gameObject);
            Destroy(other.gameObject);
            
            Merged();
            Debug.Log("Merged!");
        }
        else if (mouseReleased && transform.tag != other.tag)
        {
            Debug.Log("Can't Merge");
            transform.position = GetBuildPosition();

        }
    }
    private void OnMouseUp()
    {
        mouseReleased = false;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseOnScreen = Input.mousePosition;
        mouseOnScreen.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseOnScreen);
    }
    */
}
