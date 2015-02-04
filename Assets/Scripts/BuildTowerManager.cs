using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildTowerManager : MonoBehaviour
{

    static Dictionary<TowerType, GameObject> towerPrefabs = new Dictionary<TowerType, GameObject>();

    void Start()
    {
        towerPrefabs.Add(TowerType.brute, Resources.Load<GameObject>("Prefabs/BruteTower"));
        towerPrefabs.Add(TowerType.mage, Resources.Load<GameObject>("Prefabs/MageTower"));
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
    brute,
    mage
}
