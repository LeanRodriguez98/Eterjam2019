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
        public float fallMultiplier;
        public float shortJumpMultiplier;
        public int damageResistance;
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


    public static Player playerInstance;


    private Rigidbody2D rigidbody2d;
    private FacingDirection facingDirection = FacingDirection.Right;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        playerInstance = this;
    }
    void Start ()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (stats.damageResistance < 0)
        {
            stats.damageResistance = 0;
            Debug.LogWarning(gameObject.name + " Error. Damage resistance can't be less at 0");
        }
    }
	
	void Update ()
    {
        Movements();
        Shoot();
        if (stats.life <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void Movements()
    {
        if (Input.GetAxis(controls.horizontalAxis) != 0 || Input.GetAxis(joysticsControls.horizontalAxis) != 0)
        {
            gameObject.transform.position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * stats.speedMovement;

            if (Input.GetAxis(controls.horizontalAxis) < 0 || Input.GetAxis(joysticsControls.horizontalAxis) < 0)
            {
                facingDirection = FacingDirection.Left;
                spriteRenderer.flipX = true;
            }
            else
            {
                facingDirection = FacingDirection.Right;
                spriteRenderer.flipX = false;

            }
        }

        if ((Input.GetKeyDown(controls.jump) || Input.GetButtonDown(joysticsControls.jumpButton)) && rigidbody2d.velocity.y == 0)
        {
            rigidbody2d.velocity += Vector2.up * stats.jumpSpeed;
        }

        if (rigidbody2d.velocity.y < 0)
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (stats.fallMultiplier - 1) * Time.deltaTime;
        else if (rigidbody2d.velocity.y > 0 && !Input.GetKey(controls.jump))
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (stats.shortJumpMultiplier - 1) * Time.deltaTime;

        if (rigidbody2d.velocity.y > 0 && !Input.GetButton(joysticsControls.jumpButton))
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (stats.shortJumpMultiplier - 1) * Time.deltaTime;
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

    public void SetDamage(int damage)
    {
        stats.life -= (damage - stats.damageResistance);
    }

}
