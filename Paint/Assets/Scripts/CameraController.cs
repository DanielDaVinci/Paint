using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [Header("Zoom setting")]
    [SerializeField, Min(0)] private float minZoomSize;
    [SerializeField, Min(0)] private float maxZoomSize;
    [SerializeField, Min(0)] private float zoomSpeed;
    [SerializeField, Min(0)] private float startZoom;

    void Start()
    {
        _camera.orthographicSize = Mathf.Clamp(startZoom, minZoomSize, maxZoomSize);
    }

    void Update()
    {
        onMouseWheelScroll();
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
