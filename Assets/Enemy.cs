using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public float viewDistance = 20f;
    public float wanderDistance = 10f;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update() 
    {
        //transform.LookAt(target);
        //rb.velocity = transform.forward * speed;
        //transform.position += transform.forward * speed * Time.deltaTime;
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewDistance)
        {
            // chase
            agent.destination = target.position;
        }
        else
        {
            // seek
            if (agent.velocity == Vector3.zero)
            {
                agent.destination = Random.insideUnitCircle * 5;
            }
        }
    }
}
