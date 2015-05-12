using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[RequireComponent(typeof(UIDialog))]
public class BuildTowerLabelBehaviour : MonoBehaviour
{

    TowerType[] types;
    TowerType[] allTypes = new TowerType[] { TowerType.basic, TowerType.slow, TowerType.stun, TowerType.pierce, TowerType.poison, TowerType.fear, TowerType.charm };
    public Dictionary<TowerType, GameObject> buttons = new Dictionary<TowerType, GameObject>();
    public BuildTowerManager buildTowerManager = null;
    public BuildTowerUI buildTowerUI = null;

    private UIDialog UIdialog = null;

    void Awake()
    {
        GameObject level = GameObject.FindGameObjectWithTag("Level");
        if (level == null)
            return;
        int levelNum = level.GetComponent<AreaBehaviour>().level;

        types = allTypes.Take(levelNum).ToArray<TowerType>();

        foreach (var type in allTypes)
        {
            buttons.Add(type, GameObject.Find("BuildTowerLabel/" + type.ToString()));
            if (buttons[type] != null)
                buttons[type].SetActive(types.Contains(type));
        }
        resize();

        UIdialog = GetComponent<UIDialog>();
    }

    public void resize()
    {
        if (types.Length <= 3)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(65 * types.Length + 60, 75);
        }
        else if (types.Length < 7)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(65 * 3 + 60, GetComponent<RectTransform>().rect.height);
        }
    }

    public void buildTower(int type)
    {
        this.buildTower((TowerType)type);
    }

    public void buildTower(TowerType type)
    {
        if (buildTowerManager == null || buildTowerUI == null)
            return;
        GameObject tower = buildTowerManager.buildTower(type, buildTowerUI.caller.transform.position);
        if (tower == null)
            return;
        tower.GetComponent<TowerStats>().spot = buildTowerUI.caller;
        buildTowerUI.caller.SetActive(false);
        UIdialog.Close();
    }

}
