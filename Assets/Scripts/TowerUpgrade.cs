using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(TowerStats))]
public class TowerUpgrade : MonoBehaviour
{

    TowerStats towerStats = null;

    GameObject starPrefab = null;
    GameObject canvas = null;

    BuildTowerUI buildTowerUI;
    AreaBehaviour areaBehaviour = null;

    List<GameObject> stars = new List<GameObject>();

    PlayerGold playerGold = null;
    void Awake()
    {
        playerGold = GetComponent<PlayerGold>();
    }
    void Start()
    {
        towerStats = GetComponent<TowerStats>();
        buildTowerUI = GameObject.Find("Canvas - Tower Upgrades").GetComponent<BuildTowerUI>();
        areaBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<AreaBehaviour>();

        starPrefab = Resources.Load<GameObject>("GUI skin/star_gold");
        var canvasPrefab = Resources.Load<GameObject>("GUI skin/canvas_tower_upgrade");
        canvas = (GameObject)Instantiate(canvasPrefab);

        displayStars();
    }

    public void displayStars()
    {
        foreach (var star in stars)
        {
            Destroy(star);
        }
        stars.Clear();

        canvas.transform.SetParent(gameObject.transform);
        canvas.transform.localEulerAngles = new Vector3(315, 35, 125);

        Vector3 position = Vector3.zero;

        var width = towerStats.level * 20;
        position.z = towerStats.shotPosition.y;

        canvas.GetComponent<RectTransform>().localPosition = position;
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 15);

        Vector3 offset = Vector3.zero;

        for (int i = 0; i < towerStats.level; i++)
        {
            stars.Add((GameObject)Instantiate(starPrefab, Vector3.zero, Quaternion.identity));

            stars[stars.Count - 1].transform.SetParent(canvas.transform);

            var rectTransform = stars[stars.Count - 1].GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = Vector3.zero + offset;
            rectTransform.localRotation = Quaternion.identity;

            offset.x += 20;
        }
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            if (buildTowerUI != null && areaBehaviour.state == AreaBehaviour.State.building)
                buildTowerUI.setCaller(gameObject).OpenUpgradeDialog();
    }

    public void Upgrade()
    {
        if (towerStats.level < 3)
        {
            towerStats.level++;
            if (playerGold != null)
                playerGold.Spend(100);
            displayStars();
        }
    }

    public void Demolish()
    {
        Destroy(gameObject);
        towerStats.spot.SetActive(true);
    }

    public bool MaxedOut()
    {
        return towerStats.level >= 3;
    }
}
