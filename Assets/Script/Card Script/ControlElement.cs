using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
    
        img.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(CardManager.LastEnterDropzone);

        img.raycastTarget = true;
        GameObject droppedCard = eventData.pointerDrag;
        Debug.Log("Dropped card: " + droppedCard.name);
    }


  
}
