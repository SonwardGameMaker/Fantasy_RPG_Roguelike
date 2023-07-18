using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFence : PathWall, IThroughWalkable
{
    [SerializeField] int apPenaltyCost;

    public int GetPenaltyCost()
    {
        return apPenaltyCost;
    }
}

