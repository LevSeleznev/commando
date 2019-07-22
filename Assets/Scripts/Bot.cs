using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class Bot : Unit
{
    private readonly int _activeDistance = 10;
    private readonly int _stoppingDistance = 2;
    private bool _isTarget;
    private bool _isDeath;
    private Transform _target;
    private NavMeshAgent _agent;
    private ThirdPersonCharacter _thirdCharCntrl;

    public Transform _playerPos;

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _thirdCharCntrl = GetComponent<ThirdPersonCharacter>();

        _isDeath = false;
        Health = 100;
        SetTarget(_playerPos);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    void Update()
    {
        if (_agent)
        {
            _agent.SetDestination(Target.position);
        }
    }
}
