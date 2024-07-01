using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Animal: MonoBehaviour
{
    private protected Plane _plane;
    public float _speed { get; protected set; }
    public Rigidbody _rb { get; private set; }
    public  Animator _animator { get; private set; }
    private protected RuntimeAnimatorController _animatorController;
    private protected BoxCollider _collader;
    public Vector3 _moveVector { get; protected set; }
    private protected Vector3 _pos;


    public virtual void Start()
    {
        _plane = FindObjectOfType<Plane>();
        _rb = this.AddComponent<Rigidbody>();
        _animator = this.AddComponent<Animator>();
        _collader = this.AddComponent<BoxCollider>();
        _rb.freezeRotation = true;
    }  
}
