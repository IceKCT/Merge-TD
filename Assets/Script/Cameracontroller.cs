using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    private bool Lock = true;
    public float panSpeed = 50f;
    public float panBorderThickness = 10f;
    public float scrollspeed = 8f;
    public float minY = 10f;
    public float maxY = 80f;

    public float VerticalXMin, VerticalZMin, VerticalXMax, VerticalZMax;

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            Lock = !Lock;
        }
        if (!Lock)
        {
            return;
        }
       
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
        
      
        

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollspeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, VerticalXMin, VerticalXMax);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, VerticalZMin, VerticalZMax);
        transform.position = pos;
    }
}
