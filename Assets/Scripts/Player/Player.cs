using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Animal
{
    #region Components
    public Camera _mainCamera { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine _stateMachine { get; private set; }
    public PlayerIdleState _idleState { get; private set; }
    public PlayerMoveState _moveState { get; private set; }
    public PlayerJumpState _jumpState { get; private set; }
    public PlayerDashState _dashState { get; private set; }
    public PlayerDeadState _deathState { get; private set; }
    #endregion

    #region ClampPosition and Inputs
    public float _xClamp {  get; private set; }
    public float _zClamp { get; private set; }
    public Vector3 _input;
    #endregion

    private void Awake()
    {
        _stateMachine = new PlayerStateMachine();
        _idleState = new PlayerIdleState(this, _stateMachine, PlayerStaticFields.Idle);
        _moveState = new PlayerMoveState(this, _stateMachine, PlayerStaticFields.Move);
        _jumpState = new PlayerJumpState(this, _stateMachine, PlayerStaticFields.Jump);
        _dashState = new PlayerDashState(this, _stateMachine, PlayerStaticFields.Dash);
        _deathState = new PlayerDeadState(this, _stateMachine, PlayerStaticFields.Death);        
    }

    public override void Start()
    {
        base.Start();
        _stateMachine.Initialize(_idleState);

        _speed = 5f;

        _pos = new Vector3(0f, 5f, 0f);
        this.transform.position = _pos;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Player";

        _animatorController = Resources.Load<RuntimeAnimatorController>(PlayerStaticFields.AnimationPath); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию
    }

    private void Update()
    {
        _stateMachine._currentState.Update();

        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _xClamp = Mathf.Clamp(_rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard);
        _zClamp = Mathf.Clamp(_rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard);
       
    }

    

    public void Deconstruct(out Vector3 input, out float xClamp, out float zClamp, out List<PlayerState> states)
    {
        input = _input;
        xClamp = _xClamp;
        zClamp = _zClamp;
        states = new List<PlayerState>()
        {
            _idleState,
            _moveState,
            _jumpState,
            _dashState,
            _deathState,
        };
    }
}

