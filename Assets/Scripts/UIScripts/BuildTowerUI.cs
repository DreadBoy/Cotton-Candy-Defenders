using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BuildTowerUI : MonoBehaviour
{

    private GameObject buildTowerLabel;
    private GameObject upgradeTowerLabel;
    public GameObject caller;

    void Start()
    {

        buildTowerLabel = GameObject.Find("BuildTowerLabel");
        buildTowerLabel.GetComponent<UIDialog>().Close();
        upgradeTowerLabel = GameObject.Find("UpgradeTowerLabel");
        upgradeTowerLabel.GetComponent<UIDialog>().Close();


    }

    public BuildTowerUI setCaller(GameObject call)
    {
        caller = call;
        return this;
    }

    public void OpenBuildDialog()
    {
        buildTowerLabel.GetComponent<BuildTowerLabelBehaviour>().resize();
        buildTowerLabel.GetComponent<UIDialog>().Open(Input.mousePosition);
    }

    public void CloseBuildDialog()
    {
        buildTowerLabel.GetComponent<UIDialog>().Close();
    }

    public void OpenUpgradeDialog()
    {
        upgradeTowerLabel.GetComponent<UpgradeTowerLabelBehaviour>().setCaller(caller);
        upgradeTowerLabel.GetComponent<UIDialog>().Open(Input.mousePosition);
    }

    public void CloseUpgradeDialog()
    {
        upgradeTowerLabel.GetComponent<UIDialog>().Close();
    }
}
