using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildTowerManager : MonoBehaviour
{

    static Dictionary<TowerType, GameObject> towerPrefabs = new Dictionary<TowerType, GameObject>();

    void Start()
    {
        towerPrefabs.Add(TowerType.basic, Resources.Load<GameObject>("Prefabs/Towers/BasicTower"));
        towerPrefabs.Add(TowerType.slow, Resources.Load<GameObject>("Prefabs/Towers/SlowingTower"));
        towerPrefabs.Add(TowerType.stun, Resources.Load<GameObject>("Prefabs/Towers/StunningTower"));
        towerPrefabs.Add(TowerType.pierce, Resources.Load<GameObject>("Prefabs/Towers/PiercingTower"));
        towerPrefabs.Add(TowerType.poison, Resources.Load<GameObject>("Prefabs/Towers/PoisonedTower"));
        towerPrefabs.Add(TowerType.fear, Resources.Load<GameObject>("Prefabs/Towers/FearTower"));
        towerPrefabs.Add(TowerType.charm, Resources.Load<GameObject>("Prefabs/Towers/CharmTower"));
        
    }

    public static GameObject buildTower(TowerType type, Vector3 position)
    {
        if (!towerPrefabs.ContainsKey(type))
            return null;
        TowerStats towerStats = towerPrefabs[type].GetComponent<TowerStats>();
        if (towerStats != null)
            return (GameObject)Instantiate(towerPrefabs[type], position, towerPrefabs[type].transform.rotation);
        else
            return null;
    }
}

public enum TowerType
{
    basic,
	slow,
	stun,
	pierce,
	poison,
	fear,
	charm
}
