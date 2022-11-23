using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControlCard : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject inputPanel;
    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
       
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
        inputPanel.transform.position = new Vector3(960, 540, 0);
        inputPanel.SetActive(true);
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
    }

    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
