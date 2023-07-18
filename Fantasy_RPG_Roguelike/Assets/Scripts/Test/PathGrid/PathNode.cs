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
    public List<PathWall> walls;

    public bool isWalkable;
    public PathNode cameFromNode;

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

}
