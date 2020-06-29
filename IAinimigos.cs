using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class IAinimigos : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
    }
    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        //agent.destination = points[destPoint].position;
        agent.destination = RandomPoint().position;
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GoToNextPoint();

    }

    Transform RandomPoint()
    {
        int valorMax = points.Length;
        int valorSorteado = Random.Range(0, valorMax);
        return points[valorSorteado];
    }
}