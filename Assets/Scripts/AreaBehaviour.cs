using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class AreaBehaviour : MonoBehaviour
{
    public enum State
    {
        building,
        fighting,
        rewarding
    }
    public State state = State.building;
    //TODO display enemy portraits on doors

    public Int32 wave = 1;
    public Int32 wave_max = 5;
    
	GameObject[] spots;
    GameObject[] spawns;

    public Int32 spawnedMonsters = 0;

    WaveUI waveUI = null;
    void Start()
    {
        waveUI = GetComponent<WaveUI>();

        spots = GameObject.FindGameObjectsWithTag("Spot");
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
		disableSpots();
    }

    /// <summary>
    /// Enables spots, move camera and prepares new wave (announces at and displayes Ready button)
    /// </summary>
    public void startLevel()
    {
        wave = 1;
        enableSpots();
        state = State.building;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().gotoLevel(PlayerProgress.level);
        waveUI.newWave(wave);
    }

    /// <summary>
    /// Disables spots, spawn monsters and hides Ready button
    /// </summary>
    public void startWave()
    {
        disableSpots();
        waveUI.startWave();
        SpawnMonsters();
        state = State.fighting;
    }

    /// <summary>
    /// If not at the end of level, it enables spots and display End wave panel, otherwise ends the level
    /// </summary>
    public void endWave()
    {
        wave++;
        if (wave > wave_max)
        {
            PlayerProgress.level++;
            waveUI.endLevel();
        }
        else
        {
            enableSpots();
            waveUI.endWave();
        }
    }


	public void monsterKilled(){
        
		spawnedMonsters--;
        if (spawnedMonsters == 0)
        {
            endWave();
            state = State.rewarding;
        }
        
	}
    private void SpawnMonsters()
    {
        foreach (var spawn in spawns)
        {
            spawn.GetComponent<SpawnBehaviour>().SpawnMonsters(PlayerProgress.level, wave);
        }
    }

	private void disableSpots ()
	{
		foreach(var spot in spots)
			spot.SetActive(false);
	}

	private void enableSpots ()
	{
		foreach(var spot in spots)
			spot.SetActive(true);
	}
}
