using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }

    [SerializeField] State currentState;

    NavMeshAgent agent;

    [SerializeField] Transform[] points;

    Transform player;

    [SerializeField] float visionRange = 15f;

    [SerializeField] float attackRange = 5f;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPoint();
        currentState = State.Patrolling;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            currentState State.Patrolling:
                Patrol();
            break;
            currentState State.Chasing:
                Chase();
            break;
            currentState State.Attacking:
                Attack();
            break;
        }
    }

    void Attack()
    {
        Debug.Log("Atacando");
        currentState = State.Chasing;
    }

    void SetPoint()
    {

    }

    void Chase()
    {
        
    }

    void DrawOnGizmos()
    {
        
    }
}
