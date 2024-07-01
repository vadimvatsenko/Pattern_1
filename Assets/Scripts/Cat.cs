using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : Animal
{
    Camera _mainCamera;
    private float _dathTime;
    private bool isJump = true;
    private bool isDead = false;
    public override void Start()
    {
        base.Start();

        _mainCamera = Camera.main;
        _speed = 5f;
        _dathTime = 3f;
        _pos = new Vector3(0f, 5f, 0f);

        this.transform.position = _pos;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Player";

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Cat/Cat"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию
    }

    private void Update()
    {
       _dathTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            Jump();
            isJump = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && _dathTime <= 0)
        {
            Dash();
            _dathTime = 3f;
        }

    }

    private void Dash()
    {
        _rb.AddForce(_moveVector * 10f, ForceMode.Impulse);
    }

    private void Movement()
    {
        Vector3 forward = _mainCamera.transform.forward; // направление камеры вперёд
        Vector3 right = _mainCamera.transform.right; // направление камеры в право

        forward.y = 0f; // Убираем компоненту по оси Y, чтобы движение было только по X и Z
        right.y = 0f;

        forward.Normalize(); // нормализуем вектора 
        right.Normalize();

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
        }
    }

    private void Jump()
    {
        _rb.AddForce(new Vector3(0f, 5f, 0f) + _moveVector, ForceMode.Impulse);
        _animator.SetTrigger("jump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Plane>())
        {
            isJump = true;
        }

        if(collision.gameObject.GetComponent<Dog>())
        {
            isDead = true;
            CatDeath();
        }        
    }

    private void  CatDeath()
    {
        Events.InvokeGameReset(gameObject);
    }
}
