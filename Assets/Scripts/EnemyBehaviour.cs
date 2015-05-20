using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyBehaviour : MonoBehaviour {

    Animator animator = null;
    PathFinding pathFinding = null;
    EnemyStats enemyStats = null;

    GameObject goldEarned = null;

	AreaBehaviour areaBehaviour = null;
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        pathFinding = GetComponent<PathFinding>();
        enemyStats = GetComponent<EnemyStats>();

        goldEarned = Resources.Load<GameObject>("Prefabs/GoldEarn");

        areaBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<AreaBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void takeDamage(int damage)
    {
        enemyStats.health -= damage;
        if (enemyStats.health <= 0)
        {
            pathFinding.Stop();
            animator.SetTrigger("Death");
            StartCoroutine("DelayDestroy");
            ((GameObject)Instantiate(goldEarned, Vector3.zero, Quaternion.identity)).GetComponent<GoldEarn>().Start(transform.position);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }


    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
		areaBehaviour.monsterKilled();
    }
}
