using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public NavMeshAgent agent;

    public bool hasReachedDestination;
    public float stoppingDistance;

    public List<Road> roads;


    private void Start()
    {
        roads = FindObjectsOfType<Road>().ToList();

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GetRandomPosition());

    }

    private void Update()
    {
        if (!hasReachedDestination)
        {
            Debug.Log("agent.remainingDistance");
            if (agent.remainingDistance <= stoppingDistance)
            {
                hasReachedDestination = true;
            }
        }
        else if(hasReachedDestination)
        {
            agent.SetDestination(GetRandomPosition());
        }
    }

    private Vector3 GetRandomPosition()
    {
        Road randomroad = roads[Random.Range(0, roads.Count)];

        return randomroad.GetRandomPoint();
    }
}
