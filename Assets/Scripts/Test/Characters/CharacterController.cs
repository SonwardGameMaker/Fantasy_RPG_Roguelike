using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class CharacterController : MonoBehaviour
{
    [SerializeField] PathGrid pathGrid;
    [SerializeField] float speed;

    float step;
    bool moving = false;
    int pathNodeNum;
    private List<PathNode> movePath;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        pathNodeNum = 0;
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) Moving();
    }

    public void StartMove(Vector3 targetPos)
    {
        if (!moving && CheckInGrid(targetPos))
        {
            movePath = pathGrid.FindPath(transform.position, targetPos);
            Debug.Log("Path count: "+movePath.Count);

            moving = true;
            target = new Vector3(movePath[pathNodeNum].x + 0.5f, movePath[pathNodeNum].y + 0.5f, 0.0f);
            Look(target);
        }
    }
    void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (transform.position.Equals(target))
        {
            pathNodeNum++;
            Debug.Log(pathNodeNum);
            if (pathNodeNum == movePath.Count)
            {
                moving = false;
                pathNodeNum = 0;
            }
            else
            {
                target = new Vector3(movePath[pathNodeNum].x + 0.5f, movePath[pathNodeNum].y + 0.5f, 0.0f);
                Look(target);
            }


        }
    }

    public void Look(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = Mathf.RoundToInt(angle / 45f) * 45f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }
    private bool CheckInGrid(Vector3 pos)
    {
        double x = pos.x;
        double y = pos.y;
        return (int)x < pathGrid.Width && (int)y < pathGrid.Height && (int)x >= 0 && (int)y >= 0;
    }
}
