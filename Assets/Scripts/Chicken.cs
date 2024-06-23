using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private Transform _catPos;
    public override void Start()
    {
        base.Start();
        _catPos = FindObjectOfType<Cat>().transform;
        this.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        _rb.mass = 0.1f;
    }

    private void Update()
    {
        RunChicken();
        
    }

    private void RunChicken()
    {
        if (Vector3.Distance(this._pos, _catPos.transform.position) < 1f)
        {
            Debug.Log("Run");
            _rb.AddForce(new Vector3(0, 0.1f, 0));
        }
    }
}
