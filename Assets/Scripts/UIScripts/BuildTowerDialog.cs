﻿using UnityEngine;
using System.Collections;

public class BuildTowerDialog : MonoBehaviour {

    public GUISkin skin;
    private Rect windowRect = new Rect(0, 0, 180, 70);
    private bool opened;

    private Texture2D bruteTowerIcon = null;
    private Texture2D mageTowerIcon = null;

    private Texture2D crossIcon = null;


    private GameObject caller;

	// Use this for initialization
	void Start () {

        bruteTowerIcon = Resources.Load<Texture2D>("GUI skin/icon_sword");
        mageTowerIcon = Resources.Load<Texture2D>("GUI skin/icon_crosshair");
        crossIcon = Resources.Load<Texture2D>("GUI skin/icon_cross");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (!opened)
            return;
        if (bruteTowerIcon == null || mageTowerIcon == null || crossIcon == null)
            return;
        
        GUI.skin = skin;
        windowRect = GUILayout.Window(0, windowRect, newTowerDialog, "");

    }

    private void newTowerDialog(int windowID)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(bruteTowerIcon, GUILayout.Width(50), GUILayout.Height(50)))
        {
            BuildTowerManager.buildTower(TowerType.brute, caller.transform.position);
            caller.SetActive(false);
            this.Close();
        }
        if (GUILayout.Button(mageTowerIcon, GUILayout.Width(50), GUILayout.Height(50)))
        {
            BuildTowerManager.buildTower(TowerType.mage, caller.transform.position);
            caller.SetActive(false);
            this.Close();
        }
        if (GUILayout.Button(crossIcon, GUILayout.Width(50), GUILayout.Height(50)))
        {
            this.Close();
        }
        GUILayout.EndHorizontal();

    }

    public BuildTowerDialog setCaller(GameObject call)
    {
        caller = call;
        return this;
    }

    public void Open()
    {
        windowRect.x = Input.mousePosition.x;
        windowRect.y = Screen.height - Input.mousePosition.y;
        opened = true;
    }

    public void Close()
    {
        opened = false;
    }
}