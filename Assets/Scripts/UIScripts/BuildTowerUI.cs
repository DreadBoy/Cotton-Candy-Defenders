using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BuildTowerUI : MonoBehaviour {
    	private GameObject buildTowerLabel;

	private GameObject caller;
	
	void Start () {

        buildTowerLabel = GameObject.Find("BuildTowerLabel");
        buildTowerLabel.GetComponent<BuildTowerLabelBehaviour>().Close();

	}
	
	public BuildTowerUI setCaller(GameObject call)
	{
		caller = call;
		return this;
	}
	
	public void OpenBuildDialog()
	{
        buildTowerLabel.GetComponent<BuildTowerLabelBehaviour>().Open(Input.mousePosition);
	}

    public void CloseBuildDialog()
    {
        buildTowerLabel.GetComponent<BuildTowerLabelBehaviour>().Close();
	}
}
