using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGrid : MonoBehaviour
{
    [SerializeField] private PathGrid grid;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMousePositionInWorld();
            for (int i = 0; i < grid.GetNode(mousePosition.x, mousePosition.y).Walls.Count; i++)
            {
                Debug.Log("Wall: " + grid.GetNode(mousePosition.x, mousePosition.y).Walls[i].Position);
            }
        }
    }

    Vector3 GetMousePositionInWorld()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; // заздалегідь встановити z-координату для створення вірної позиції у світі
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
