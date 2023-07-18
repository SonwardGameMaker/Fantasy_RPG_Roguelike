using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGrid : MonoBehaviour
{
    [SerializeField] SpriteRenderer unwalkableTiles;
    [SerializeField] int height;
    [SerializeField] int width;
    [SerializeField] PathNode[,] nodes;
    [SerializeField] AStar pathfinder;

    //public int PPU;
    public int Height { get { return height; } }
    public int Width { get { return width; } }
    

    private void Start()
    {
        pathfinder = new AStar(this);
        nodes = new PathNode[width, height];

        InitGrid();
    }

    private void OnDrawGizmos()
    {
        if (nodes == null) return;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(new Vector3(x, y, 0.0f), new Vector3(x + 1, y, 0.0f));
                Gizmos.DrawLine(new Vector3(x, y, 0.0f), new Vector3(x, y + 1, 0.0f));
                Gizmos.DrawLine(new Vector3(x, y + 1, 0.0f), new Vector3(x + 1, y + 1, 0.0f));
                Gizmos.DrawLine(new Vector3(x + 1, y, 0.0f), new Vector3(x + 1, y + 1, 0.0f));
            }
        }
    }



    public int[] CoordToPos(double x, double y)
    {
        // TODO
        return new int[2] { (int)x, (int)y };
    }
    public int[] CoordToPos(Vector3 coordinate)
    {
        return CoordToPos(coordinate.x, coordinate.y);
    }
    public List<PathNode> FindPath(PathNode startNode, PathNode endNode)
    {
        return pathfinder.FindPath(startNode, endNode);
    }
    public List<PathNode> FindPath(Vector3 start, Vector3 end)
    {
        return pathfinder.FindPath(GetNode(start.x, start.y), GetNode(end.x, end.y));
    }
    public PathNode GetNode(double x, double y)
    {
        int[] pos = CoordToPos(x, y);
        Debug.Log("x = " + pos[0] + ", y = " + pos[1]);
        return nodes[pos[0], pos[1]];
    }

    private void InitGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                nodes[x, y] = new PathNode(this, x, y);
            }
        }
    }

}
