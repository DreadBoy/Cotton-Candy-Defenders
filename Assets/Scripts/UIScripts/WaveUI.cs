using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WaveManager))]
public class WaveUI : MonoBehaviour
{
    GUISkin skin = null;

    GameObject waveLabel;
    GameObject waveLabelPrefab;
    GameObject canvas;

    WaveManager waveManager = null;

    enum State
    {
        title,
        title_switching,
        waiting,
        none
    }
    State state = State.none;

    void Start()
    {
        skin = Resources.Load<GUISkin>("GUI skin/CCD");

        waveLabelPrefab = Resources.Load<GameObject>("GUI skin/Wave Label");
        canvas = GameObject.Find("Canvas");

        waveManager = GetComponent<WaveManager>();
    }

    void Update()
    {

    }

    public void newWave()
    {
        if (state == State.none)
        {
            state = State.title;
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        switch (state)
        {
            case State.title:
                waveLabel = (GameObject)Instantiate(waveLabelPrefab, Vector3.zero, Quaternion.identity);
                waveLabel.transform.SetParent(canvas.transform);
                waveLabel.GetComponent<WaveLabelBehaviour>().setText(waveManager.waveNum);
                StartCoroutine("newWaveHide");
                state = State.title_switching;  
                break;
            case State.waiting:
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Ready"))
                {
                    state = State.none;
                    waveManager.newWave();
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                break;

        }
        GUILayout.EndArea();
    }

    IEnumerator newWaveHide()
    {
        yield return new WaitForSeconds(5);
        state = State.waiting;
    }
}
