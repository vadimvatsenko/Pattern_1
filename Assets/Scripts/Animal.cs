using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Animal: MonoBehaviour
{
    private protected Plane _plane;
    private protected float _speed;
    private protected Rigidbody _rb;
    private protected Animator _animator;
    private protected RuntimeAnimatorController _animatorController;
    private protected BoxCollider _collader;
    private protected Vector3 _moveVector;
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
