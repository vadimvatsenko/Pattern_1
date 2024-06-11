using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform cat;
    void Start()
    {
        //cat = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(cat.position.x, transform.position.y, cat.position.z);
    }
}
