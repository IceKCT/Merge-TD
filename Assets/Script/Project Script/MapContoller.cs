using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapContoller : MonoBehaviour
{
    [HideInInspector] public Vector3 CurrentMousePosition;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(var hit in hits)
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Map")) continue;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);

            CurrentMousePosition = hit.point;
            break;
        }
    }
}
