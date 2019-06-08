using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [System.Serializable]
    public struct Stats
    {
        public int speedMovement;
    }

    [System.Serializable]
    public struct Controls
    {
        public KeyCode upKey;
        public KeyCode downKey;
        public KeyCode leftKey;
        public KeyCode rightKey;
    }

    public Controls controls;
    public Stats stats;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        Movements();
	}

    public void Movements()
    {
        if (Input.GetKey(controls.leftKey))
        {
            gameObject.transform.position += new Vector3(-stats.speedMovement * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(controls.rightKey))
        {
            gameObject.transform.position += new Vector3(stats.speedMovement * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(controls.upKey))
        {
            gameObject.transform.position += new Vector3(0, stats.speedMovement * Time.deltaTime, 0);
        }

        if (Input.GetKey(controls.downKey))
        {
            gameObject.transform.position += new Vector3(0, -stats.speedMovement * Time.deltaTime, 0);
        }
    }

}
