using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResearchCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float y;
    // Start is called before the first frame update

    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {

    }
    public void OnEndDrag(PointerEventData eventData)
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

  
    private void OnMouseEnter()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        Debug.Log("Yahoo");
    }
    private void OnMouseDown()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        Debug.Log("Click");
    }
}
