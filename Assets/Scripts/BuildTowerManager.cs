using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildTowerManager : MonoBehaviour
{

    static Dictionary<TowerType, GameObject> towerPrefabs = new Dictionary<TowerType, GameObject>();

    void Start()
    {
        towerPrefabs.Add(TowerType.brute, Resources.Load<GameObject>("Prefabs/BruteTower"));
    }

    public static void buildTower(TowerType type, Vector3 position)
    {
        if (!towerPrefabs.ContainsKey(type))
            return;
        TowerStats towerStats = towerPrefabs[type].GetComponent<TowerStats>();
        if (towerStats != null)
        {
            Instantiate(towerPrefabs[type], position, towerPrefabs[type].transform.rotation);
        }
    }
}

public enum TowerType
{
    brute,
    mage
}
