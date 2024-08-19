using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Jump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        OnGroundDetected();
    }

    private void Jump()
    {
        _player._rb.AddForce(new Vector3(0f, 5f, 0f) + _moveVector, ForceMode.Impulse);
    }

    private void OnGroundDetected()
    {
        Ray ray = new Ray(this._player.transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.05f))
        {
            _stateMachine.ChangeState(_player._idleState);
        }
    }
}
