using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public Transform[] ObserveLocation => _observeLocation;
    
    [SerializeField] private Transform[] _observeLocation;
    [SerializeField] private NavMeshAgent _agent;
    public float DetectionRange = 5f;
    public float AttackRange = 2f;
    
    private State _currentState;

    private void Start()
    {
        _currentState = new Roaming(this, _agent);

        PlayerController.Instance.TakeDamage(_atkDamage);
    }

    private void Update()
    {
        _currentState = _currentState.Process();
    }
}
