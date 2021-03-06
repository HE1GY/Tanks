using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //??????? ???? ??????????? ???????? RB ?? ????? ? ??? ????????
public abstract class Tanks : MonoBehaviour
{
    [SerializeField] private int _maxHealth=30;
    [SerializeField] protected float _movementSpeed=3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 7f;
    [SerializeField] private int _point = 0;
    protected Rigidbody2D _rigidbody;
    protected int _currentHealth;
    protected UI _ui;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody= GetComponent<Rigidbody2D>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            Stats.Score += _point;
            _ui.UpdateScoreAndLevel();
        }
    }

   protected abstract void Move();
    protected void SetAngle(Vector3 target)//??? ???????? ??????
    {
        Vector3 deltaPosition = target - transform.position; //?????? ??? ????
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;//??? ? ????????
        Quaternion angle = Quaternion.Euler(0f, 0f, angleZ + _angleOffset);//????? ??? 
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed);//?????? ????????
    }
}
