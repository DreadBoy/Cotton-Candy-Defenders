using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PitOfDoom : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<EnemyBehaviour>();
        if (enemy != null)
        {
            enemy.Die();
        }
    }
}
