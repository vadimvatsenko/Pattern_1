using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    [SerializeField] MeshFilter field;
    private Rigidbody rb;
    private Animator animator;
    Vector3 moveVector;
    private float speed = 5f;
    private bool isWalk = false;
    Transform pos;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
    }

    public void StartPos(Vector3 pos)
    {
        transform.position = pos;
    }

    
    void Update()
    {
        Movement();       
    }
    private void Movement()
    {
        /*moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");*/

        moveVector = new Vector3(Input.GetAxis("Horizontal"), moveVector.y, Input.GetAxis("Vertical"));

        if (moveVector! != Vector3.zero) 
        {
            //animator.SetFloat("Walk", Mathf.Abs(moveVector);

            moveVector = moveVector.normalized;
            rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(moveVector);

            rb.rotation = Quaternion.Lerp(rb.rotation, unitRotation, Time.deltaTime * speed);
        }
        
    }

    
}
