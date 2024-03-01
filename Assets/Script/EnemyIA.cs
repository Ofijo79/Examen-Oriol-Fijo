using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }

    [SerializeField] private State currentState;

    NavMeshAgent agent;

    Transform player;

    [SerializeField] Transform[] patrolPoints;

    [SerializeField] float detectionRange = 15;

    [SerializeField] float attackRange = 5;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Start()
    {
        SetPoint();
        currentState = State.Patrolling;
    }

    void Update()
    {
        switch(currentState)
        {
            case State.Patrolling:
                Patrol();
            break;
            case State.Chasing:
                Chase();
            break;
            case State.Attacking:
                Attack();
            break;
        }
    }

    void Patrol()
    {
        if(IsInRange(detectionRange) == true)
        {
            currentState = State.Chasing;
        }

        if(agent.remainingDistance < 0.5f)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        agent.destination = patrolPoints[Random.Range(0, patrolPoints.Length)].position;
    }

    void Chase()
    {
        if(IsInRange(detectionRange) == false)
        {
            SetPoint();
            currentState = State.Patrolling;
        }

        if(IsInRange(attackRange) == true)
        {
            currentState = State.Attacking;
        }

        agent.destination = player.position;
    }

    bool IsInRange(float range)
    {
        if(Vector3.Distance(transform.position, player.position) < range)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void Attack()
    {
        Debug.Log("Atacando");

        currentState = State.Chasing;
    }

    void DrawOnGizmos()
    {
        Gizmos.color = Color.blue;

        foreach(Transform point in patrolPoints)
        {
            Gizmos.DrawWireSphere(point.position, 0.5f);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
