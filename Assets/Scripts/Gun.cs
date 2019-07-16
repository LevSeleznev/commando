using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : BaseWeapon
{
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if (_bullet)
        {
            Bullet tempbullet = Instantiate(_bullet, _gunT.position, _gunT.rotation) as Bullet;
            if (tempbullet)
            {
                tempbullet.gunT = _gunT;
                tempbullet.Force = _force;
                tempbullet.name = "buller";
            }
        }
    }
}
