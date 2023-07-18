using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSmallGate : PathWall, IInteractable, IThroughWalkable
{
    [SerializeField] bool opened;
    [SerializeField] int apPenaltyCost = 0;
    

    public bool Opened { get { return opened; } }

    public void Interact()
    {
        opened = !opened;
    }

    public int GetPenaltyCost()
    {
        if (opened) return 0;
        else return apPenaltyCost;
    }
}
