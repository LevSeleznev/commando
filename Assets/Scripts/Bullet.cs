using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _destructTime = 20;

    public float Force { get; set; }
    public Transform gunT { get; set; }

    protected override void Awake()
    {
        base.Awake();
        Destroy(_GOInstance, _destructTime);
    }
    void Update()
    {
        GetRB.AddForce(gunT.forward * Force, ForceMode.Force);
    }
}
