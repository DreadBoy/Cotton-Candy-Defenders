using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BuildTowerLabelBehaviour : MonoBehaviour {

	TowerType[] types;
	TowerType[] allTypes = new TowerType[]{TowerType.basic, TowerType.slow, TowerType.stun, TowerType.pierce, TowerType.poison, TowerType.fear, TowerType.charm};
	public Dictionary<TowerType, GameObject> buttons = new Dictionary<TowerType, GameObject>();

	
	private GameObject spot;

	void Start () {
		GameObject level = GameObject.Find ("Level");
		if(level == null)
			return;
		int levelNum = level.GetComponent<LevelStats>().level;

		types = allTypes.Take (levelNum).ToArray<TowerType>();

		foreach (var type in allTypes) {
			buttons.Add(type, GameObject.Find("BuildTowerLabel/" + type.ToString()));
			if(buttons[type] != null)
				buttons[type].SetActive(types.Contains(type));
		}
	}

	public void buildTower(TowerType type){
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
	
	public void Open()
	{
		gameObject.SetActive (true);
	}
	
	public void Close()
	{
		gameObject.SetActive (false);
	}
}
