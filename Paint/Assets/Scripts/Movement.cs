using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Vector2 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
            lastPos = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 newPos = Input.mousePosition;
            Vector3 direction = (lastPos - newPos).normalized;
            lastPos = newPos;

            transform.position -= direction * Time.deltaTime * speed;
        }
    }
}
