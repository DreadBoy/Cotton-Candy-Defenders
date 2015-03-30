using UnityEngine;
using System.Collections;

public class SpotClick : MonoBehaviour
{
	BuildTowerUI buildTowerUI;

    // Use this for initialization
    void Start()
    {
		buildTowerUI = GameObject.Find ("Canvas - Tower Upgrades").GetComponent<BuildTowerUI>();
    }


    void OnMouseDown()
    {
		if (buildTowerUI != null)
			buildTowerUI.setCaller(gameObject).OpenBuildDialog();
    }
}
