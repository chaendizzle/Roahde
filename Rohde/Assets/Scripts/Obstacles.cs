using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Obstacles : MonoBehaviour
{
    Tilemap tilemap;
    bool[,] obstacles;
    bool[,] playerObstacles;
    Pathfinder pathfinder;
    List<GameObject> markers = new List<GameObject>();
    public GameObject markerPrefab;

    bool held = false;
    Vector3 startPos;
    Vector3 endPos;

    static Obstacles instance;

    // Use this for initialization
    void Awake () {
        instance = this;
        tilemap = GetComponentInChildren<Tilemap>();
        obstacles = new bool[tilemap.size.x, tilemap.size.y];
        playerObstacles = new bool[tilemap.size.x, tilemap.size.y];
        for (int i = 0; i < tilemap.size.x; i++)
        {
            for (int j = 0; j < tilemap.size.y; j++)
            {
                TileBase tile = tilemap.GetTile(ToGridPos(new Vector2Int(i, j)));
                obstacles[i, j] = tile != null && tile.name != "tileset_7";
                playerObstacles[i, j] = tile != null && (tile.name == "tileset_6" || tile.name == "tileset_8");
            }
        }
        pathfinder = new Pathfinder(obstacles, false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            held = true;
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            held = false;
        }
        List<Vector3> path = new List<Vector3>();
        if (held)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            path = FindPath(startPos, endPos);
            if (path == null)
            {
                path = new List<Vector3>();
            }
        }
        DrawPath(path);
    }

    void DrawPath(List<Vector3> path)
    {
        for (int i = markers.Count; i < path.Count; i++)
        {
            markers.Add(Instantiate(markerPrefab));
        }
        for (int i = path.Count; i < markers.Count; i++)
        {
            Destroy(markers[i]);
            markers.RemoveAt(i);
            i--;
        }
        for (int i = 0; i < path.Count; i++)
        {
            markers[i].transform.position = new Vector3(path[i].x, path[i].y, markers[i].transform.position.z);
            if (i < path.Count - 1)
            {
                markers[i].GetComponent<Marker>().target = markers[i + 1];
            }
        }
    }

    public List<Vector3> FindPath(Vector3 start, Vector3 end)
    {
        Vector2Int startPos = ToArrayPos(tilemap.WorldToCell(start));
        Vector2Int endPos = ToArrayPos(tilemap.WorldToCell(end));
        return pathfinder.FindPath(startPos, endPos)
            ?.Select(p => tilemap.GetCellCenterWorld(ToGridPos(p))).ToList();
    }

    public static List<Vector3> PathTo(Vector3 start, Vector3 end)
    {
        return instance.FindPath(start, end);
    }

    public Vector3Int ToGridPos(Vector2Int arrayPos)
    {
        int cellX = -(tilemap.size.x) / 2 + arrayPos.x;
        int cellY = -(tilemap.size.y) / 2 + arrayPos.y;
        return new Vector3Int(cellX, cellY, 0);
    }
    public Vector2Int ToArrayPos(Vector3Int gridPos)
    {
        int arrayX = (tilemap.size.x) / 2 + gridPos.x;
        int arrayY = (tilemap.size.y) / 2 + gridPos.y;
        return new Vector2Int(arrayX, arrayY);
    }
}
