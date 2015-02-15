using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveUI))]
[RequireComponent(typeof(LevelBehaviour))]
public class WaveManager : MonoBehaviour
{

    WaveUI waveUI = null;
    LevelBehaviour levelBehaviour = null;

    public int waveNum = 1;
    public int waveNumMax = 2;

    void Start()
    {
        waveUI = GetComponent<WaveUI>();
        levelBehaviour = GetComponent<LevelBehaviour>();
    }

    public void newWave()
	{
        levelBehaviour.SpawnMonsters();
		levelBehaviour.disableSpots();
    }

	public void endWave(){
		waveNum++;
		if(waveNum > waveNumMax)
			waveUI.endLevel();
		else{
			levelBehaviour.enableSpots();
			Debug.Log ("Enabling");
			waveUI.endWave();
		}
	}
}
