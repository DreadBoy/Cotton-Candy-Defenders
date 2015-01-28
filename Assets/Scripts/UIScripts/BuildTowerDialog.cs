using UnityEngine;
using System.Collections;

public class BuildTowerDialog : MonoBehaviour {

    public GUISkin skin;
    private Rect windowRect = new Rect(0, 0, Screen.width / 2, Screen.height / 2);
    private bool opened;

    private GameObject caller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (!opened)
            return;
        
        GUI.skin = skin;

        GUILayout.BeginArea(new Rect(0, 0, Screen.width / 4, Screen.height));

        windowRect = GUILayout.Window(0, windowRect, newTowerDialog, "");

        GUILayout.EndArea();
    }

    private void newTowerDialog(int windowID)
    {
        if (GUILayout.Button("Build Brute tower"))
        {
            BuildTowerManager.buildTower(TowerType.brute, caller.transform.position);
            caller.SetActive(false);
            this.Close();
        }

    }

    public BuildTowerDialog setCaller(GameObject call)
    {
        caller = call;
        return this;
    }

    public void Open()
    {
        opened = true;
    }

    public void Close()
    {
        opened = false;
    }
}
