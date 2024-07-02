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
              
    }

    private void Jump()
    {
        _player._rb.AddForce(new Vector3(0f, 5f, 0f) + _moveVector, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Plane>())
        {
            isJump = true;
        }

        if (collision.gameObject.GetComponent<Dog>())
        {
            isDead = true;
            CatDeath();
        }
    }


}
