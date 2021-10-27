using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    private float _timer;
    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;   //��� ���������� ������������ �������
    }
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHP(_currentHealth);
        if (_currentHealth<=0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// ������������ ���� �����
        }

    }
    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));//���������� ����� �� ����� � ������������ � ����� ���������
        if (_timer<=0)
        {
            if (Input.GetMouseButton(0))//������� ��� ������ ����
            {
                Shoot();
                _timer = _reloadTime;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
        
    }
}
