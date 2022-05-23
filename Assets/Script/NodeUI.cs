using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject UI;
    private Node target,target2;

    private Camera cam;

    public LayerMask clickable;
    public LayerMask ground;

    public Vector3 Positionoffset;
    
    public void SetTarget(Node _target)
    {
        this.target = _target;
        this.target2 = _target;
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
        else if (target == null)
        {
            Debug.Log("Don't have tower to merge");
            Merge.Instance.DeleteAll();
        }
        else
        {
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
        Merge.Instance.nodeSelect.Add(target);
        if(Merge.Instance.nodeSelect.Count == 2)
        {
            target.Merged();
            
        }
        Buildmanager.instance.DeselectNode();
    }

    public void MergeNew()
    {
        target2.Merged();
        Buildmanager.instance.DeselectNode();
        
    }
   

    

    
}
