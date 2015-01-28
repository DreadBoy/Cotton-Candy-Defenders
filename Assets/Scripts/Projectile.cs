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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"){
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(1);
                GameObject.Destroy(gameObject);

            }
        }
    }
}
