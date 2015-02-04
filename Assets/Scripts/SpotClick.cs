using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BuildTowerDialog))]
public class SpotClick : MonoBehaviour
{
    BuildTowerDialog buildTowerDialog;

    // Use this for initialization
    void Start()
    {
        buildTowerDialog = GetComponent<BuildTowerDialog>();
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
