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

    public enum AIState
    {
        idle, patrolling, chasing
    }
    public AIState CurrentState;
    public float WaitAtPoint;    
    private float waitCounter;

    public float ChaseRange;

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = WaitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {        
        EnemyStates();
    }

    void EnemyStates()
    {
        //distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        switch (CurrentState)
        {
            case AIState.idle:
                Animator.SetBool("IsMoving", false);
                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    CurrentState = AIState.patrolling;
                    Agent.SetDestination(PatrolPoints[CurrentPatrolPoint].position);
                }
                break;
            case AIState.patrolling:
                if (distanceToPlayer <= ChaseRange)
                {
                    CurrentState = AIState.chasing;
                    Animator.SetBool("IsMoving", true);
                }
                else
                {
                    SetAgentDestination();
                }
                break;
            case AIState.chasing:
                Agent.SetDestination(PlayerController.Instance.transform.position);
                break;
        }
    }

    void SetAgentDestination()
    {        
        if (Agent.remainingDistance <= .2f)
        {
            CurrentPatrolPoint++;
            if (CurrentPatrolPoint >= PatrolPoints.Length)
            {
                CurrentPatrolPoint = 0;
            }
            CurrentState = AIState.idle;
            waitCounter = WaitAtPoint;
            //Agent.SetDestination(PatrolPoints[CurrentPatrolPoint].position);
        }

        Animator.SetBool("IsMoving", true);
    }
}
