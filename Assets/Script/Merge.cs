using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public List<Node> nodeList = new List<Node>();
    public List<Node> nodeSelect = new List<Node>();

    private static Merge _instance;
    private Node node;
    public static Merge Instance { get{ return _instance; } }

    private void Awake()
    {
        if(_instance != null & _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    //public bool CanMerge { get { return nodeSelect[0].tag == nodeSelect[1].tag; } }
    public void ClickSelect(Node nodeToAdd)
    {
        nodeSelect.Add(nodeToAdd);
        nodeToAdd.transform.GetChild(0).gameObject.SetActive(true);
        if (nodeSelect.Count > 2)
        {
            DeleteAll();
        }

    }
    public void DeleteAll()
    {
        foreach(var node in nodeSelect)
        {
            node.transform.GetChild(0).gameObject.SetActive(false);
        }
        nodeSelect.Clear();
    }

    
}
