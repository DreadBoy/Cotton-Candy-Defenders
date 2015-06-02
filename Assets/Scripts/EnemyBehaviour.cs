using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyBehaviour : MonoBehaviour
{

    Animator animator = null;
    PathFinding pathFinding = null;
    EnemyStats enemyStats = null;

    GameObject goldEarned = null;

    AreaBehaviour areaBehaviour = null;

    private Boolean dying = false;
    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        pathFinding = GetComponent<PathFinding>();
        enemyStats = GetComponent<EnemyStats>();

        goldEarned = Resources.Load<GameObject>("Prefabs/GoldEarn");

        areaBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<AreaBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDamage(int damage)
    {
        enemyStats.health -= damage;
        if (enemyStats.health <= 0)
        {
            Death();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    public void Die()
    {
        Death();
    }

    private void Death()
    {
        pathFinding.Stop();
        animator.SetTrigger("Death");
        StartCoroutine("DelayDestroy");
        if (!dying)
        {
            ((GameObject)Instantiate(goldEarned, Vector3.zero, Quaternion.identity)).GetComponent<GoldEarn>().Start(transform.position, enemyStats.worth);
            PlayerProgress.Gold += enemyStats.worth;
        }
        dying = true;
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
        areaBehaviour.monsterKilled();
    }
}
