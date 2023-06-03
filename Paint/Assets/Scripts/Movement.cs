using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector3 startPos;
    private Vector2 lastMousePos;

    bool DownOnPaintSpace = false;

    private void Update()
    {
        OnRightMouseDown();
        OnRightMouseDrag();
        OnRightMouseUp();
    }

    private void OnRightMouseDown()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            DownOnPaintSpace = true;

            startPos = transform.position;
            lastMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnRightMouseUp()
    {
        if (Input.GetMouseButtonUp(1))
            DownOnPaintSpace = false;
    }

    private void OnRightMouseDrag()
    {
        if (DownOnPaintSpace && Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 newMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 delta = newMousePos - lastMousePos;

            transform.position = startPos + delta;
        }
    }
}
