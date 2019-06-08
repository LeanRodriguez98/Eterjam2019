using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [System.Serializable]
    public struct Stats
    {
        public int life;
        public int speedMovement;
        public int jumpSpeed;
        public float jumpCoulDown;
    }

    [System.Serializable]
    public struct Controls
    {
        public KeyCode leftKey;
        public KeyCode rightKey;
        public KeyCode jump;
    }

    public Controls controls;
    public Stats stats;
    private Rigidbody2D rigidbody2d;
    private bool canJump = true;
	void Start ()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Movements();
        Shoot();
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

        if (Input.GetKeyDown(controls.jump) && canJump)
        {
            rigidbody2d.AddForce(Vector3.up * stats.jumpSpeed);
            canJump = false;
            Invoke("CanJumpReseter", stats.jumpCoulDown);
        }
      
    }

    public void CanJumpReseter()
    {
        canJump = true;
    }

    public void Shoot()
    {

    }

}
