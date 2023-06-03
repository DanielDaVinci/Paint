using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawModeChanger : MonoBehaviour
{
    [SerializeField] private Painter Painter;

    private void Start()
    {
        SetBrush();
    }

    public void SetBrush()
    {
        Painter.Touch = null;
        Painter.Touch += DrawPoint;
    }

    public void SetFill()
    {
        Painter.Touch = null;
        Painter.Touch += Fill;
    }

    public void DrawPoint(Vector3Int position)
    {
        uint size = Painter.PointSize;

        for (int x = position.x - (int)size; x <= position.x + (int)size; x++)
        {
            for (int y = position.y - (int)size; y <= position.y + (int)size; y++)
            {
                if (Mathf.Sqrt((float)Mathf.Pow(x - position.x, 2) + (float)Mathf.Pow(y - position.y, 2)) <= size)
                {
                    Painter.Tilemap.SetTile(new Vector3Int(x, y, 0), Painter.TilePrefab);
                    Painter.Tilemap.RefreshTile(new Vector3Int(x, y, 0));
                }
            }
        }
    }

    public void Fill(Vector3Int position)
    {
        Tile currentTile;
        currentTile = Painter.Tilemap.GetTile<Tile>(position);

        if (currentTile != null && Painter.Tilemap.GetColor(position) != Painter.PointColor)
        {
            Painter.Tilemap.SetColor(position, Painter.PointColor);
            Painter.Tilemap.RefreshTile(position);

            Fill(position + Vector3Int.up);
            Fill(position + Vector3Int.right);
            Fill(position + Vector3Int.down);
            Fill(position + Vector3Int.left);
        }
    }
}
