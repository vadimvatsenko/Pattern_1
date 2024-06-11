using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dog : Animal
{
    private float speed = 10f;
    private int randomStep;
    private Rigidbody rb;
    [SerializeField] private Transform moveStep;
   
    private void Start()
    {
        randomStep = Random.Range(0, moveStep.transform.childCount);
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
       
        Debug.Log($"{moveStep.transform.GetChild(randomStep)} - {moveStep.transform.GetChild(randomStep).transform.position}");
        
    }

    public override void Movement()
    {

        rb.MovePosition(Vector3.MoveTowards(rb.transform.localPosition, moveStep.transform.GetChild(randomStep).localPosition, speed * Time.deltaTime));

        if (Vector2.Distance(rb.transform.localPosition, moveStep.transform.GetChild(randomStep).localPosition) < 0.2f)
        {
            randomStep = Random.Range(0, moveStep.transform.childCount);
        }
    }
}
