using UnityEngine;
using System.Collections;

public class MageTowerShot : MonoBehaviour {

	public float shotCooldown = 2;
	private GameObject shotTarget = null;
	public GameObject particles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50);
		int i = 0;
		while (i < hitColliders.Length) {
			if(hitColliders[i].tag == "Enemy"){
				shotTarget = hitColliders[i].gameObject;
				GameObject e = (GameObject)Instantiate(particles, shotTarget.transform.position, Quaternion.identity);
				//hitColliders[i].gameObject
			}
			i++;
		}
	}
}
