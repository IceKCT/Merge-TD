using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorArrow : MonoBehaviour
{
    public Texture2D cursor;
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
