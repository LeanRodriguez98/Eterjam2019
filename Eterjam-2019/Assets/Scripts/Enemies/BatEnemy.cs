using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy {

    public float horizontalSpeed;
    public float LeftRightTime;

    public float UpDownTime;
    public float verticalSpeed;

    public GameObject enemyBullet;
    public float shootDelay = 2.0f;
    // Use this for initialization
    override public void Start() {
        base.Start();
        Invoke("ChangeDirection", LeftRightTime);
        Attack();
    }

    // Update is called once per frame
    override public void Update() {
        base.Start();
        Movement();
    }

    override public void Attack()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
        Invoke("Attack", shootDelay);
    }
    override public void Movement()
    {
        transform.position += Vector3.right * horizontalSpeed * stats.speedMovement * Time.deltaTime;
        transform.position += Vector3.up * verticalSpeed * stats.speedMovement * Mathf.Sin(Time.timeSinceLevelLoad);
    }
    public void ChangeDirection()
    {
        horizontalSpeed *= -1;
        Invoke("ChangeDirection", LeftRightTime);
    }
}
