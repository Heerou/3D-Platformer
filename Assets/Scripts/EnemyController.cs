using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public int CurrentPatrolPoint;
    public NavMeshAgent Agent;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetAgentDestination();
    }

    void SetAgentDestination()
    {
        Agent.SetDestination(PatrolPoints[CurrentPatrolPoint].position);
        if (Agent.remainingDistance <= .2f)
        {
            CurrentPatrolPoint++;
            if (CurrentPatrolPoint >= PatrolPoints.Length)
            {
                CurrentPatrolPoint = 0;
            }
            Agent.SetDestination(PatrolPoints[CurrentPatrolPoint].position);
        }

        Animator.SetBool("IsMoving", true);
    }
}
