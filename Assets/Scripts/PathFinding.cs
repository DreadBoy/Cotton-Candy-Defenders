using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour
{
    Vector3 goal = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        goal = GameObject.Find("goal").transform.position;
        var agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
