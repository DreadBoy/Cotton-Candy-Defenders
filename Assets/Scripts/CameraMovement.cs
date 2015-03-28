using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraMovement : MonoBehaviour
{

    public List<GameObject> levels = new List<GameObject>();


    // Update is called once per frame
    void Update()
    {

        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            move += Vector3.left + Vector3.back;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right + Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            move += Vector3.right + Vector3.back;
        if (Input.GetKey(KeyCode.W))
            move += Vector3.left + Vector3.forward;

        Vector3 positionNew = transform.position + move;
        /*
        Debug.Log(positionNew.ToString());

        foreach (var level in levels)
        {
            if (level != null)
                if (!level.collider.bounds.Contains(positionNew))
                {
                    positionNew.x = Mathf.Clamp(positionNew.x, level.collider.bounds.min.x, level.collider.bounds.max.x);
                    positionNew.z = Mathf.Clamp(positionNew.z, level.collider.bounds.min.z, level.collider.bounds.max.z);
                }
        }
        */

        transform.position = positionNew;
        
    }

    public void gotoLevel(int level){
        if (levels[level - 1] == null)
            return;
        if(levels[level - 1].GetComponent<CameraStats>() == null)
            return;
        transform.position = levels[level - 1].transform.position;
        camera.orthographicSize = levels[level - 1].GetComponent<CameraStats>().Size;
    }

}
