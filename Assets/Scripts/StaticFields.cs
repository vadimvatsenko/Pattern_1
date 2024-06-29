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

    public static string FlowersPath => "Prefabs/Flower";
    public static string FlowersHolder => "Flowers";
    public static string Trees1Path => "Prefabs/Tree1";
    public static string Trees1Holder => "Trees1";
    public static string Trees2Path = "Prefabs/Tree2";
    public static string Trees2Holder = "Trees2";

    void Start()
    {
        _plane = FindAnyObjectByType<Plane>().gameObject;
        LeftBoard = _plane.GetComponent<Plane>()._planeWorldSize.x * -1f / 2 + 0.5f;
        RightBoard = _plane.GetComponent<Plane>()._planeWorldSize.x / 2 - 0.5f;
        TopBoard = _plane.GetComponent<Plane>()._planeWorldSize.z * -1f / 2 + 0.5f;
        BottomBoard = _plane.GetComponent<Plane>()._planeWorldSize.z / 2 - 0.5f;
    }
}
