using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 15f;
    [SerializeField] bool isProvoked = false;
    NavMeshAgent navMeshAgent;
    float DistanceToTarget = Mathf.Infinity;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        DistanceToTarget = Vector3.Distance(target.position,transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        else if(DistanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }
    private void EngageTarget()
    {
        if(DistanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if(DistanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    private void AttackTarget()
    {
        Debug.Log(name + "is seeked and is destroying" +target.name);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);   
    }
}
