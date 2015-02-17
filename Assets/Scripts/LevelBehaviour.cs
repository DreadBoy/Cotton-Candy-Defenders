using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(LevelStats))]
[RequireComponent(typeof(WaveManager))]
public class LevelBehaviour : MonoBehaviour
{

    //TODO display enemy portraits on doors
	
	LevelStats levelStats = null;
    Dictionary<LevelStats.Monster.Type, GameObject> prefabs = new Dictionary<LevelStats.Monster.Type, GameObject>();

	WaveManager waveManager = null;

	int spawnedMonsters = 0;
	public Boolean canBuild = false;

	GameObject[] spots;

    void Start()
    {
        levelStats = GetComponent<LevelStats>();
		waveManager = GetComponent<WaveManager>();

		prefabs.Add(LevelStats.Monster.Type.Spider, Resources.Load<GameObject>("Prefabs/Enemies/Spider"));

		spots = GameObject.FindGameObjectsWithTag("Spot");
		disableSpots();
    }

    public void SpawnMonsters()
    {
        StartCoroutine("SpawnMonstersCoroutine");
    }

    private IEnumerator SpawnMonstersCoroutine()
    {
		Boolean finished = false;
		while (!finished)
		{
			finished = true;
            foreach(var door in levelStats.doors){
                if(door.levels[waveManager.waveNum - 1].monsters.Count <= 0)
                    continue;
				if (!prefabs.ContainsKey(door.levels[waveManager.waveNum - 1].monsters[0].type))
                    continue;
				Instantiate(prefabs[door.levels[waveManager.waveNum - 1].monsters[0].type], door.position, Quaternion.identity);
				spawnedMonsters++;
				door.levels[waveManager.waveNum - 1].monsters.RemoveAt(0);
				if(door.levels[waveManager.waveNum - 1].monsters.Count > 0)
					finished = false;
            }
			if(finished)
				yield break;
            yield return new WaitForSeconds(1);
        }
    }

	public void monsterKilled(){
		spawnedMonsters--;
		if(spawnedMonsters == 0)
		   waveManager.endWave();
	}

	public void disableSpots ()
	{
		canBuild = false;
		foreach(var spot in spots)
			spot.SetActive(false);
	}

	public void enableSpots ()
	{
		canBuild = true;
		foreach(var spot in spots)
			spot.SetActive(true);
	}
}
