using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Agent;

    // Start is called before the first frame update
    void Start()
    {
        Agent.SetDestination(Target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
