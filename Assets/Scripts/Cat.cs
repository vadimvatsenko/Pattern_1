using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : Animal
{
    Camera _mainCamera;
    private bool isJump = true;
    private bool isDead = false;
    public override void Start()
    {
        base.Start();

        _mainCamera = Camera.main;
        _speed = 5f;
        _pos = new Vector3(0f, 5f, 0f);

        this.transform.position = _pos;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Player";

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Cat/Cat"); // �������� ���������� ��������
        _animator.runtimeAnimatorController = _animatorController; // ����������� ���������� � ��������
    }
    
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && isJump)
        {
            Jump();
            isJump = false;
        }
       
    }
    private void Movement()
    {
        Vector3 forward = _mainCamera.transform.forward; // ����������� ������ �����
        Vector3 right = _mainCamera.transform.right; // ����������� ������ � �����

        forward.y = 0f; // ������� ���������� �� ��� Y, ����� �������� ���� ������ �� X � Z
        right.y = 0f;

        forward.Normalize(); // ����������� ������� 
        right.Normalize();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _moveVector = (horizontal * right) + (vertical * forward).normalized;

        float xClamp = Mathf.Clamp(this._rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard);        
        float zClamp = Mathf.Clamp(this._rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard);

        _animator.SetBool("IsWalk", Mathf.Abs(_moveVector.x) > 0.1f || Mathf.Abs(_moveVector.z) > 0.1f);

        if (_moveVector != Vector3.zero) 
        {
            _rb.MovePosition(new Vector3(xClamp, this._rb.position.y, zClamp) + _moveVector * _speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(new Vector3(_moveVector.x, _moveVector.y, _moveVector.z));

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
        if (collision.gameObject.tag == "Map")
        {
            isJump = true;
        }
        
    }
}
