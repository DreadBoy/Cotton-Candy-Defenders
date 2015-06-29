using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;


public class TabsManager : MonoBehaviour {
    [Serializable]
    public class Tab
    {
        public Button tab;
        public GameObject panel;
    }

    public Int32 defaultIndex = 0;
    private Int32 index = 0;

    public List<Tab> tabs = new List<Tab>();

	// Use this for initialization
	void Start () {
        if (defaultIndex < 0 || defaultIndex > tabs.Count - 1)
            return;
        index = defaultIndex;
        for (int i = 0; i < tabs.Count; i++)
        {
            var tab = tabs[i];
            if(tab.tab == null || tab.panel == null)
                continue;
            tab.panel.SetActive(i == index);
            buttonSetup(tab.tab);
        }
	}

    void buttonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => switchTab(button));
    }

    private void switchTab(Button button)
    {
        index = tabs.FindIndex(t => t.tab == button);
        for (int i = 0; i < tabs.Count; i++)
        {
            var tab = tabs[i];
            tab.panel.SetActive(i == index);
        }
    }
}
