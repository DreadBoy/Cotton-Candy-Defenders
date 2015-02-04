using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class Projectile : MonoBehaviour {

    private GameObject goal;
    private TrailRenderer trail;

	// Use this for initialization
	void Start () {
        trail = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    public void setGoal(GameObject _goal)
    {
        goal = _goal;
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        float timeSinceStarted = 0f;
        while (true && goal != null)
        {
            timeSinceStarted += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, goal.transform.position, timeSinceStarted / 2);

            // If the object has arrived, stop the coroutine
            if (transform.position == goal.transform.position)
            {
                GameObject.Destroy(gameObject);
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
		if (goal == null)
						Destroy (gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"){
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
            if (enemyStats.health != null)
            {
                enemyBehaviour.takeDamage(1);
                GameObject.Destroy(gameObject);

            }
        }
    }
}
