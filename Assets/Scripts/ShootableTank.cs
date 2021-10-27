using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableTank : Tanks
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime=0.5f;
    protected void Shoot()
    {
        Instantiate(_projectile,_shootPoint.position,transform.rotation);
    }
}
