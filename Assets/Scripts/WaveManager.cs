using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveUI))]
public class WaveManager : MonoBehaviour
{

    WaveUI waveUI = null;
    LevelBehaviour levelBehaviour = null;

    public int waveNum = 1;
    public int waveNumMax = 5;

    void Start()
    {
        waveUI = GetComponent<WaveUI>();
        waveUI.newWave();
        levelBehaviour = GetComponent<LevelBehaviour>();
    }

    public void newWave()
    {
        levelBehaviour.SpawnMonsters();
    }
}
