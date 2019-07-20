using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Unit
{
    private bool _isDeath;

    protected override void Awake()
    {
        base.Awake();
        _isDeath = false;
        Health = 100;
    }

    void Update()
    {
        
    }
}
