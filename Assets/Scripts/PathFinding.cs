using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class PathFinding : MonoBehaviour
{
    Vector3 goal = Vector3.zero;
	NavMeshAgent agent = null;

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform.position;
		agent = GetComponent<NavMeshAgent>();
		if(agent != null)
            agent.SetDestination(goal);
    }

	public void Stop(){
		if(agent != null)
			agent.Stop();
	}
}
