using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private float _force;
    private Transform _catPos;
    private Transform _dogPos;
    public override void Start()
    {
        base.Start();
        _catPos = FindObjectOfType<Cat>().transform;
      
        this.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        this._collader.center = new Vector3(0f, 0.5f, 0f);
        _force = 0.25f;
        _rb.mass = 0.1f;

        _animatorController = Resources.Load<RuntimeAnimatorController>("Animation/Chicken/Chicken"); // получаем контроллер анимации
        _animator.runtimeAnimatorController = _animatorController; // добавляемым контроллер а анимацию
    }

    private void Update()
    {
        RunChicken();

    }

    private void RunChicken()
    {
        _moveVector = (this.transform.localPosition - _catPos.transform.localPosition);

        //_rb.MovePosition(new Vector3(xClamp, 0.2f, zClamp));

        if ((Vector3.Distance(this.transform.localPosition, _catPos.transform.localPosition ) < 3f))
        {
            _rb.AddForce(new Vector3(0, 0.2f, 0) + _moveVector * _force, ForceMode.Impulse);
            Debug.Log(new Vector3(0, 0.2f, 0) + _moveVector);
            _animator.SetTrigger("jump");


            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);
            
            _rb.rotation = Quaternion.Lerp(_rb.rotation, unitRotation, Time.deltaTime * 5f);
        }

        float xClamp = Mathf.Clamp(this._rb.position.x, -_plane._planeWorldSize.x / 2 + 0.5f, _plane._planeWorldSize.x / 2 - 0.5f);
        float zClamp = Mathf.Clamp(this._rb.position.z, -_plane._planeWorldSize.z / 2 + 0.5f, _plane._planeWorldSize.z / 2 - 0.5f);

        _rb.position = new Vector3(xClamp, this._rb.position.y, zClamp);
    }
}
