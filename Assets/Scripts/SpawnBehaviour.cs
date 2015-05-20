using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class SpawnBehaviour : MonoBehaviour
{
    [System.Serializable]
    public class WaveWraper
    {
        public List<Monster.Type> monsters = new List<Monster.Type>();
    }
    [System.Serializable]
    public class LevelWraper
    {
        public List<WaveWraper> waves = new List<WaveWraper>();
    }


    AreaBehaviour areaBehaviour = null;
    public List<LevelWraper> levels = new List<LevelWraper>();
    public Single waitTime = 2.5f;
    Dictionary<Monster.Type, GameObject> prefabs = new Dictionary<Monster.Type, GameObject>();

    void Start()
    {
        foreach (Monster.Type type in Enum.GetValues(typeof(Monster.Type)))
            prefabs.Add(type, Resources.Load<GameObject>("Prefabs/Enemies/" + type.ToString()));

        areaBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<AreaBehaviour>();

        for (int l = 0; l < areaBehaviour.level_max; l++)
        {
            while(levels.Count < areaBehaviour.level_max) //only if not set up in Editor
                levels.Add(new LevelWraper());

            for (int w = 0; w < areaBehaviour.wave_max; w++)
            {
                while (levels[l].waves.Count < areaBehaviour.wave_max) //only if not set up in Editor
                    levels[l].waves.Add(new WaveWraper());
                
            }
        }
    }

    public void SpawnMonsters(Int32 level, Int32 wave)
    {
        level -= 1;
        wave -= 1;
        areaBehaviour.spawnedMonsters += levels[level].waves[wave].monsters.Count;
        StartCoroutine(SpawnMonstersCoroutine(level, wave, name));
    }

    private IEnumerator SpawnMonstersCoroutine(Int32 level, Int32 wave, String name)
    {
        Boolean finished = false;
        while (!finished)
        {
            finished = true;
            if (levels[level].waves[wave].monsters.Count <= 0)
                continue;
            if (!prefabs.ContainsKey(levels[level].waves[wave].monsters[0]))
                continue;
			Instantiate(prefabs[levels[level].waves[wave].monsters[0]], transform.position, prefabs[levels[level].waves[wave].monsters[0]].transform.rotation);
            levels[level].waves[wave].monsters.RemoveAt(0);
            if (levels[level].waves[wave].monsters.Count > 0)
                finished = false;
            if (finished)
                yield break;

            yield return new WaitForSeconds(waitTime);
        }
    }
}
