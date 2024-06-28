using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chicken : Animal
{
    private Transform _catPos;
    private GameObject[] _dogsPos;
    private float _jumpForce;
    private float _enemyMaxDistance;
    public override void Start()
    {
        base.Start();

        if(FindObjectOfType<Cat>() != null)
        {
            _catPos = FindObjectOfType<Cat>().transform;
        }
        
        _dogsPos = GameObject.FindGameObjectsWithTag("Enemy");
        
        this.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        this._collader.center = new Vector3(0f, 0.5f, 0f);

        _jumpForce = 0.25f;
        _rb.mass = 0.1f;
        _enemyMaxDistance = 3f;

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Chicken/Chicken"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию
    }

    private void FixedUpdate()
    {
        RunChicken();
        
    }

    private void RunChicken()
    {
        if(_catPos != null)
        {
            AnimalContactWithChickens(_catPos);
        }

        if (_dogsPos != null)
        {
            foreach (GameObject d in _dogsPos)
            {
                AnimalContactWithChickens(d.transform);
            }
        }        
    }

    private void AnimalContactWithChickens(Transform animal)
    {
        _moveVector = (this.transform.localPosition - animal.transform.localPosition).normalized;
        if ((Vector3.Distance(this.transform.localPosition, animal.transform.localPosition) < _enemyMaxDistance))
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0) + _moveVector, ForceMode.Impulse);
            _animator.SetTrigger("jump");

            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);
            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.fixedDeltaTime * 30f));
        }

        float xClamp = Mathf.Clamp(_rb.position.x, StaticFields.LeftBoard, StaticFields.RightBoard);
        float zClamp = Mathf.Clamp(_rb.position.z, StaticFields.TopBoard, StaticFields.BottomBoard);

        _rb.MovePosition(new Vector3(xClamp, _rb.position.y, zClamp));
    }
}
