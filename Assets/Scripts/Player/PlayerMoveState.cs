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
        
    }

    private void Movement()
    {
        /*Vector3 forward = _camera.transform.forward; // направление камеры вперёд
        Vector3 right = _camera.transform.right; // направление камеры в право

        forward.y = 0f; // Убираем компоненту по оси Y, чтобы движение было только по X и Z
        right.y = 0f;
        *//*
                forward.Normalize(); // нормализуем вектора 
                right.Normalize();*//*

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _moveVector = (horizontal * right) + (vertical * forward).normalized;

        float xClamp = Mathf.Clamp(this._rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard);
        float zClamp = Mathf.Clamp(this._rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard);

        _animator.SetBool("IsWalk", Mathf.Abs(_moveVector.x) > 0.1f || Mathf.Abs(_moveVector.z) > 0.1f);

        if (_moveVector != Vector3.zero)
        {
            _rb.MovePosition(new Vector3(xClamp, _rb.position.y, zClamp) + _moveVector * _speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);

            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * _speed));
        }*/
    }
}
