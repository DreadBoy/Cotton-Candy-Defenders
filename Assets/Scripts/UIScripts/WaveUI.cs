using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WaveUI : MonoBehaviour
{
	GameObject waveLabel;
	GameObject readyButton;
	GameObject endWavePanel;
	GameObject endLevelPanel;

    void Start()
    {
		waveLabel = GameObject.Find("NewWaveLabel");
		readyButton = GameObject.Find("ReadyWaveButton");
		endWavePanel = GameObject.Find("EndWavePanel");
		endLevelPanel = GameObject.Find("EndLevelPanel");
    }

    public void newWave(Int32 wave)
    {
        waveLabel.GetComponent<NewWaveLabelBehaviour>().Begin(wave);
        StartCoroutine(newWaveHideCoroutine());
        endWavePanel.SetActive(false);
        endLevelPanel.SetActive(false);
    }

    public void startWave()
    {
        readyButton.SetActive(false);
    }

	public void endWave(){
		endWavePanel.SetActive(true);
	}

	public void endLevel(){
		endLevelPanel.SetActive(true);
	}

    IEnumerator newWaveHideCoroutine()
    {
		yield return new WaitForSeconds(5);
		readyButton.SetActive(true);
	}

}
