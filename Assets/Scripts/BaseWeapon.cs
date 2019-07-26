using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseObject
{
    [SerializeField] protected Transform _gunT;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected float _force = 300;

    protected Timer _rechargeTimer = new Timer();
    protected bool _fire = true;

    public abstract void Fire();
    public abstract void Reload();

    protected virtual void Update()
    {
        _rechargeTimer.Update();
        if (_rechargeTimer.IsEvent())
        {
            _fire = true;
        }
    }
}
