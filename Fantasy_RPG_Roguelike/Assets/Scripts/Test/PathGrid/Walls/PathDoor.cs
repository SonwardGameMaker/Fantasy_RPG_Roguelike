using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDoor : PathWall, IInteractable, IThroughWalkable
{
    [SerializeField] const int apPenaltyCost = 0;

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

