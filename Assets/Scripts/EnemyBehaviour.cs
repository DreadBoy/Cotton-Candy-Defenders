using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(PlayerGold))]
public class EnemyBehaviour : MonoBehaviour
{

    Animator animator = null;
    PathFinding pathFinding = null;
    EnemyStats enemyStats = null;

    GameObject goldEarned = null;
    PlayerGold playerGold = null;

    AreaBehaviour areaBehaviour = null;

    private Boolean dying = false;
    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        pathFinding = GetComponent<PathFinding>();
        enemyStats = GetComponent<EnemyStats>();
        playerGold = GetComponent<PlayerGold>();

        goldEarned = Resources.Load<GameObject>("Prefabs/GoldEarn");

        areaBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<AreaBehaviour>();
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
            if (playerGold.Earn(enemyStats.worth))
                ((GameObject)Instantiate(goldEarned, Vector3.zero, Quaternion.identity)).GetComponent<GoldEarn>().Start(transform.position, enemyStats.worth);
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
