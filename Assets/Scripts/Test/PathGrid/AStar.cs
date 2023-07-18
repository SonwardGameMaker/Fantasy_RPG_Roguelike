using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    PathGrid grid;
    List<PathNode> openList;
    List<PathNode> closedList;

    public AStar(PathGrid grid)
    {
        this.grid = grid;
    }

    public List<PathNode> FindPath(PathNode startNode, PathNode endNode)
    {
        if (!endNode.isWalkable) { return new List<PathNode> { startNode }; }
        if (startNode == endNode) { return new List<PathNode>() { startNode }; }

        openList = new List<PathNode>() { startNode };
        closedList = new List<PathNode>();
        
        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                PathNode node = grid.GetNode(x, y);
                node.gCost = int.MaxValue;
                node.CalcuateFCost();
                node.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalcuateFCost();

        while (openList.Count > 0)
        {
            PathNode currentNode = GetTheLowestCostNode(openList);
            if (currentNode == endNode) { return CalculatePath(endNode); }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbour in GetNeigbours(currentNode))
            {
                if (closedList.Contains(neighbour)) continue;
                if (!neighbour.isWalkable)
                {
                    closedList.Add(neighbour);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbour);
                if (tentativeGCost > currentNode.gCost)
                {
                    neighbour.cameFromNode = currentNode;
                    neighbour.gCost = tentativeGCost;
                    neighbour.hCost = CalculateDistanceCost(neighbour, endNode);
                    neighbour.CalcuateFCost();

                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }

        return null;
    }

    private List<PathNode> GetNeigbours(PathNode currentNode)
    {
        List<PathNode> neigbours = new List<PathNode>();

        if (currentNode.x - 1 >= 0)
        {
            neigbours.Add(grid.GetNode(currentNode.x - 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neigbours.Add(grid.GetNode(currentNode.x - 1, currentNode.y - 1));
            if (currentNode.y + 1 < grid.Height) neigbours.Add(grid.GetNode(currentNode.x - 1, currentNode.y + 1));
        }
        if (currentNode.x + 1 < grid.Width)
        {
            neigbours.Add(grid.GetNode(currentNode.x + 1, currentNode.y));
            if (currentNode.y - 1 >= 0) neigbours.Add(grid.GetNode(currentNode.x + 1, currentNode.y - 1));
            if (currentNode.y + 1 < grid.Height) neigbours.Add(grid.GetNode(currentNode.x + 1, currentNode.y + 1));
        }
        if (currentNode.y - 1 >= 0) neigbours.Add(grid.GetNode(currentNode.x, currentNode.y - 1));
        if (currentNode.y + 1 < grid.Height) neigbours.Add(grid.GetNode(currentNode.x, currentNode.y + 1));

        return neigbours;
    }
    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();

        return path;
    }
    private int CalculateDistanceCost(PathNode nodeA, PathNode nodeB)
    {
        int dx = Mathf.Abs(nodeA.x - nodeB.x);
        int dy = Mathf.Abs(nodeA.y - nodeB.y);
        int remaining = Mathf.Abs(dx - dy);
        return MOVE_DIAGONAL_COST * Mathf.Min(dx, dy) + MOVE_STRAIGHT_COST * remaining;
    }
    private PathNode GetTheLowestCostNode(List<PathNode> nodeList)
    {
        PathNode lowerCost = nodeList[0];
        foreach (PathNode iter in nodeList)
        {
            if (iter.fCost < lowerCost.fCost)
            {
                lowerCost = iter;
            }
        }

        return lowerCost;
    }
}
