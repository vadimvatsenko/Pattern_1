using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dog : Animal
{
    
    private int randomStep;
    private Rigidbody rb;
    [SerializeField] private Transform moveStep;
   
    private void Start()
    {
        speed = 10f;
        randomStep = Random.Range(0, moveStep.transform.childCount);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
       
        Debug.Log($"{moveStep.transform.GetChild(randomStep)} - {moveStep.transform.GetChild(randomStep).transform.position}");
        
    }

    private void Movement()
    {

        rb.MovePosition(moveStep.transform.GetChild(randomStep).position * speed * Time.deltaTime);

        if (Vector2.Distance(rb.transform.position, moveStep.transform.GetChild(randomStep).localPosition) < 0.2f)
        {
            randomStep = Random.Range(0, moveStep.transform.childCount);
        }
    }
}
