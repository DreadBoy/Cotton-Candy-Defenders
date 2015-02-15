using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(WaveManager))]
public class WaveUI : MonoBehaviour
{
	GameObject waveLabel;
	GameObject readyButton;
	GameObject endWavePanel;
	GameObject endLevelPanel;

    WaveManager waveManager = null;

    void Start()
    {
		waveLabel = GameObject.Find("NewWaveLabel");
		readyButton = GameObject.Find("ReadyWaveButton");
		endWavePanel = GameObject.Find("EndWavePanel");
		endLevelPanel = GameObject.Find("EndLevelPanel");

        waveManager = GetComponent<WaveManager>();
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

	public void newWaveHide(){
		StartCoroutine("newWaveHideCoroutine");
	}
}
