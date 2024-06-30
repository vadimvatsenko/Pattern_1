using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    protected Rigidbody _rb;
    private string _animBoolName;

    protected float horizontal;
    private float vertical;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        _player._animator.SetBool(_animBoolName, true);
        _rb = _player._rb;
    }

    public virtual void Update()
    {
        Debug.Log($"I am in {_animBoolName}");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    public virtual void Exit() 
    {
        _player._animator.SetBool( _animBoolName, false);
    }
}
