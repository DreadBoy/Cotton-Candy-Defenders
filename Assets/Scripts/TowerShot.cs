using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TowerStats))]
public class TowerShot : MonoBehaviour
{

    float shotCooldown = 0;
    public GameObject projectile;
	TowerStats towerStats = null;

    void Start()
    {
		towerStats = GetComponent<TowerStats>();
    }

    void FixedUpdate()
    {

        if (shotCooldown <= 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Enemy")
                {
                    
                    TowerStats towerStats = GetComponent<TowerStats>();
                    if (towerStats == null) 
                        continue;
                    GameObject project = (GameObject)Instantiate(projectile, transform.position + towerStats.shotPosition, Quaternion.identity);
                    project.GetComponent<Projectile>().setGoal(hitCollider.gameObject);
                    shotCooldown = 4 - towerStats.level;
                    break;
                }
            }
        }
        else
            shotCooldown -= Time.fixedDeltaTime;
    }
}
