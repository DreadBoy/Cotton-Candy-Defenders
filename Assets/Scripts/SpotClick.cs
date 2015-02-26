using UnityEngine;
using System.Collections;

public class SpotClick : MonoBehaviour
{
	BuildTowerLabelBehaviour buildTowerDialog;

    // Use this for initialization
    void Start()
    {
		buildTowerDialog = GameObject.Find ("BuildTowerLabel").GetComponent<BuildTowerLabelBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (buildTowerDialog != null)
            buildTowerDialog.setCaller(gameObject).Open();
    }
}
