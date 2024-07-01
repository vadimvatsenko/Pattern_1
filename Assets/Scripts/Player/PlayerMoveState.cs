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
        if (_input == Vector3.zero) 
        {
            _stateMachine.ChangeState(_player._idleState);
        }
        
    }

    private void Movement()
    {
        Vector3 forward = _mainCamera.transform.forward; // ����������� ������ �����
        Vector3 right = _mainCamera.transform.right; // ����������� ������ � �����

        forward.y = 0f; // ������� ���������� �� ��� Y, ����� �������� ���� ������ �� X � Z
        right.y = 0f;
     
        _moveVector = (_input.x * right) + (_input.z * forward).normalized; // _moveVector ��� ������� ��������� ??? 

        float xClamp = Mathf.Clamp(this._rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard);
        float zClamp = Mathf.Clamp(this._rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard);

        if (_moveVector != Vector3.zero)
        {
            _rb.MovePosition(new Vector3(xClamp, _rb.position.y, zClamp) + _moveVector * _player._speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);

            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * _player._speed));
        }
    }
}
