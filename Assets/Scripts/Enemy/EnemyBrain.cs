using System;
using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolMovement))]
public class EnemyBrain : MonoBehaviour
{
    private EnemyPatrolMovement _patrolMovement;
    private IMovementType _activeMovement;
    private IMovementType ActiveMovement
    {
        get => _activeMovement;

        set
        {
            if (value != _activeMovement)
            {
                _activeMovement?.ResetMovement();
                OnMovementChange?.Invoke();
            }

            _activeMovement = value;
        }
    }

    public Vector3 Direction => ActiveMovement.Direction;
    public float Speed => ActiveMovement.Speed;

    public event Action OnMovementChange;

    private Transform _target;
    private float _detectionRadius = 5f;

    public void Start()
    {
        _patrolMovement = GetComponent<EnemyPatrolMovement>();
        ActiveMovement = _patrolMovement;

        _target = FindAnyObjectByType<PlayerMovement>()?.transform;
    }

    private bool DetectPlayer() => 
    Vector3.Distance(_target.position, transform.position) <= _detectionRadius;

    private void BrainLogic()
    {
        if (DetectPlayer())
        {
            // Saw Player
        }
    }

    private void Update()
    {
        ActiveMovement.Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // if (_doFollow)
            // Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
