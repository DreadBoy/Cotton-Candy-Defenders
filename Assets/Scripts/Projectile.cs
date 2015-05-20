using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TrailRenderer))]
public class Projectile : MonoBehaviour
{

    private GameObject goal = null;
    private TrailRenderer trail;

    public float speed;
    public int damage;

    // Use this for initialization
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goal == null)
        {
            GameObject.Destroy(gameObject);
            return;
        }
        float step = speed * Time.deltaTime * 30;

        transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, step);

        Vector3 newDir = Vector3.RotateTowards(transform.forward, goal.transform.position - transform.position, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    public void setGoal(GameObject _goal)
    {
        goal = _goal;
        //StartCoroutine("Move");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyBehaviour enemyBehaviour = other.GetComponent<EnemyBehaviour>();
             
            enemyBehaviour.takeDamage(damage);
            GameObject.Destroy(gameObject);

        }
    }
}
