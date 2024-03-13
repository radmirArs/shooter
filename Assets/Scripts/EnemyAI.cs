using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoint;
    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _healthPlayer;
    private int i;
    public Animator _animator;

    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;
    public float damage = 30;

    void Start()
    {
        InitComponentLinks();
        EnemyMoveForPointRandom();
    }

    void Update()
    {
        ControlRaycastEnemyUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void AttackUpdate()
    {
        _animator.SetBool("AttackEnemy", false);
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            { 
                _animator.SetBool("AttackEnemy", true);
                _healthPlayer.DestroyEnemyUpdate((damage * Time.deltaTime));
            }
        }
    }
    
    void ControlRaycastEnemyUpdate()
    {
        _isPlayerNoticed = false;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) <= viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                    _isPlayerNoticed = true;
            }
        }
    }

    void ChaseUpdate()
    {
        if (_isPlayerNoticed)
            _navMeshAgent.destination = player.transform.position;
    }

    void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                EnemyMoveForPointRandom();
        }
    }

    void EnemyMoveForPointRandom()
    {
        i = Random.Range(0, patrolPoint.Count);
        _navMeshAgent.destination = patrolPoint[i].position;
    }
    void InitComponentLinks()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _healthPlayer =  player.GetComponent<PlayerHealth>();
    }
}
