using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : BaseObject, ISetDamage
{
    [SerializeField] int _health;

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public void SetDamage(int damage)
    {
        if (_health > 0)
        {
            _health -= damage;
        }

        if (_health <= 0)
        {
            _health = 0;
            Destroy(_GOInstance);
        }
    }
}
