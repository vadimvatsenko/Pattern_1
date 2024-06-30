using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal
{
    #region Components
    Camera _mainCamera;
    #endregion
    #region States
    public PlayerStateMachine _stateMachine { get; private set; }
    public PlayerIdleState _idleState { get; private set; }
    public PlayerMoveState _moveState { get; private set; }
    public PlayerJumpState _jumpState { get; private set; }
    public PlayerDeadState _deathState { get; private set; }
    #endregion

    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();
        _idleState = new PlayerIdleState(this, _stateMachine, PlayerStaticFields.Idle);
        _moveState = new PlayerMoveState(this, _stateMachine, PlayerStaticFields.Move);
        _jumpState = new PlayerJumpState(this, _stateMachine, PlayerStaticFields.Jump);
        _deathState = new PlayerDeadState(this, _stateMachine, PlayerStaticFields.Death);        
    }

    public override void Start()
    {
        base.Start();
        _stateMachine.Initialize(_idleState);

        _pos = new Vector3(0f, 5f, 0f);
        this.transform.position = _pos;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Player";

        _animatorController = Resources.Load<RuntimeAnimatorController>(PlayerStaticFields.AnimationPath); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию

        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _stateMachine._currentState.Update();


    }
}
