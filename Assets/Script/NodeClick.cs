using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClick : MonoBehaviour
{
    private Camera cam;

    public LayerMask clickable;
    public LayerMask ground;
    public Node node;
    void Start()
    {
        cam = Camera.main;
        node = GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);


                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable) )
                {
                    Merge.Instance.ClickSelect(hit.collider.gameObject.GetComponent<Node>()); 
                }
              
                else
                {
                    Merge.Instance.DeleteAll();
                }


            

        }
    }
}
