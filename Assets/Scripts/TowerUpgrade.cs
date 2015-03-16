using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(TowerStats))]
[RequireComponent(typeof(TowerUpgradeDialog))]
public class TowerUpgrade : MonoBehaviour
{

    TowerStats towerStats = null;

	GameObject starPrefab = null;
	GameObject canvas = null;

    TowerUpgradeDialog upgradeTowerDialog = null;
	LevelBehaviour levelBehaviour = null;

	List<GameObject> stars = new List<GameObject>();

    void Start()
    {
        towerStats = GetComponent<TowerStats>();
        upgradeTowerDialog = GetComponent<TowerUpgradeDialog>();
		levelBehaviour = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelBehaviour>();

		starPrefab = Resources.Load<GameObject>("GUI skin/star_gold");
		var canvasPrefab = Resources.Load<GameObject>("GUI skin/canvas_tower_upgrade");
		canvas = (GameObject)Instantiate(canvasPrefab);

		displayStars();
    }

	public void displayStars(){
		foreach(var star in stars){
			Destroy(star);
		}
		stars.Clear();

		canvas.transform.SetParent(gameObject.transform);

		Vector3 position = Vector3.zero;

		var width = towerStats.level * 20;
		position.z = towerStats.shotPosition.y;

		canvas.GetComponent<RectTransform>().localPosition = position;
		canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 15);

		Vector3 offset = Vector3.zero;

		for (int i = 0; i < towerStats.level; i++) {
			stars.Add((GameObject)Instantiate(starPrefab, Vector3.zero, Quaternion.identity));

			stars[stars.Count - 1].transform.SetParent(canvas.transform);

			var rectTransform = stars[stars.Count - 1].GetComponent<RectTransform>();
			rectTransform.anchoredPosition = Vector3.zero + offset;
			rectTransform.localRotation = Quaternion.identity;

			offset.x += 20;
		}
	}

    void OnMouseDown()
    {
		if (upgradeTowerDialog != null && levelBehaviour.canBuild)
            upgradeTowerDialog.setCaller(this).Toggle();
    }

    public void Upgrade()
    {
        if (towerStats.level < 3)
        {
            towerStats.level++;
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
