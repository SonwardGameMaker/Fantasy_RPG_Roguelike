using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode 
{
    private PathGrid grid;
    public readonly int x;
    public readonly int y;

    public int gCost;
    public int hCost;
    public int fCost;
    [SerializeField] private List<PathWall> walls;

    public bool isWalkable;
    public PathNode cameFromNode;
    public List<PathWall> Walls { get { return walls; } }

    public PathNode(PathGrid grid, int x, int y, bool isWalkable = true)
    {
        this.x = x; this.y = y;
        walls = new List<PathWall>();
        this.isWalkable = isWalkable;
    }

    public void CalcuateFCost() 
    {
        fCost = gCost + hCost;
    }
    public bool AddWall(PathWall wall)
    {

        foreach (PathWall iter in walls)
        {
            if (iter.Position == wall.Position) return false;
        }

        walls.Add(wall);
        return true;
    }
}
