using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal: MonoBehaviour
{
    protected string name { get; private set; }

    public abstract void Movement();
}
