using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class BuildTowerLabelBehaviour : MonoBehaviour
{

    TowerType[] types;
    TowerType[] allTypes = new TowerType[] { TowerType.basic, TowerType.slow, TowerType.stun, TowerType.pierce, TowerType.poison, TowerType.fear, TowerType.charm };
    public Dictionary<TowerType, GameObject> buttons = new Dictionary<TowerType, GameObject>();


    private GameObject spot;

    void Start()
    {
        GameObject level = GameObject.FindGameObjectWithTag("Level");
        if (level == null)
            return;
        int levelNum = level.GetComponent<LevelStats>().level;

        types = allTypes.Take(levelNum).ToArray<TowerType>();

        foreach (var type in allTypes)
        {
            buttons.Add(type, GameObject.Find("BuildTowerLabel/" + type.ToString()));
            if (buttons[type] != null)
                buttons[type].SetActive(types.Contains(type));
        }
        if (types.Length <= 3)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(55 * types.Length + 35, 65);
        }
        else if (types.Length < 7)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(55 * 3 + 35, GetComponent<RectTransform>().rect.heigh)t;
        }
    }

    public void buildTower(TowerType type)
    {
        GameObject tower = BuildTowerManager.buildTower(type, spot.transform.position);
        if (tower == null)
            return;
        tower.GetComponent<TowerStats>().spot = spot;
        spot.SetActive(false);
        this.Close();
    }


    public BuildTowerLabelBehaviour setCaller(GameObject call)
    {
        spot = call;
        return this;
    }

    public void Open(Vector3 mousePosition)
    {

        var rectTransform = GetComponent<RectTransform>();
        Boolean flipHorizontal = false,
            flipVertical = false;

        flipVertical = mousePosition.y - rectTransform.rect.height < 0;
        flipHorizontal = mousePosition.x + rectTransform.rect.width > Screen.width;

        Vector2 position = Vector2.zero;
        position.x = flipHorizontal ? mousePosition.x - rectTransform.rect.width : mousePosition.x;
        position.y = flipVertical ? mousePosition.y - Screen.height + rectTransform.rect.height : mousePosition.y - Screen.height;

        rectTransform.anchoredPosition = position;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.SetActive(false);
    }
}
