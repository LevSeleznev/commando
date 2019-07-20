using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private int _curDamage;
    [SerializeField] private float _destructTime = 20;

    public float Force { get; set; }
    public Transform gunT { get; set; }

    /// <summary>
    /// debug
    /// </summary>
    LineRenderer line;
    Vector3 startPos;

    protected override void Awake()
    {
        base.Awake();
        Destroy(_GOInstance, _destructTime);
        line = GetComponent<LineRenderer>();
        if (line != null)
        {
            line.SetWidth(0.02f, 0.02f);
        }
        _curDamage = _damage;
        startPos = Position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            return;
        }
        SetDamage(collision.gameObject.GetComponent<ISetDamage>());
        Destroy(_GOInstance);
    }

    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
        {
            obj.SetDamage(_curDamage);
        }
    }

    void Update()
    {
        line.SetPosition(0, startPos);
        line.SetPosition(1, Position);
        //GetRB.AddForce(gunT.forward * Force, ForceMode.Force);
    }
}
