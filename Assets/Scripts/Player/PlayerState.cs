using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    protected Rigidbody _rb;
    public Vector3 _moveVector {  get; protected set; }
    private string _animBoolName;

    protected Vector3 _input;
    public Camera _mainCamera;
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
        _moveVector = _player._moveVector;
        _mainCamera = Camera.main;
    }

    public virtual void Update()
    {
        Debug.Log($"I am in {_animBoolName}");

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _input = new Vector3(horizontal, 0, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateMachine.ChangeState(_player._jumpState);
        }

        if (_input != Vector3.zero)
        {
            _stateMachine.ChangeState(_player._moveState);
        }
    }

    public virtual void Exit() 
    {
        _player._animator.SetBool( _animBoolName, false);
    }
}
