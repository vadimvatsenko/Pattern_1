using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dog : Animal
{
    private List<Vector3> _matrix;
    private Vector3 _randomStep;
    public Vector3 _direction { get; private set; }
    private Transform _catPos;
    private Transform _dogsParent;
    public override void Start()
    {
        base.Start();
        _dogsParent = new GameObject("Dogs").transform;
        this.transform.SetParent(_dogsParent);
        _catPos = FindObjectOfType<Cat>().transform;
        speed = 10f;
        this._collader.size = new Vector3(0.71f, 1.64f, 1.54f);
        this._collader.center = new Vector3(0f, 0.86f, 0f);
        this.tag = "Enemy";
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        _rb.mass = 5f;

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Dog/Dog"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию

        _matrix = MoveMatrix();
        SetRandomStep();
    }
    void Update()
    {
        Movement();
        
    }

    private void Movement()
    {
        _direction = (_randomStep - transform.position).normalized;
        _rb.MovePosition(Vector3.MoveTowards(transform.position, _randomStep, speed * Time.deltaTime));

        _animator.SetBool("IsWalk", _direction != Vector3.zero);

        if (_direction != Vector3.zero)
        {
            Quaternion unitRotation = Quaternion.LookRotation(_direction);
            _rb.rotation = Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * speed);
        }
        if (Vector3.Distance(this.transform.position, _randomStep) < 0.2f) SetRandomStep();

        /*if (Vector3.Distance(this.transform.position, _catPos.transform.position) < 2f)
        {
            _rb.MovePosition(Vector3.MoveTowards(this.transform.position, _catPos.transform.position, speed * 1.5f * Time.deltaTime));
        }*/
    }

    private List<Vector3> MoveMatrix()
    {
        List<Vector3> result = new List<Vector3>();
        for (float i = -_plane._planeWorldSize.x / 2 + 0.5f; i < _plane._planeWorldSize.x / 2 - 0.5f; i += 5)
        {
            for (float j = -_plane._planeWorldSize.z / 2 + 0.5f; j < _plane._planeWorldSize.z / 2 - 0.5f; j += 5)
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
        if (collision != null) 
        {
            SetRandomStep();
        }
    }
}
