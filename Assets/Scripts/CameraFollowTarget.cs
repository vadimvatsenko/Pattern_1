using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPos;
    [SerializeField] private Vector3 offsetPos;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float smooth = 0.2f;
    private Vector3 velocity = Vector3.zero;
    void Awake()
    {
    }

    
    private void LateUpdate()
    {
        target = GameObject.FindWithTag("Player");
        if (target != null) 
        {
            targetPos = target.transform.position + offsetPos;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smooth);
        }
        
    }
}
