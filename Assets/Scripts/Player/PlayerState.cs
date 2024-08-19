using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;

    public Vector3 _moveVector { get; protected set; }
    private string _animBoolName;
    public Camera _mainCamera;

    protected Player _player;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;

    }

    public virtual void Enter()
    {
        _player._animator.SetBool(_animBoolName, true);
        _moveVector = _player._moveVector;
        _mainCamera = Camera.main;
    }

    public virtual void Update()
    {
        //Debug.Log($"I am in {_animBoolName}");
        //Debug.Log(_player._rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _stateMachine.ChangeState(_player._dashState);
            //_player._rb.AddForce(_moveVector * 10f, ForceMode.Impulse);
        }
    }

    public virtual void Exit()
    {
        _player._animator.SetBool(_animBoolName, false);
    }
}
