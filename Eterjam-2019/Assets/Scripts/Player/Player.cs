using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public struct Stats
    {
        public int life;
        public int speedMovement;
    }

    public struct Controls
    {
        public KeyCode upKey;
        public KeyCode downKey;
        public KeyCode leftKey;
        public KeyCode rightKey;
        public string horizontalAxis;
        public string verticalAxis;
    }

    public Controls controls;
    public Stats stats;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
