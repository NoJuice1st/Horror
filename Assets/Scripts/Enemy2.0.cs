using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public float speed;
    public float viewDistance = 20f;
    public float wanderDistance = 10f;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        if (target == null) return;
        
        agent.speed = speed;

            var distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewDistance)
        {
            // chase
            agent.destination = target.position;
        }
        else
        {
            // seek or stand
            if (agent.velocity == Vector3.zero)
            {
                //seek
                agent.destination += Random.insideUnitSphere * 5;
            }
        }
    }
}
