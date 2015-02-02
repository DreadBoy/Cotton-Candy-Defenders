using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(PathFinding))]
public class EnemyHealth : MonoBehaviour {

    Animation animationController = null;
	PathFinding pathFinding = null;
    public int _health { get; private set; }
    public int health = 2;

    GameObject goldEarned = null;

	// Use this for initialization
	void Start () {
		animationController = GetComponent<Animation>();
		pathFinding = GetComponent<PathFinding>();
		goldEarned = Resources.Load<GameObject> ("Prefabs/GoldEarn");
        _health = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDamage(int damage)
    {
        _health -= damage;
		animationController.CrossFade("hit1");
		animationController.CrossFadeQueued("walk");
        if (_health <= 0)
        {
			pathFinding.Stop();
			animationController.CrossFade("death1");
            StartCoroutine("DelayDestroy");
			var gold = (GameObject)Instantiate(goldEarned, Vector3.zero, Quaternion.identity);// .Start(transform.position);
			var goldScript = gold.GetComponent<GoldEarn>();
			goldScript.Start(transform.position);
		}
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 100, 100), "Gold"))
            Instantiate(goldEarned, Vector3.zero, Quaternion.identity);

    }
}
