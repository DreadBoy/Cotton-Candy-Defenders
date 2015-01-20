using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health { get; private set; }

	// Use this for initialization
	void Start () {
        health = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
