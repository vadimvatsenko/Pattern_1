using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFields : MonoBehaviour
{
    GameObject _plane;
    public static float LeftBoard;
    public static float RightBoard;
    public static float TopBoard;
    public static float BottomBoard;
    void Start()
    {
        _plane = GameObject.FindWithTag("Map");
        LeftBoard = _plane.GetComponent<Plane>()._planeWorldSize.x * -1f / 2 + 0.5f;
        RightBoard = _plane.GetComponent<Plane>()._planeWorldSize.x / 2 - 0.5f;
        TopBoard = _plane.GetComponent<Plane>()._planeWorldSize.z * -1f / 2 + 0.5f;
        BottomBoard = _plane.GetComponent<Plane>()._planeWorldSize.z / 2 - 0.5f;
    }
}
