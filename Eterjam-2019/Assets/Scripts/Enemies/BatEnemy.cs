using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : Enemy {

    public float horizontalSpeed;
    public float LeftRightTime;

    public float UpDownTime;
    public float verticalSpeed;

    // Use this for initialization
    override public void Start() {
        base.Start();
        Invoke("ChangeDirection", LeftRightTime);
    }

    // Update is called once per frame
    override public void Update() {
        base.Start();
        Movement();
    }


    public void Movement()
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
