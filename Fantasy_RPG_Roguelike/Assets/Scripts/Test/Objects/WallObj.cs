using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObj : MonoBehaviour
{
    public void OnWallPositionChanged(WallPosition wallPosition)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, ((float)wallPosition) * 90f + 180f);
    }
}
