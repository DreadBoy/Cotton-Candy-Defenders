using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(LevelStats))]
public class LevelBehaviour : MonoBehaviour
{

    //TODO display enemy portraits on doors

    LevelStats levelStats = null;
    Dictionary<LevelStats.Monster.Type, GameObject> prefabs = new Dictionary<LevelStats.Monster.Type, GameObject>();

    void Start()
    {
        levelStats = GetComponent<LevelStats>();
        prefabs.Add(LevelStats.Monster.Type.Spider, Resources.Load<GameObject>("Prefabs/Enemies/Spider"));
    }

    public void SpawnMonsters()
    {
        StartCoroutine("SpawnMonstersCoroutine");
    }

    private IEnumerator SpawnMonstersCoroutine()
    {
        while (true)
        {
            foreach(var door in levelStats.doors){
                if(door.monsters.Count <= 0)
                    continue;
                if (!prefabs.ContainsKey(door.monsters[0].type))
                    continue;
                Instantiate(prefabs[door.monsters[0].type], door.position, Quaternion.identity);
                door.monsters.RemoveAt(0);
            }
            yield return new WaitForSeconds(1);

            // Otherwise, continue next frame
            yield return null;
        }
    }
}
