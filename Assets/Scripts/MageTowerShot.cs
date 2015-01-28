using UnityEngine;
using System.Collections;

public class MageTowerShot : MonoBehaviour
{

    public float shotCooldown = 0;
    public GameObject projectile;
    private Vector3 shotPosition;

    void Start()
    {
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
                    shotCooldown = 2;
                    break;
                }
            }
        }
        else
            shotCooldown -= Time.fixedDeltaTime;
    }
}
