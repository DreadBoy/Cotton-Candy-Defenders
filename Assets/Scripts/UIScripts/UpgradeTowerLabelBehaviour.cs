using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UIDialog))]
public class UpgradeTowerLabelBehaviour : MonoBehaviour
{

    private GameObject caller;

    public void setCaller(GameObject call)
    {
        caller = call;
    }
    public void UpgradeTower()
    {
        TowerUpgrade tower = caller.GetComponent<TowerUpgrade>();
        if (tower != null)
        {
            tower.Upgrade();
            GetComponent<UIDialog>().Close();
        }
    }

    public void DemolishTower()
    {
        TowerUpgrade tower = caller.GetComponent<TowerUpgrade>();
        if (tower != null)
        {
            tower.Demolish();
            GetComponent<UIDialog>().Close();
        }
    }
}
