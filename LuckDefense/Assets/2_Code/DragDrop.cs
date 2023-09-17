using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        Debug.Log("Mouse Down");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        isDragging = false;
        
    }

    private void Update()
    {
        if (isDragging)
        {
            Debug.Log("Dragging");
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
            newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);
            
            
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}