using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class EnemyHealth : MonoBehaviour {

    Animation animation = null;
    public int _health { get; private set; }
    public int health = 2;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
        _health = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void takeDamage(int damage)
    {
        _health -= damage;
        animation.CrossFade("hit1");
        animation.CrossFadeQueued("walk");
        if (_health <= 0)
        {
            animation.CrossFade("death1");
            StartCoroutine("DelayDestroy");
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }
}
