using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat : Animal
{
    private bool isJump = true;
    public override void Start()
    {
        base.Start();
        speed = 5f;
        _pos = new Vector3(0f, 5f, 0f);
        this.transform.position = _pos;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Player";
        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Cat/Cat"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию
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
        _moveVector = new Vector3(Input.GetAxis("Horizontal"), _moveVector.y, Input.GetAxis("Vertical"));

        float xClamp = Mathf.Clamp(this._rb.position.x, -_plane._planeWorldSize.x / 2 + 0.5f, _plane._planeWorldSize.x / 2 - 0.5f);
        float zClamp = Mathf.Clamp(this._rb.position.z, -_plane._planeWorldSize.z / 2 + 0.5f, _plane._planeWorldSize.z / 2 - 0.5f);

        _animator.SetBool("IsWalk", Mathf.Abs(_moveVector.x) > 0.1f || Mathf.Abs(_moveVector.z) > 0.1f);

        if (_moveVector != Vector3.zero) 
        {
            _moveVector = _moveVector.normalized;
     
            _rb.MovePosition(new Vector3(xClamp, this._rb.position.y, zClamp) + _moveVector * speed * Time.deltaTime);

            Quaternion unitRotation = Quaternion.LookRotation(new Vector3(_moveVector.x, _moveVector.y, _moveVector.z));
            
            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * speed));
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
