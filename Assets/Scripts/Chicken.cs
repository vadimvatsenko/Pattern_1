using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    private float _force;
    private Transform _catPos;
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

    private void FixedUpdate()
    {
        RunChicken();
    }

    private void RunChicken()
    {
        AnimalContactWithChickens(_catPos);
    }

    private void AnimalContactWithChickens(Transform animal)
    {
        _moveVector = (this.transform.localPosition - animal.localPosition).normalized;

        if ((Vector3.Distance(this.transform.localPosition, animal.transform.localPosition) < 3f))
        {
            _rb.AddForce(new Vector3(0, 0.2f, 0) + _moveVector * _force, ForceMode.Impulse);
            _animator.SetTrigger("jump");

            Quaternion unitRotation = Quaternion.LookRotation(_moveVector);
            _rb.MoveRotation(Quaternion.Lerp(_rb.rotation, unitRotation, Time.fixedDeltaTime * 30f));
        }

        float xClamp = Mathf.Clamp(this._rb.position.x, -_plane._planeWorldSize.x / 2 + 0.5f, _plane._planeWorldSize.x / 2 - 0.5f);
        float zClamp = Mathf.Clamp(this._rb.position.z, -_plane._planeWorldSize.z / 2 + 0.5f, _plane._planeWorldSize.z / 2 - 0.5f);

        _rb.MovePosition(new Vector3(xClamp, this._rb.position.y, zClamp));
    }
}
