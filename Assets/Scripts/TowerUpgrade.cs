using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(TowerStats))]
[RequireComponent(typeof(TowerUpgradeDialog))]
public class TowerUpgrade : MonoBehaviour
{

    TowerStats towerStats = null;

    GUISkin skin;
	GameObject starPrefab = null;

	GameObject canvas = null;

    TowerUpgradeDialog upgradeTowerDialog = null;
	LevelBehaviour levelBehaviour = null;

	List<GameObject> stars = new List<GameObject>();

    void Start()
    {
        towerStats = GetComponent<TowerStats>();
        upgradeTowerDialog = GetComponent<TowerUpgradeDialog>();
		levelBehaviour = GameObject.Find("Level").GetComponent<LevelBehaviour>();

		starPrefab = Resources.Load<GameObject>("GUI skin/star_gold");

        skin = Resources.Load<GUISkin>("GUI skin/CCD");

		canvas = GameObject.Find("Canvas - Tower Upgrades");

		displayStars();
    }

	public void displayStars(){
		foreach(var star in stars){
			Destroy(star);
		}
		stars.Clear();

		
		Vector3 position = Camera.main.WorldToScreenPoint(towerStats.transform.position + towerStats.shotPosition);
		position.y = Screen.height - position.y;
		var width = towerStats.level * 20;
		position.y += 20;
		position.x = position.x - width / 2 + 10;
		Vector3 offset = Vector3.zero;

		for (int i = 0; i < towerStats.level; i++) {
			stars.Add((GameObject)Instantiate(starPrefab, Vector3.zero, Quaternion.identity));
			stars[stars.Count - 1].GetComponent<RectTransform>().localPosition = position + offset;
			stars[stars.Count - 1].transform.SetParent(canvas.transform);
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
