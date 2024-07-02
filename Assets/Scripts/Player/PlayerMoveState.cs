using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Movement();
        if (_player._input == Vector3.zero) 
        {
            _stateMachine.ChangeState(_player._idleState);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _stateMachine.ChangeState(_player._dashState);
        }

    }

    private void Movement()
    {
        Vector3 forward = _mainCamera.transform.forward; // ����������� ������ �����
        Vector3 right = _mainCamera.transform.right; // ����������� ������ � �����

        forward.y = 0f; // ������� ���������� �� ��� Y, ����� �������� ���� ������ �� X � Z
        right.y = 0f;
     
        _moveVector = (_player._input.x * right) + (_player._input.z * forward).normalized; // _moveVector ��� ������� ��������� ??? 

            _player._rb.MovePosition(new Vector3(_player._xClamp, _player._rb.position.y, _player._zClamp) + _moveVector * _player._speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);

            _player._rb.MoveRotation(Quaternion.Lerp(_player._rb.rotation, unitRotation, Time.deltaTime * _player._speed));
        
    }
}
