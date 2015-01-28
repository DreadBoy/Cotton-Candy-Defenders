using UnityEngine;
using System.Collections;

public class SpotClick : MonoBehaviour
{
    public BuildTowerDialog buildTowerDialog;

    // Use this for initialization
    void Start()
    {
        
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
