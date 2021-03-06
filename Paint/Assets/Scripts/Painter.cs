using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BoxCollider2D))]
public class Painter : MonoBehaviour
{
    [SerializeField] private Tilemap  tilemap;
    [SerializeField] private Tile     tilePrefab;

    [Header("Point settings")]
    [SerializeField] private Color pointColor;
    [SerializeField] private uint  pointSize;
    [SerializeField] private uint  minPointSize;
    [SerializeField] private uint  maxPointSize;

    private bool DownOnPaintSpace = false;

    public Color PointColor
    {
        get { return pointColor; }
        set
        {
            pointColor = value;
            tilePrefab.color = pointColor;
        }
    }

    public uint PointSize
    {
        get { return pointSize; }
        set
        {
            pointSize = (uint)Mathf.Clamp(value, minPointSize, maxPointSize);
        }
    }

    private void Start()
    {
        tilePrefab.color = pointColor;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            DownOnPaintSpace = true;
    }

    private void OnMouseUp()
    {
        DownOnPaintSpace = false;
    }

    private void OnMouseDrag()
    {
        if (DownOnPaintSpace && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
            DrawPoint(coordinate, pointSize);
        }
    }

    public void DrawPoint(Vector3Int position, uint size = 0)
    {
        for (int x = position.x - (int)size; x <= position.x + (int)size; x++)
        {
            for (int y = position.y - (int)size; y <= position.y + (int)size; y++)
            {
                if (Mathf.Sqrt((float)Mathf.Pow(x - position.x, 2) + (float)Mathf.Pow(y - position.y, 2)) <= size)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tilePrefab);
                    tilemap.RefreshTile(new Vector3Int(x, y, 0));
                }
            }
        }
    }
}
