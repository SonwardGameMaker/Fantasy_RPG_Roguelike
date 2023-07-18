using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWindow : PathWall, IInteractable, IThroughWalkable
{
    [SerializeField] int apPenaltyCost;
    
    public void Interact()
    {
        throughWalkable = !throughWalkable;
    }

    public int GetPenaltyCost()
    {
        if (throughWalkable) return apPenaltyCost;
        else return int.MaxValue; //TODO
    }
}
