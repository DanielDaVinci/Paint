using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class Painter : MonoBehaviour
{
    [SerializeField] private Tilemap  tilemap;
    [SerializeField] private Tile     tilePrefab;

    [Header("Point settings")]
    [SerializeField] private uint  pointSize;
    [SerializeField] private uint  minPointSize;
    [SerializeField] private uint  maxPointSize;

    private bool DownOnPaintSpace = false;

    public Tilemap Tilemap
    {
        get { return tilemap; }
    }

    public Tile TilePrefab
    {
        get { return tilePrefab; }
    }

    public uint PointSize
    {
        get { return pointSize; }
        set
        {
            pointSize = (uint)Mathf.Clamp(value, minPointSize, maxPointSize);
        }
    }

    public Color PointColor
    {
        get { return tilePrefab.color; }
        set { tilePrefab.color = value; }
    }

    private void Start()
    {
        //CreateSheet();
    }
    /*
    private void CreateSheet()
    {
        for (int x = 0; x < sheetSize.x; x++)
        {
            for (int y = 0; y < sheetSize.y; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tilePrefab);
                tilemap.SetColor(new Vector3Int(x, y, 0), backgroundColor);
            }
        }
        tilemap.RefreshAllTiles();
    }
    */

    public delegate void OnTouch(Vector3Int position);
    public OnTouch Touch;
    private void Update()
    {
        OnMouseDown();
        OnMouseUp();
        OnMouseDrag();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        if (!EventSystem.current.IsPointerOverGameObject())
            DownOnPaintSpace = true;
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
            DownOnPaintSpace = true;
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
            DownOnPaintSpace = false;
    }

    private void OnMouseExit()
    {
        DownOnPaintSpace = false;
    }

    private void OnMouseDrag()
    {
        if (DownOnPaintSpace && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
            Touch?.Invoke(coordinate);
        }
    }
}
