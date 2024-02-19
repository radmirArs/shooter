﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoint;
    private NavMeshAgent _navMeshAgent;
    private int i;

    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;

    void Start()
    {
        InitComponentLinks();
        EnemyMoveForPointRandom();
    }

    void Update()
    {
        ControlRaycastEnemyUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    void ControlRaycastEnemyUpdate()
    {
        _isPlayerNoticed = false;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
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
        if (_navMeshAgent.remainingDistance == 0 && _isPlayerNoticed == false)
            EnemyMoveForPointRandom();
    }

    void EnemyMoveForPointRandom()
    {
        i = Random.Range(0, patrolPoint.Count);
        _navMeshAgent.destination = patrolPoint[i].position;
    }
    void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
