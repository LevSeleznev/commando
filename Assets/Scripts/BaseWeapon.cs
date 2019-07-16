using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseObject
{
    [SerializeField] protected Transform _gunT;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected float _force = 300;

    public abstract void Fire();

    protected virtual void Update()
    {
        
    }
}
