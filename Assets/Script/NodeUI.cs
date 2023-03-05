using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
   /* public GameObject UI;
    private Node target,target2;

    private Camera cam;

    public LayerMask clickable;
    public LayerMask ground;

    public Vector3 Positionoffset;
    public static bool checkMerge = false;

    private int getMoney;
    public GameObject sellEffect;
    public Transform effectPoint;

    public Text MergePrice,MergeShadowPrice,sellPriceText , sellPriceTextShadow;
    public void SetTarget(Node _target)
    {
        this.target = _target;
        this.target2 = _target;
        //Text Price Merge
        MergePrice.text = target.turret.GetComponent<Turret>().GetMergePrice().ToString() + " $";
        MergeShadowPrice.text = target.turret.GetComponent<Turret>().GetMergePrice().ToString() + " $";
        //Text Price Sell
        sellPriceText.text = target.turret.GetComponent<Turret>().GetMoneyFromTower().ToString() + " $";
        sellPriceTextShadow.text = target.turret.GetComponent<Turret>().GetMoneyFromTower().ToString() + " $";

        transform.position = target.GetBuildPosition() + Positionoffset;
        UI.SetActive(true);
    }

    public void SetTargetTwo(Node _target)
    {
        this.target = _target;
        if(target != target2)
        {
            MergeNew();
        }
        else if (target.turret == null)
        {
           
            Debug.Log("Don't have tower to merge");
            Merge.Instance.DeleteAll();
        }
        else
        {
            target.MergeArea.SetActive(false);
            Buildmanager.instance.SelectAnother();
            Debug.Log("Can't merge self tower");
            Merge.Instance.DeleteAll();
        }
        
    }


    public void Hide()
    {
        UI.SetActive(false);
    }
    
    public void MergeTower()
    {
        checkMerge = true;
        target.MergeArea.SetActive(true);
        Merge.Instance.nodeSelect.Add(target);
        if(Merge.Instance.nodeSelect.Count == 2)
        {
           
            
        }
        Buildmanager.instance.DeselectNode();
    }

    public void MergeNew()
    {
     
        Buildmanager.instance.DeselectNode();
        Merge.Instance.DeleteAll();
    }
   
    public void SellTower()
    {
        PlayerStat.Money += target.turret.GetComponent<Turret>().GetMoneyFromTower();
        
        Destroy(target.turret);
        target.turret = null;
        Instantiate(sellEffect, effectPoint.position, Quaternion.identity);
        Buildmanager.instance.DeselectNode();
    }

    */

    
}
