using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector3 startPos;
    private Vector2 lastMousePos;

    private void Update()
    {
        OnRightMouseDown();
        OnRightMouseDrag();
    }

    private void OnRightMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startPos = transform.position;
            lastMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnRightMouseDrag()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 newMousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 delta = newMousePos - lastMousePos;

            transform.position = startPos + delta;
        }
    }
}
