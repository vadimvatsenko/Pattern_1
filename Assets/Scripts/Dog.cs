using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dog : Animal
{
    private List<Vector3> _matrix;
    private Vector3 _randomStep;
    private Vector3 _direction;
    private Vector3 _clampPos;
    private Transform _catPos;

    private bool isPatrol = true;
    private bool isAttack = false;
    private bool isChase = false;
    public override void Start()
    {
        base.Start();
        _catPos = FindObjectOfType<Player>().transform;

        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        this.tag = "Enemy";
        _speed = 4f;
        _rb.mass = 5f;

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Dog/Dog"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию

        _matrix = MoveMatrix();
        SetRandomStep();
    }

    private void Update()
    {
        _clampPos = new Vector3(Mathf.Clamp(_rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard),
                                            _rb.position.y, 
                                Mathf.Clamp(_rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard));

        if (_catPos != null) 
        {
            if (Vector3.Distance(_rb.position, _catPos.position) < 7f)
            {
                isChase = true;
                isPatrol = false;
            }
            else
            {
                isChase = false;
                isPatrol = true;
            }
        }

        
    }

    private void FixedUpdate()
    {
        if (isChase)
        {
            ChaseCat();
        }
        if (isPatrol)
        {
            Movement();
        }
    }

    private void Movement()
    {
        _speed = 5f;
        _direction = (_randomStep - _rb.position).normalized;
        
        _rb.MovePosition(Vector3.MoveTowards(_clampPos, _randomStep, _speed * Time.fixedDeltaTime));

        _animator.SetBool("IsWalk", _direction != Vector3.zero);

        if (_direction != Vector3.zero)
        {
            Quaternion unitRotation = Quaternion.LookRotation(_direction);
            _rb.rotation = Quaternion.Lerp(_rb.rotation, unitRotation, Time.fixedDeltaTime * _speed);
        }
        if (Vector3.Distance(_rb.position, _randomStep) < 0.2f) SetRandomStep();        
    }

    private void ChaseCat()
    {
        if(_catPos != null)
        {
            _direction = (_catPos.position - _rb.position).normalized;
            _speed = 5.5f;
            if (Vector3.Distance(this.transform.position, _catPos.position) < 7f)
            {
                _speed = 6f;
                _rb.MovePosition(Vector3.MoveTowards(_clampPos, _catPos.position, _speed * Time.fixedDeltaTime));
                if (_direction != Vector3.zero)
                {
                    Quaternion unitRotation = Quaternion.LookRotation(_direction);
                    _rb.rotation = Quaternion.Lerp(_rb.rotation, unitRotation, Time.fixedDeltaTime * _speed);
                }
            }
            else if (Vector3.Distance(_rb.position, _catPos.position) > 7f)
            {
                isPatrol = true;
            }
        } else 
        {
            isPatrol = true;
        }
        
    }

    private List<Vector3> MoveMatrix()
    {
        List<Vector3> result = new List<Vector3>();
        for (float i = StaticFields.LeftBoard; i < StaticFields.RightBoard; i += 5)
        {
            for (float j = StaticFields.TopBoard; j < StaticFields.BottomBoard; j += 5)
            {
                result.Add(new Vector3(i, 0, j));
            }
        }

        return result;
    }

    private void SetRandomStep()
    {
        if (_matrix.Count > 0)
        {
            int randomIndex = Random.Range(0, _matrix.Count);
            _randomStep = _matrix[randomIndex];
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            SetRandomStep();
        }
    }
}
