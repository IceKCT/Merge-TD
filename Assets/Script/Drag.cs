using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 offset;
    /*private GameObject selectedTower;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(selectedTower == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if (hit.collider.CompareTag("WaterTower"))
                    {
                        return;
                    }
                    selectedTower = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {

            }
        }

        if(selectedTower != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedTower.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedTower.transform.position = new Vector3(worldPosition.x, .25f,worldPosition.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
           Input.mousePosition.x,
           Input.mousePosition.y,
           Camera.main.farClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }*/
    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        Debug.Log("is Click");
    }

    private void OnMouseDrag()
    {
        Debug.Log("is Drag");
        transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseOnScreen = Input.mousePosition;
        mouseOnScreen.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseOnScreen);
    }
}
