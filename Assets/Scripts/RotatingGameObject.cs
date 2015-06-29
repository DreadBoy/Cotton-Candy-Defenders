using UnityEngine;
using System.Collections;
using System;

public class RotatingGameObject : MonoBehaviour {

    public Int32 speed;
    private Vector3 rotation = Vector3.zero;

    void Start()
    {
        rotation = new Vector3(0, 0, speed);
    }
	void Update () {
        transform.Rotate(rotation);
	}
}
