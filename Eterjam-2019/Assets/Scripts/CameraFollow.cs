using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    private float offsetY;

	// Use this for initialization
	void Start () {
        offsetY = target.position.y - transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {


            if (offsetY != target.position.y - transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - offsetY, transform.position.z);
                offsetY = target.position.y - transform.position.y;

            }
        }
    }
}
