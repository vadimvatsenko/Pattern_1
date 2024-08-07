using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    public Vector3 _moveVector {  get; protected set; }
    private string _animBoolName;


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
        _moveVector = _player._moveVector;
        _mainCamera = Camera.main;        
    }

    public virtual void Update()
    {
        //Debug.Log($"I am in {_animBoolName}");

        (Vector3 input, float xClamp, float zClamp, Dictionary<States, PlayerState> states) = _player; // ��� ����� ��������?

        

        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            _stateMachine.ChangeState( _player._dashState);
        }

        if (input != Vector3.zero)
        {
            _stateMachine.ChangeState(states["MOVE"]);
        }
    }

    public virtual void Exit() 
    {
        _player._animator.SetBool( _animBoolName, false);
    }
}
