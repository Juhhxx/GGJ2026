using System;
using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrolMovement))]
public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private float _fov;
    [Range(0, 360)] [SerializeField] private float _fovAngle;
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
    [SerializeField] private float _detectionRadius = 5f;

    public void Start()
    {
        _patrolMovement = GetComponent<EnemyPatrolMovement>();
        ActiveMovement = _patrolMovement;

        _target = FindAnyObjectByType<PlayerMovement>()?.transform;
    }

    private bool DetectPlayer()
    {
        float signedAngle = Vector3.Angle(Direction, _target.position - transform.position);
        if (Vector3.Distance(_target.position, transform.position) <= _fov)
        {
            if (Mathf.Abs(signedAngle) < _fovAngle / 2)
            {
                Debug.Log("PENIS2");
                return true;
            }
        }
        return Vector3.Distance(_target.position, transform.position) <= _detectionRadius;
    }

    private void BrainLogic()
    {
        if (DetectPlayer())
        {
            Debug.Log("butt");
            // Saw Player
        }
    }

    private void Update()
    {
        ActiveMovement.Move();
        BrainLogic();
        DrawWireArc(transform.position, Direction, _fovAngle, _fov, Color.green);
        DrawWireArc(transform.position, Direction, 360, _detectionRadius, Color.blue);
        Debug.DrawRay(transform.position, Direction, Color.red);
    }
    private void DrawWireArc(Vector3 position, Vector3 dir, float anglesRange, float radius, Color color, float maxSteps = 20)
    {
        var srcAngles = GetAnglesFromDir(position, dir);
        var initialPos = position;
        var posA = initialPos;
        var stepAngles = anglesRange / maxSteps;
        var angle = srcAngles - anglesRange / 2;
        for (var i = 0; i <= maxSteps; i++)
        {
            var rad = Mathf.Deg2Rad * angle;
            var posB = initialPos;
            posB += new Vector3(radius * Mathf.Cos(rad), radius * Mathf.Sin(rad),0);

            Debug.DrawLine(posA, posB, color);

            angle += stepAngles;
            posA = posB;
        }
        Debug.DrawLine(posA, initialPos, color);
    }
    private float GetAnglesFromDir(Vector3 position, Vector3 dir)
    {
        var forwardLimitPos = position + dir;
        var srcAngles = Mathf.Rad2Deg * Mathf.Atan2(forwardLimitPos.y - position.y, forwardLimitPos.x - position.x);

        return srcAngles;
    }
}
