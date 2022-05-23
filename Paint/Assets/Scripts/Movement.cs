using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [Header("Zoom")]
    [SerializeField] private float   minZoomSize;
    [SerializeField] private float   maxZoomSize;
    [SerializeField] private float   zoomSpeed;

    private Vector3 startPos;
    private Vector2 lastMousePos;

    private void Update()
    {
        OnRightMouseDown();
        OnRightMouseDrag();

        onMouseWheelScroll();
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

    private void onMouseWheelScroll()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float delta = Input.GetAxis("Mouse ScrollWheel");
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - delta * zoomSpeed, minZoomSize, maxZoomSize);
        }
    }
}
