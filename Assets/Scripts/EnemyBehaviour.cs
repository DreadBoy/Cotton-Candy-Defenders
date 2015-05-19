using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyBehaviour : MonoBehaviour {

    Animation animationController = null;
    PathFinding pathFinding = null;
    EnemyStats enemyStats = null;

    GameObject goldEarned = null;

	AreaBehaviour areaBehaviour = null;
	// Use this for initialization
	void Start () {

        animationController = GetComponent<Animation>();
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
            animationController.CrossFade("death1");
            StartCoroutine("DelayDestroy");
            ((GameObject)Instantiate(goldEarned, Vector3.zero, Quaternion.identity)).GetComponent<GoldEarn>().Start(transform.position);
        }
        else
        {
            animationController.CrossFade("hit1");
            animationController.CrossFadeQueued("walk");
        }
    }


    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
		areaBehaviour.monsterKilled();
    }
}
