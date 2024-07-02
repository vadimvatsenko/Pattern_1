using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

        Debug.Log(_player._rb == true);

        /*_rb.position = new Vector3(_player._xClamp, _player._rb.position.y, _player._zClamp);*/

        if (_player._input != Vector3.zero) 
        {
            _stateMachine.ChangeState(_player._moveState);
        }
    }
}
