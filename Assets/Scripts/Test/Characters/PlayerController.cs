using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(GetMousePositionInWorld());
            GetComponent<CharacterController>().StartMove(GetMousePositionInWorld());
        }
    }

    Vector3 GetMousePositionInWorld()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; // ���������� ���������� z-���������� ��� ��������� ���� ������� � ���
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
