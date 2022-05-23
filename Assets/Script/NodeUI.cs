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

        transform.position = target.GetBuildPosition() + Positionoffset;
        UI.SetActive(true);
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
        
        /*Merge.Instance.nodeSelect[0].turret = null;
        Merge.Instance.DeleteAll();*/
        Buildmanager.instance.DeselectNode();
    }

    

    
}
