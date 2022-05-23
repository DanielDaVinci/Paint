using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(BoxCollider2D))]
public class Painter : MonoBehaviour
{
    [SerializeField] private Tilemap  tilemap;
    [SerializeField] private TileBase tilePrefab;
    [SerializeField] private uint     pointSize;

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
            DrawPoint(coordinate, pointSize);
        }
    }

    public void DrawPoint(Vector3Int position, uint size = 0)
    {
        tilemap.SetTile(position, tilePrefab);
        for (int x = position.x - (int)size; x <= position.x + (int)size; x++)
        {
            for (int y = position.y - (int)size; y <= position.y + (int)size; y++)
            {
                if (Mathf.Sqrt((float)Mathf.Pow(x - position.x, 2) + (float)Mathf.Pow(y - position.y, 2)) <= size)
                    tilemap.SetTile(new Vector3Int(x, y, 0), tilePrefab);
            }
        }
    }
}
