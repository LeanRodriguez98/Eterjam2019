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
        public string horizontalAxis;
        public KeyCode jump;
        public KeyCode shoot;
    }

    [System.Serializable]
    public struct JoysticsControls
    {
        public string horizontalAxis;
        public string jumpButton;
        public string shootButton;
    }

    public enum FacingDirection
    {
        Left,
        Right
    }

    public Controls controls;
    public JoysticsControls joysticsControls;
    public Stats stats;
    public GameObject bullet;
    private Rigidbody2D rigidbody2d;
    private bool canJump = true;
    private FacingDirection facingDirection = FacingDirection.Right;
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
        if (Input.GetAxis(controls.horizontalAxis) != 0 || Input.GetAxis(joysticsControls.horizontalAxis) != 0)
        {
            gameObject.transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * stats.speedMovement;

            if (Input.GetAxis(controls.horizontalAxis) < 0 || Input.GetAxis(joysticsControls.horizontalAxis) < 0)
            {
                facingDirection = FacingDirection.Left;
            }
            else
            {
                facingDirection = FacingDirection.Right;
            }
        }

        if ((Input.GetKeyDown(controls.jump) || Input.GetButtonDown(joysticsControls.jumpButton)) && canJump)
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
        if (Input.GetKeyDown(controls.shoot) || Input.GetButtonDown(joysticsControls.shootButton))
        {
            GameObject bulletAux = Instantiate(bullet, transform.position, transform.rotation);
            if (facingDirection == FacingDirection.Left)
            {
                bulletAux.GetComponent<Bullet>().direction = Bullet.Direction.Left;
            }
            else if(facingDirection == FacingDirection.Right)
            {
                bulletAux.GetComponent<Bullet>().direction = Bullet.Direction.Right;
            }
        }
    }

}
