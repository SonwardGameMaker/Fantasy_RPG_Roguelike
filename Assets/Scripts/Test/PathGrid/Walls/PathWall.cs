using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallPosition { Left, Down, Rght, Up }
public class PathWall : MonoBehaviour
{
    [SerializeField] protected WallPosition position;
    [SerializeField] protected bool throughWalkable;
    public WallPosition Position
    {
        get { return position; }
        set
        { 
            // TODO
            if (position != value)
            {
                position = value;
                GetComponent<WallObj>().OnWallPositionChanged(value);
            }
        }
    }
    public bool ThroughWalkable { get { return throughWalkable; } }

}
