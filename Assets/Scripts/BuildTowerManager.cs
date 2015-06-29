using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildTowerManager : MonoBehaviour
{

    private Dictionary<TowerType, GameObject> towerPrefabs = new Dictionary<TowerType, GameObject>();
    PlayerGold playerGold = null;

    void Awake()
    {
        playerGold = GetComponent<PlayerGold>();
    }
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

    public GameObject buildTower(TowerType type, Vector3 position)
    {
        if (!towerPrefabs.ContainsKey(type))
            return null;
        TowerStats towerStats = towerPrefabs[type].GetComponent<TowerStats>();
        if (towerStats != null)
        {
            if (towerStats.Cost <= PlayerProgress.gold.gold)
            {
                GameObject tower = (GameObject)Instantiate(towerPrefabs[type], position, towerPrefabs[type].transform.rotation);
                if (playerGold != null)
                    playerGold.Spend(towerStats.Cost);
                return tower;
            }
            return null;
        }
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
